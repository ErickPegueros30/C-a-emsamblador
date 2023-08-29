using System;

namespace Sintaxis_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (Sintaxis L = new Sintaxis("suma.cpp"))
                {
                    //L.Programa();

                    /*while (!L.FinArchivo())
                    {
                        L.nextToken();
                    }*/
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}