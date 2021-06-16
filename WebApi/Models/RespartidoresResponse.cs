using Logica.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class RespartidoresResponse
    {
        public string NombreCompleto { get; set; }
        public decimal TotalGanadoPorComisiones { get; set; }
        public int CantEnviosRealizados { get; set; }
        public RespartidoresResponse(Repartidor r, DateTime d, DateTime h)
        {
            this.NombreCompleto = r.NombreApellido;
            this.CantEnviosRealizados = r.CantidadEnviosEntregados(d, h);
            this.TotalGanadoPorComisiones = r.ComisionPorEnvio * this.CantEnviosRealizados;

        }

    }
    public class RepartidoresResponseList
    {
        public List<RespartidoresResponse> repartidores;
        public RepartidoresResponseList()
        {
            repartidores = new List<RespartidoresResponse>();
        }
    }
}