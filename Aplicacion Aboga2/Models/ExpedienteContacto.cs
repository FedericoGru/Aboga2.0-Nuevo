using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacion_Aboga2.Models
{
    public class ExpedienteContacto
    {
        private int _IdContacto;
        private int _IdExpedienteContacto;
        private int _IdExpediente;
        private int _IdTipoContacto;

        public int IdContacto
        {
            get { return _IdContacto; }
            set { _IdContacto = value; }
        }
        public int IdExpedienteContacto
        {
            get { return _IdExpedienteContacto; }
            set { _IdExpedienteContacto = value; }
        }
        public int IdExpediente
        {
            get { return _IdExpediente; }
            set { _IdExpediente = value; }
        }
        public int IdTipoContacto
        {
            get { return _IdTipoContacto; }
            set { _IdTipoContacto = value; }
        }
        public ExpedienteContacto(int IdContacto, int IdExpedienteContacto, int IdExpediente, int IdTipoContacto)
        {
            _IdContacto = IdContacto;
            _IdExpedienteContacto = IdExpedienteContacto;
            _IdExpediente = IdExpediente;
            _IdTipoContacto = IdTipoContacto;
        }
        public ExpedienteContacto()
        {

        }
    }
}