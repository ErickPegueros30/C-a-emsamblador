using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sintaxis_2
{
    public class Variable
    {
        public enum TiposDatos { Char, Int, Float };

        private string nombre;
        public bool agregada = false;
        private float valor;
        private TiposDatos tipo;
        public Variable(string nombre, TiposDatos tipo)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.valor = 0;
        }
        public string getNombre()
        {
            return nombre;
        }
        public TiposDatos getTiposDatos()
        {
            return this.tipo;
        }
        public void setValor(float valor)
        {
            this.valor = valor;
        }
        public float getValor()
        {
            return valor;
        }
        public void setAgregada(bool valor)
        {
            this.agregada = valor;
        }
        public bool getAgregada(){
            return agregada;
        }

    }
}