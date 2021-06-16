using System;
using System.Collections.Generic;
using System.Text;

namespace Logica.Clases
{
    public class Destinatario : Persona
    {
        public bool PoseeTelefono()
        {
            return this.Telefono.HasValue;
        }
    }
}
