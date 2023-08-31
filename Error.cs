
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sintaxis_2
{
    public class Error : Exception
    {
        private StreamWriter log;
        private object value;

        public Error(StreamWriter log, object value)
        {
            this.log = log;
            this.value = value;
        }


        public Error(string mensaje, StreamWriter log, int linea, int columna) : base(mensaje + " en la linea "+linea+" columna "+columna)
        {
            log.WriteLine("Error: "+mensaje+" en la linea "+linea+" columna "+columna);
        }
    }
}