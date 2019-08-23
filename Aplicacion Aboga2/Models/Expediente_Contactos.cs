using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacion_Aboga2.Models
{
    public class Expediente_Contactos
    {
        private int _IdExpedienteContacto;
        private int _IdExpediente;
        private int _Id_Contacto;
        private int _IdTipoContacto;

        public Expediente_Contactos(int IdExpedienteContacto, int IdExpediente, int Id_Contacto, int IdTipoContacto)
        {
            _IdExpedienteContacto = IdExpedienteContacto;
            _IdExpediente = IdExpediente;
            _Id_Contacto = Id_Contacto;
            _IdTipoContacto = IdTipoContacto;
        }

        public int IdExpedienteContacto { get => _IdExpedienteContacto; set => _IdExpedienteContacto = value; }
        public int IdExpediente { get => _IdExpediente; set => _IdExpediente = value; }
        public int Id_Contacto { get => _Id_Contacto; set => _Id_Contacto = value; }
        public int IdTipoContacto { get => _IdTipoContacto; set => _IdTipoContacto = value; }
    }
}