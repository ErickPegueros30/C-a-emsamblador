using System;

namespace Sintaxis_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Token T = new Token();

                T.setContenido("3.5e-8");
                T.setClasificacion(Token.Tipos.Numero);

                Console.WriteLine(T.getContenido());
                Console.WriteLine(T.getClasificacion());
                
                /*using (Lenguaje L = new Lenguaje("suma.cpp"))
                {
                    //L.Programa();
                    
                    while (!L.FinArchivo())
                    {
                        L.nextToken();
                    }
                    
                }*/
            } 
            catch (Exception e)
            {
                Console.WriteLine("Error: "+e.Message);
            }
        }
    }
}