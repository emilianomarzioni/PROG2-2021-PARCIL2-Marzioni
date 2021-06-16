using Logica.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class EnvioResponse
    {
        private Envio envio;

        public EnvioResponse(Envio envio)
        {
            this.envio = envio;
        }

        public string CodigoSeguimiento { get; set; }
    }
}