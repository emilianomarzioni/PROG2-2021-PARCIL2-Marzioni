using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Result
    {
        public string ID { get; set; }
        public bool status { get; set; }
        public string error { get; set; }

        public Result(string id, bool Ok)
        {
            this.ID = id;
            this.status = true;
        }

        public Result(bool status, string error)
        {
            this.status = false;
            this.error = error;
        }

        public Result(bool v)
        {
            this.status = v;
        }
    }
}