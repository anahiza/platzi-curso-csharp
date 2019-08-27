using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using CoreEscuela.App;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit+=accionEvento;
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            //Printer.Beep(10000, cantidad: 10);
            ImpimirCursosEscuela(engine.Escuela);

            var diccionario= engine.GetDiccionarioObjetos();
            //engine.ImprimirDiccionario(diccionario,true);

            //engine.Escuela.LimpiarLugar();   
            var reporteador = new Reporteador(diccionario);
     

            reporteador.GetPromedioAlumnosxAsignatura();

            Printer.WriteTitle("Captura de una evaluación por consola");
            var newEval = new Evaluación();
            string nombre;
            float nota;
            string notatxt;
            WriteLine("Ingrese el nombre de la evaluación");
            Printer.PressEnter();
            nombre=Console.ReadLine();
            if(string.IsNullOrWhiteSpace(nombre))
            {
                Printer.WriteTitle("El valor del nombre no puede ser vacio");
            }
            else{
                newEval.Nombre= nombre.ToLower();
                WriteLine("El nombre ha sido ingresado correctamente");
            }
            WriteLine("Ingrese la nota");
            Printer.PressEnter();
            notatxt=Console.ReadLine();
            if(string.IsNullOrWhiteSpace(notatxt))
            {
                Printer.WriteTitle("El valor de la nota no puede ser vacio");
            }
            else{

                try
                {
                    newEval.Nota= float.Parse(notatxt);
                    if (newEval.Nota <0 || newEval.Nota > 5)
                    {
                        throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 5");
                    }
                    else{
                        WriteLine("La nota ha sido ingresada correctamente");

                    }
                }
                catch (ArgumentOutOfRangeException arge)
                {
                    WriteLine(arge.Message);

                }

                
                catch (Exception) {
                    Printer.WriteTitle("El valor de la nota no es un número válido");
                }

                finally
                {
                    Printer.WriteTitle("Finally");
                }

            }



            
        }

        private static void accionEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("Exiting Program ...");

        }

        private static void ImpimirCursosEscuela(Escuela escuela)
        {

            Printer.WriteTitle("Cursos de la Escuela");


            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre  }, Id  {curso.UniqueId}");
                }
            }
        }

       
    }
}
