using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using System.Linq;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        private Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _dicionario{ get; set; }
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dic)        
        {

            if (dic==null)
            {
                throw new ArgumentNullException( nameof(dic));
            }
            else{
                    _dicionario=dic;

            }
        }

        public IEnumerable<Evaluación> GetListaEvaluacion()
        {
          
            if (_dicionario.TryGetValue(LlaveDiccionario.Evaluaciones, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluación>();
            }
            else
            {
                return null;
            }
      
        }

        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluación> listaEvaluaciones )
        {
            listaEvaluaciones = GetListaEvaluacion();
            return (from ev in listaEvaluaciones                   
                    select ev.Asignatura.Nombre).Distinct();
        }

        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dummy);
        }

        public Dictionary<string, IEnumerable<Evaluación>> GetListaEvaluacionxAsignatura()
        {
            var dic = new Dictionary<string, IEnumerable<Evaluación>> ();
            var listaAsignaturas = GetListaAsignaturas( out var listaEvaluaciones);

            foreach(var a in listaAsignaturas)
            {
                var listaEvalporAsignatura = from ev in listaEvaluaciones
                                            where ev.Asignatura.Nombre == a
                                            select ev;
                dic.Add(a,listaEvalporAsignatura);
            }


            return dic;
        }
    }
}