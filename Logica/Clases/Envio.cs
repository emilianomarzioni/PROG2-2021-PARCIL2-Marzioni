using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logica.Clases
{
    public class Envio
    {       
        public EstadoEnvio Estado{ get; set; }
        public string ID { get; set; } 
        public int DestinatarioDNI { get; set; }
        public int RepartidorDNI { get; set; }
        public DateTime FechaEstimadaDeEntrega { get; set; }
        public DateTime FechadeEntrega { get; set; }        

        public Envio(int dni, string fechaEstimadaDeEntrega, string descripcion)
        {
            this.Estado = EstadoEnvio.Pendiente;
            this.ID = Empresa.GenerarID(); //PODRIA SER UN METODO DE ESTA CLASE Y NO DE OTRA
            this.DestinatarioDNI = dni;
            //USAR TIPO DE DATOS DATETIME EN ESTOS CASOS
            this.FechaEstimadaDeEntrega = DateTime.ParseExact(fechaEstimadaDeEntrega,"dd/MM/yyyy",CultureInfo.InvariantCulture);
        }

        //RECIBIR EL ENUMERADOR COMO PARAMETRO DIRECTAMENTE
        public EstadoEnvio? ModificarEstado(string newEstado)
        {

            EstadoEnvio conv = (EstadoEnvio)Enum.Parse(typeof(EstadoEnvio), newEstado);
            switch (conv)
            {
                case EstadoEnvio.Pendiente:
                    return null;
                case EstadoEnvio.AsignadoRepartidor:
                    if (this.Estado == EstadoEnvio.Pendiente)
                        return conv;
                    
                    break;
                case EstadoEnvio.EnCamino:
                    if (this.Estado == EstadoEnvio.AsignadoRepartidor)
                        return conv;
                    break;
                case EstadoEnvio.Entregado:
                    if (this.Estado == EstadoEnvio.EnCamino)
                        return conv;
                    break;
                default:
                    return null;
            }
            return null;
           
        }
    }
    public enum EstadoEnvio
    {
        Pendiente,
        AsignadoRepartidor,
        EnCamino,
        Entregado
    }
}
