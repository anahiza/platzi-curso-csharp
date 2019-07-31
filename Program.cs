using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            //Printer.Beep(10000, cantidad: 10);
            ImpimirCursosEscuela(engine.Escuela);
            Printer.DrawLine(20);
            Printer.WriteTitle("Pruebas de poliformisfo");
            var alumnoTest = new Alumno();
            alumnoTest.Nombre="Claire UnderWood";

            ObjetoEscuelaBase ob = alumnoTest;
            Printer.WriteTitle("Alumno");
            WriteLine($"Alumno: {alumnoTest.UniqueId}");
             WriteLine($"Alumno: {alumnoTest.GetType()}");
            Printer.WriteTitle("Objeto Escuela");
            WriteLine($"Objeto: {ob.UniqueId.ToString()}");
             WriteLine($"Objeto: {ob.GetType()}");

            var eval = new Evaluación(){Nombre="Matematicas", Nota=4.5f};
       Printer.WriteTitle("Evaluacion");
            WriteLine($"Evaluacion: {eval.UniqueId.ToString()}");
             WriteLine($"Evaluacion: {eval.Nota}");
             WriteLine($"Evaluacion: {eval.GetType()}");

             ob=eval;
                         Printer.WriteTitle("Objeto Escuela");
            WriteLine($"Objeto: {ob.UniqueId.ToString()}");
             WriteLine($"Objeto: {ob.GetType()}");




            var listaObjetos = engine.GetObjetosEscuela();
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
