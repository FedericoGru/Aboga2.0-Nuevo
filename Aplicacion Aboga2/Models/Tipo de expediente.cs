using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Aplicacion_Aboga2.Models
{
    public class Tipo_de_expediente
    {
        private int _IdTipoDeExpediente;
        private string _TipoDeExpediente;

        public int IdTipoDeExpediente
        {
            get { return _IdTipoDeExpediente; }
            set { _IdTipoDeExpediente = value; }
        }
        public string TipoDeExpediente
        {
            get { return _TipoDeExpediente; }
            set { _TipoDeExpediente = value; }
        }
        public Tipo_de_expediente(int IdTipoDeExpediente, string TipoDeExpediente)
        {
            _IdTipoDeExpediente = IdTipoDeExpediente;
            _TipoDeExpediente = TipoDeExpediente;
        }
        public Tipo_de_expediente()
        {
            IdTipoDeExpediente = IdTipoDeExpediente;
            TipoDeExpediente = TipoDeExpediente;
        }
    }
}