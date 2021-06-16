using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logica;
using Logica.Clases;

namespace WebApi.Models
{
    public class EnvioRequest
    {
        public string FechaEstimadaDeEntrega { get; set; }
        public int Dni { get; set; }
        public string Descripcion { get; set; }
        public Envio CrearEnvio()
        {
            Envio env = new Envio(this.Dni,this.FechaEstimadaDeEntrega,this.Descripcion);
            return env;
        }
    }
    //public class AtencionRequest
    //{
    //    public int idCliente { get; set; }
    //    public int idEnfermedad { get; set; }
    //    public DateTime fecha { get; set; }

    //    public Atencion CrearAtencion()
    //    {
    //        Atencion atencion = new Atencion(this.fecha, this.idEnfermedad, this.idCliente);

    //        return atencion;
    //    }
    //}
}