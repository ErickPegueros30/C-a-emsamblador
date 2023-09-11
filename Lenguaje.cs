using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
    Requerimiento 1: Mensajes del printf deben salir sin comillas
                     Incluir \n y \t como secuencias de escape
    Requerimiento 2: Agregar el % al PorFactor
                     Modifcar el valor de una variable con ++,--,+=,-=,*=,/=.%=
    Requerimiento 3: Cada vez que se haga un match(Tipos.Identificador) verficar el
                     uso de la variable
                     Icremento(), Printf(), Factor() y usar getValor y Modifica
                     Levantar una excepcion en scanf() cuando se capture un string
    Requerimiento 4: Implemenar la ejecución del ELSE
*/

namespace Sintaxis_2
{
    public class Lenguaje : Sintaxis
    {
        List<Variable> lista;
        Stack<float> stack;
        public Lenguaje()
        {
            lista = new List<Variable>();
            stack = new Stack<float>();
        }
        public Lenguaje(string nombre) : base(nombre)
        {
            lista = new List<Variable>();
            stack = new Stack<float>();
        }

        //Programa  -> Librerias? Variables? Main
        public void Programa()
        {
            bool ejecuta = true;
            if (getContenido() == "#")
            {
                Librerias();
            }
            if (getClasificacion() == Tipos.TipoDato)
            {
                Variables();
            }
            Main(ejecuta);
            Agregada();

        }
        private void Agregada()
        {
            bool agregada;
            foreach (Variable v in lista)
            {
                agregada = v.getAgregada();
                if (!agregada)
                {
                    Console.WriteLine("Advertencia: La variable <" + v.getNombre() + "> nunca fue utilizada");
                }
            }
        }

        private void Imprime()
        {
            log.WriteLine("-----------------");
            log.WriteLine("V a r i a b l e s");
            log.WriteLine("-----------------");
            foreach (Variable v in lista)
            {
                v.setAgregada(true);
                log.WriteLine(v.getNombre() + " " + v.getTiposDatos() + " = " + v.getValor());
            }
            log.WriteLine("-----------------");
        }

        private bool Existe(string nombre)
        {
            foreach (Variable v in lista)
            {
                if (v.getNombre() == nombre)
                {
                    return true;
                }
            }
            return false;
        }
        private void Modifica(string nombre, float nuevoValor)
        {
            foreach (Variable v in lista)
            {
                if (v.getNombre() == nombre)
                {
                    v.setAgregada(true);
                    v.setValor(nuevoValor);
                }
            }
        }
        private float getValor(string nombre)
        {
            foreach (Variable v in lista)
            {
                if (v.getNombre() == nombre)
                {
                    v.setAgregada(true);
                    return v.getValor();
                }
            }
            return 0;
        }
        // Libreria -> #include<Identificador(.h)?>
        private void Libreria()
        {
            match("#");
            match("include");
            match("<");
            //Console.WriteLine(getContenido());
            match(Tipos.Identificador);
            if (getContenido() == ".")
            {
                match(".");
                match("h");
            }
            match(">");
        }
        //Librerias -> Libreria Librerias?
        private void Librerias()
        {
            Libreria();
            if (getContenido() == "#")
            {
                Librerias();
            }
        }
        //Variables -> tipo_dato ListaIdentificadores; Variables?
        private void Variables()
        {
            Variable.TiposDatos tipo = Variable.TiposDatos.Char;
            switch (getContenido())
            {
                case "int": tipo = Variable.TiposDatos.Int; break;
                case "float": tipo = Variable.TiposDatos.Float; break;
            }
            match(Tipos.TipoDato);
            ListaIdentificadores(tipo);
            match(";");
            if (getClasificacion() == Tipos.TipoDato)
            {
                Variables();
            }
        }
        //ListaIdentificadores -> identificador (,ListaIdentificadores)?
        private void ListaIdentificadores(Variable.TiposDatos tipo)
        {
            if (!Existe(getContenido()))
            {
                lista.Add(new Variable(getContenido(), tipo));
            }
            else
            {
                throw new Error("de sintaxis, la variable <" + getContenido() + "> está duplicada", log, linea, columna);
            }
            match(Tipos.Identificador);
            if (getContenido() == ",")
            {
                match(",");
                ListaIdentificadores(tipo);
            }
        }
        //BloqueInstrucciones -> { ListaInstrucciones ? }
        private void BloqueInstrucciones(bool ejecuta)
        {
            match("{");
            if (getContenido() != "}")
            {
                ListaInstrucciones(ejecuta);
            };
            match("}");
        }

        //ListaInstrucciones -> Instruccion ListaInstrucciones?
        private void ListaInstrucciones(bool ejecuta)
        {
            Instruccion(ejecuta);
            if (getContenido() != "}")
            {
                ListaInstrucciones(ejecuta);
            }
        }
        //Instruccion -> Printf | Scanf | If | While | Do | For | Asignacion
        private void Instruccion(bool ejecuta)
        {
            if (getContenido() == "printf")
            {
                Printf(ejecuta);
            }
            else if (getContenido() == "scanf")
            {
                Scanf(ejecuta);
            }
            else if (getContenido() == "if")
            {
                If(ejecuta);
            }
            else if (getContenido() == "while")
            {
                While(ejecuta);
            }
            else if (getContenido() == "do")
            {
                Do(ejecuta);
            }
            else if (getContenido() == "for")
            {
                For(ejecuta);
            }
            else
            {
                Asignacion(ejecuta);
            }
        }
        //Asignacion -> identificador = Expresion;
        private void Asignacion(bool ejecuta)
        {
            if (!Existe(getContenido()))
            {
                throw new Error("de sintaxis, la variable <" + getContenido() + "> no está declarada", log, linea, columna);
            }
            log.Write(getContenido() + " = ");
            string variable = getContenido(); // En Variable se guardó b
            match(Tipos.Identificador);

            if (getContenido() == "=")
            {
                match("=");
                Expresion();
            }
            else if (getClasificacion() == Tipos.IncrementoTermino)
            {
                //Console.WriteLine(getContenido());
                foreach (Variable v in lista)
                {
                    if (v.getNombre() == variable)
                    {
                        v.setAgregada(true);
                        if (getContenido() == "++")
                        {
                            v.setValor(v.getValor() + 1);
                            match("++");
                        }
                        else
                        {
                            v.setValor(v.getValor() - 1);
                            match("--");
                        }
                        stack.Push(v.getValor());
                    }
                }

            }
            else if (getClasificacion() == Tipos.IncrementoFactor)
            {
                foreach (Variable v in lista)
                {
                    if (variable == v.getNombre())
                    {
                        if (getContenido() == "+=")
                            {
                                match("+=");
                                if (getContenido() == "(")
                                {
                                    Expresion();
                                    v.setValor(v.getValor() + stack.Pop());
                                }
                                else
                                {
                                    float resultado1;
                if(float.TryParse(getContenido(),out resultado1)){
                    v.setValor(v.getValor() + resultado1);
                                    match(Tipos.Numero);
                }else{
                    throw new Error("de Parseo", log, linea, columna); 
                }   
                                    
                                }
                            }
                            else if (getContenido() == "-=")
                            {
                                match("-=");
                                if (getContenido() == "(")
                                {
                                    
                                    Expresion();
                                    v.setValor(v.getValor() - stack.Pop());
                                }
                                else
                                {
                                    float resultado2;
                if(float.TryParse(getContenido(),out resultado2)){
                    
                                    v.setValor(v.getValor() - resultado2);
                                    match(Tipos.Numero);
                }else{
                    throw new Error("de Parseo", log, linea, columna); 
                } 
                                }
                            }
                            else if (getContenido() == "*=")
                            {
                                match("*=");
                                if (getContenido() == "(")
                                {
                                    Expresion();
                                    v.setValor(v.getValor() * stack.Pop());
                                }
                                else
                                {
                                    float resultado3;
                if(float.TryParse(getContenido(),out resultado3)){
                    v.setValor(v.getValor() * resultado3);
                                    match(Tipos.Numero);
                }else{
                    throw new Error("de Parseo", log, linea, columna); 
                } 
                                    
                                }
                            }
                            else if (getContenido() == "/=")
                            {
                                match("/=");
                                if (getContenido() == "(")
                                {
                                    Expresion();
                                    v.setValor(v.getValor() / stack.Pop());
                                }
                                else
                                {
                                    float resultado4;
                if(float.TryParse(getContenido(),out resultado4)){
                    v.setValor(v.getValor() / resultado4);
                                    match(Tipos.Numero);
                }else{
                    throw new Error("de Parseo", log, linea, columna); 
                } 
                                    
                                }
                            }
                            else if (getContenido() == "%=")
                            {
                                match("%=");
                                if (getContenido() == "(")
                                {
                                    Expresion();
                                    v.setValor(v.getValor() % stack.Pop());
                                }
                                else
                                {
                                    float resultado5;
                if(float.TryParse(getContenido(),out resultado5)){
                     v.setValor(v.getValor() % resultado5);
                                    match(Tipos.Numero);
                }else{
                    throw new Error("de Parseo", log, linea, columna); 
                }   
                                }
                            }
                            stack.Push(v.getValor());
                    }
                }
            }
            float resultado = stack.Pop();
            log.WriteLine(" = " + resultado);
            if (ejecuta)
            {
                Modifica(variable, resultado);
            }
            match(";");
        }

        //While -> while(Condicion) BloqueInstrucciones | Instruccion
        private void While(bool ejecuta)
        {
            match("while");
            match("(");
            Condicion();
            match(")");
            if (getContenido() == "{")
            {
                BloqueInstrucciones(ejecuta);
            }
            else
            {
                Instruccion(ejecuta);
            }

        }
        //Do -> do BloqueInstrucciones | Instruccion while(Condicion)
        private void Do(bool ejecuta)
        {
            match("do");
            if (getContenido() == "{")
            {
                BloqueInstrucciones(ejecuta);
            }
            else
            {
                Instruccion(ejecuta);
            }
            match("while");
            match("(");
            Condicion();
            match(")");
            match(";");
        }
        //For -> for(Asignacion Condicion; Incremento) BloqueInstrucciones | Instruccion
        private void For(bool ejecuta)
        {
            match("for");
            match("(");
            Asignacion(ejecuta);
            Condicion();
            match(";");
            Incremento(ejecuta);
            match(")");
            if (getContenido() == "{")
            {
                BloqueInstrucciones(ejecuta);
            }
            else
            {
                Instruccion(ejecuta);
            }
        }
        //Incremento -> Identificador ++ | --
        private void Incremento(bool ejecuta)
        {
            if (!Existe(getContenido()))
            {
                throw new Error("de sintaxis, la variable <" + getContenido() + "> no está declarada", log, linea, columna);
            }
            match(Tipos.Identificador);
            if (getContenido() == "++")
            {
                match("++");
            }
            else
            {
                match("--");
            }
        }
        //Condicion -> Expresion OperadorRelacional Expresion
        private bool Condicion()
        {
            Expresion();
            string operador = getContenido();
            match(Tipos.OperadorRelacional);
            Expresion();
            float R1 = stack.Pop();
            float R2 = stack.Pop();

            switch (operador)
            {
                case "==": return R2 == R1;
                case ">": return R2 > R1;
                case ">=": return R2 >= R1;
                case "<": return R2 < R1;
                case "<=": return R2 <= R1;
                default: return R2 != R1;
            }

        }
        //If -> if (Condicion) BloqueInstrucciones | Instruccion (else BloqueInstrucciones | Instruccion)?
        private void If(bool ejecuta)
        {
            match("if");
            match("(");
            bool evaluacion = Condicion() && ejecuta;
            match(")");
            if (getContenido() == "{")
            {
                BloqueInstrucciones(evaluacion);
            }
            else
            {
                Instruccion(evaluacion);
            }
            if (getContenido() == "else")
            {
                match("else");

                if (getContenido() == "{")
                {
                    BloqueInstrucciones(!evaluacion); // Ejecutar el bloque de instrucciones dentro del "else" si no se cumplió la condición
                }
                else
                {
                    Instruccion(!evaluacion); // Ejecutar la instrucción dentro del "else" si no se cumplió la condición
                }
            }
        }

        //Printf -> printf(cadena(,Identificador)?);
        private void Printf(bool ejecuta)
        {
            match("printf");
            match("(");

            if (ejecuta)
            {
                string comillas = getContenido();
                if (comillas == getContenido()){
                comillas = getContenido().Replace("\"", "");
                comillas = comillas.Replace("\\t", "\t");
                comillas = comillas.Replace("\\n", "\n");
                Console.Write(comillas);
                }
            }

            match(Tipos.Cadena);
            if (getContenido() == ",")
            {
                match(",");
                if (!Existe(getContenido()))
                {
                    throw new Error("de sintaxis, la variable <" + getContenido() + "> no está declarada", log, linea, columna);
                }
                foreach (Variable v in lista)
                {
                    if (v.getNombre() == getContenido())
                    {
                        v.setAgregada(true);
                        Console.WriteLine(v.getValor()); 
                    }
                }
                match(Tipos.Identificador);
            }
            match(")");
            match(";");

        }

        //Scanf -> scanf(cadena,&Identificador);
        private void Scanf(bool ejecuta)
        {   
            match("scanf");
            match("(");
            match(Tipos.Cadena);
            match(",");
            match("&");
            if (!Existe(getContenido()))
            {
                throw new Error("de sintaxis, la variable <" + getContenido() + "> no está declarada", log, linea, columna);
            }
            string variable = getContenido();
            match(Tipos.Identificador);
            if (ejecuta)
            {
                string captura = "" + Console.ReadLine();
                float resultado;
                if (float.TryParse(captura, out resultado))
                {
                    Modifica(variable, resultado);

                }
                else
                {
                    throw new Error("de sintaxis, la variable es de Tipo String", log, linea, columna);
                }
            }
            match(")");
            match(";");
        }
        //Main -> void main() BloqueInstrucciones
        private void Main(bool ejecuta)
        {
            match("void");
            match("main");
            match("(");
            match(")");
            BloqueInstrucciones(ejecuta);
        }
        //Expresion -> Termino MasTermino
        private void Expresion()
        {
            Termino();
            MasTermino();
        }
        //MasTermino -> (OperadorTermino Termino)?
        private void MasTermino()
        {
            if (getClasificacion() == Tipos.OperadorTermino)
            {
                string operador = getContenido();
                match(Tipos.OperadorTermino);
                Termino();
                log.Write(" " + operador);
                float R2 = stack.Pop();
                float R1 = stack.Pop();
                if (operador == "+")
                {
                    stack.Push(R1 + R2);
                }
                else
                {
                    stack.Push(R1 - R2);
                }
            }
        }
        //Termino -> Factor PorFactor
        private void Termino()
        {
            Factor();
            PorFactor();
        }
        //PorFactor -> (OperadorFactor Factor)?
        private void PorFactor()
        {
            if (getClasificacion() == Tipos.OperadorFactor)
            {
                string operador = getContenido();
                match(Tipos.OperadorFactor);
                Factor();
                log.Write(" " + operador);
                float R2 = stack.Pop();
                float R1 = stack.Pop();
                if (operador == "*")
                {
                    stack.Push(R1 * R2);
                }
                else if (operador == "/")
                {
                    stack.Push(R1 / R2);
                }
                else if (operador == "%")
                {
                    stack.Push(R1 % R2);
                }
            }
        }
        //Factor -> numero | identificador | (Expresion)
        private void Factor()
        {
            if (getClasificacion() == Tipos.Numero)
            {
                log.Write(" " + getContenido());
                string captura = "" + getContenido();
                float resultado;
                if (float.TryParse(captura, out resultado))
                {
                    stack.Push(resultado);
                }
                match(Tipos.Numero);
            }
            else if (getClasificacion() == Tipos.Identificador)
            {
                if (!Existe(getContenido()))
                {
                    throw new Error("de sintaxis, la variable <" + getContenido() + "> no está declarada", log, linea, columna);
                }
                foreach (Variable v in lista)
                {
                    if (v.getNombre() == getContenido())
                    {
                        v.setAgregada(true);
                        stack.Push(v.getValor());
                    }
                }
                match(Tipos.Identificador);
            }
            else if (getContenido() == "(")
            {
                match("(");
                Expresion();
                match(")");
            }
        }
    }
}