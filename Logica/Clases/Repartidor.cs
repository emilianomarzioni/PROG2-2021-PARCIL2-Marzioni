using System;
using System.Collections.Generic;
using System.Text;

namespace Logica.Clases
{
   public class Repartidor : Persona
    {
        public decimal ComisionPorEnvio { get; set; }
        //ERROR DE MODELADO, NO DEBE ACCEDER A PRINCIPAL DESDE LOS OBJETOS.
        public int CantidadEnviosEntregados(DateTime d,DateTime d2)
        {
            return Empresa.Instancia.ObtenerCantidadEnviosRealizadosPorVendedor(this, d, d2);
        }
    }
    
}
