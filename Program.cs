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
