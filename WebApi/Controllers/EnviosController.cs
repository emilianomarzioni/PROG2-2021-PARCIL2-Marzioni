using Logica;
using Logica.Clases;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EnviosController : ApiController
    {
        Empresa empresa = Empresa.Instancia;
        [Route("envios")]
        public IHttpActionResult Post([FromBody] EnvioRequest request)
        {
            Envio envio = request.CrearEnvio();
            Result result = empresa.CargarEnvio(envio);

            if (result.status)
            {
                return Content(HttpStatusCode.Created, result.ID);
            }
            return Content(HttpStatusCode.BadRequest, result);



           
        }
        
        public IHttpActionResult Put([FromBody] ActualizarEnvioRequest request,string idEnvio)
        {
            Envio envio = empresa.ObtenerEnvio(idEnvio);
            if(envio == null)
            {
                return Content(HttpStatusCode.BadRequest, "No existe el envio solicitado");
            }
            else
            {
               EstadoEnvio? estado =  envio.ModificarEstado(request.NewEstado);
                if(estado != null)
                    return Content(HttpStatusCode.BadRequest, "Estado Invalido");
                
                envio.Estado = estado.Value;
                Result resultado = empresa.ActualizarEnvio(envio);
                    return Ok();
            }
        }
        [Route("repartidores")]
        public IHttpActionResult Get(string desdeString,string hastaString)
        {
            var desde = DateTime.ParseExact(desdeString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var hasta = DateTime.ParseExact(hastaString, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            List<Repartidor>  repartidores = empresa.ObtenerRepartidores();
            RepartidoresResponseList reps = new RepartidoresResponseList();
            foreach (var rep in repartidores)
            {
                var repRes = new RespartidoresResponse(rep,desde,hasta);
                reps.repartidores.Add(repRes);
            }
            return Content(HttpStatusCode.OK, reps);
        }
        [Route("repartidor")]//asignar repartidor a un envio menor distancia entre desti y rep
        public IHttpActionResult Put(string idEnvio)
        {
            Envio envio = empresa.ObtenerEnvio(idEnvio);
            if (envio == null)            
                return Content(HttpStatusCode.BadRequest, "No existe el envio solicitado");
            
            Repartidor rep = empresa.ObtenerRepartidorCercano( envio.DestinatarioDNI);
            
            if (rep == null)
            {
                return Content(HttpStatusCode.BadRequest, "No se encontro un repartidor");
            }
            envio.RepartidorDNI = rep.Dni;
            Result result = empresa.ActualizarEnvio(envio);
            return Content(HttpStatusCode.OK, rep);
        }
    }
}
