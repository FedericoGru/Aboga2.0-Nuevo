using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Aplicacion_Aboga2.Models
{
    public class Expediente
    {
        private int _IdExpediente;
        private int _IdTipoExpediente;
        private string _Descripcion;
        private int _IdJuzgadoExpediente;
        private int _NumeroExpediente;
        private int _Estado;
        private string _Caratula;
    

        public int IdExpediente
        {
            get { return _IdExpediente; }
            set { _IdExpediente = value; }
        }
        public int IdTipoExpediente
        {
            get { return _IdTipoExpediente; }
            set { _IdTipoExpediente = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        public int IdJuzgadoExpediente
        {
            get { return _IdJuzgadoExpediente; }
            set { _IdJuzgadoExpediente = value; }
        }
        public int NumeroExpediente
        {
            get { return _NumeroExpediente; }
            set { _NumeroExpediente = value; }
        }
        public int Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        public string Caratula
        {
            get { return _Caratula; }
            set { _Caratula = value; }
        }

        public Expediente(int IdExpediente, int IdTipoExpediente, string Descripcion, int IdJuzgadoExpediente, int NumeroExpediente,int Estado, string Caratula)
        {
            _IdExpediente = IdExpediente;
            _IdTipoExpediente = IdTipoExpediente;
            _Descripcion = Descripcion;
            _IdJuzgadoExpediente = IdJuzgadoExpediente;
            _NumeroExpediente = NumeroExpediente;
            _Estado = Estado;
            _Caratula = Caratula;
        }
        public Expediente()
        { 

        }
    }
}