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

        public IEnumerable<Escuela> GetListaEvaluacion()
        {
            IEnumerable<Escuela>  res;
            if (_dicionario.TryGetValue(LlaveDiccionario.Escuela, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                res = lista.Cast<Escuela>();
            }
            else
            {
                res=null;
            }
            return res;
        }
    }
}