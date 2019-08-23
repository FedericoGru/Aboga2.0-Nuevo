using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Aplicacion_Aboga2.Models
{
    public class Juzgado
    {
        private int _IdJuzgado;
        private int _NumeroDeJuzgado;
        private string _Radicacion;

        public int IdJuzgado
        {
            get { return _IdJuzgado; }
            set { _IdJuzgado = value; }
        }
        public int NumeroDeJuzgado
        {
            get { return _NumeroDeJuzgado; }
            set { _NumeroDeJuzgado = value; }
        }
        public string Radicacion
        {
            get { return _Radicacion; }
            set { _Radicacion = value; }
        }
        public Juzgado(int IdJuzgado, int NumeroDeJuzgado, string Radicacion)
        {
            _IdJuzgado = IdJuzgado;
            _NumeroDeJuzgado = NumeroDeJuzgado;
            _Radicacion = Radicacion;
        }
        public Juzgado()
        {
            IdJuzgado = IdJuzgado;
            NumeroDeJuzgado = NumeroDeJuzgado;
            Radicacion = Radicacion;
        }
    }
}