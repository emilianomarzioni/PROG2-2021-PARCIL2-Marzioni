using System;
using System.Collections.Generic;
using System.Text;

namespace Logica.Clases
{
   public class Repartidor : Persona
    {
        public decimal ComisionPorEnvio { get; set; }
        public int CantidadEnviosEntregados(DateTime d,DateTime d2)
        {
            return Empresa.Instancia.ObtenerCantidadEnviosRealizadosPorVendedor(this, d, d2);
        }
    }
    
}
