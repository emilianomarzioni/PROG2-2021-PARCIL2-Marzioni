using System;
using System.Collections.Generic;
using System.Text;

namespace Logica.Clases
{
    public class Persona
    {
        public int Dni { get; set; }
        public string NombreApellido { get; set; }
        public int CodigoPostal { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long? Telefono { get; set; }
    }
}
