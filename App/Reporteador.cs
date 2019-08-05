using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;

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
            _dicionario[LlaveDiccionario.Evaluaciones];
        }
    }
}