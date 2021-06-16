using Logica.Clases;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public sealed class Empresa
    {
        public List<Destinatario> Destinatarios { get; set; }
        public List<Repartidor> Repartidores { get; set; }

        public List<Envio> Envios { get; set; }

        

        private readonly static Empresa _instance = new Empresa();               

        private Empresa()
        {
            if (Destinatarios == null)
                Destinatarios = new List<Destinatario>();
            if (Envios == null)
                Envios = new List<Envio>();
            if (Repartidores == null)
                Repartidores = new List<Repartidor>();
        }
        private static Random random = new Random();
        private double EarthRadius;

        public static string GenerarID()
        {            
            return random.Next(10000000, 100000000).ToString() ;
        }
        public static Empresa Instancia
        {
            get { return _instance; }
        }
        public Result CargarEnvio(Envio envio)
        {
           
            Destinatario destinatario = this.ValidarExistenciaDestinatario(envio.DestinatarioDNI);
            if (destinatario == null)
                return new Result(false, "No existe el destinatario.");
            if(!destinatario.PoseeTelefono())
                return new Result(false, "No tiene el telefono de contacto cargado.");
          
            this.Envios.Add(envio);
            return new Result(envio.ID, true);
        }

        public Result ActualizarEnvio(Envio envio)
        {
            var item = Envios.Find(x => x.ID == envio.ID);
            Envios.Remove(item);
            Envios.Add(envio);
           
            return new Result(true);
        }

        public List<Repartidor> ObtenerRepartidores()
        {
            return Repartidores;
        }
        public int ObtenerCantidadEnviosRealizadosPorVendedor(Repartidor r,DateTime desde,DateTime hasta)
        {
            return Envios.Count(x => x.RepartidorDNI == r.Dni && x.FechaEstimadaDeEntrega > desde && x.FechaEstimadaDeEntrega < hasta);
        }

        public Envio ObtenerEnvio(string idEnvio)
        {
            return Envios.FirstOrDefault(x => x.ID == idEnvio);
        }

        public Destinatario ValidarExistenciaDestinatario(int dni)
        {
            return Destinatarios.FirstOrDefault(x => x.Dni == dni);             
        }

        public Repartidor ObtenerRepartidorCercano( int destinatarioDNI)
        {
            Destinatario desti = this.ValidarExistenciaDestinatario(destinatarioDNI);
            double cercano = 0;
            Repartidor repCerc = null;
            foreach (var rep in Repartidores)
            {
                var d = CalcularDistancia(rep, desti);
                if (d < cercano)
                    repCerc = rep;
            }
            return repCerc;
        }

        

        private Repartidor ObtenerRepartidorPorDNI(int dni)
        {
            return Repartidores.FirstOrDefault(x => x.Dni == dni);
        }
        public double CalcularDistancia(Repartidor point1, Destinatario point2)
        {
            double distance = 0;
            double Lat = (point2.Latitude - point1.Latitude) * (Math.PI / 180);
            double Lon = (point2.Longitude - point1.Longitude) * (Math.PI / 180);
            double a = Math.Sin(Lat / 2) * Math.Sin(Lat / 2) + Math.Cos(point1.Latitude * (Math.PI / 180)) * Math.Cos(point2.Latitude * (Math.PI / 180)) * Math.Sin(Lon / 2) * Math.Sin(Lon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            distance = EarthRadius * c;
            return distance;
        }
    }
   

}
