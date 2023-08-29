using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sintaxis_2
{
    public class Lenguaje : Sintaxis
    {
        public Lenguaje()
        {

        }
        public Lenguaje(string nombre) : base (nombre)
        {

        }
        //Las librerias son obtativas
        public void Programa()
        {
            if(getContenido()=="#")
            {
            Librerias();
            }
            match("variable");
            match("main");
        }
        private void Librerias()
        {
            match("#");
            match("include");
            match("<");
            match(Tipos.Identificador);
        }
    }
}