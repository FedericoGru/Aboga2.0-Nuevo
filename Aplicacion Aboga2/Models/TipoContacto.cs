using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacion_Aboga2.Models
{
    public class TipoContacto
    {
        private int _IdTipoContacto;
        private string _Descripcion;

        public TipoContacto(int IdTipoContacto, string Descripcion)
        {
            _IdTipoContacto = IdTipoContacto;
            _Descripcion = Descripcion;
        }

        public int IdTipoContacto { get => _IdTipoContacto; set => _IdTipoContacto = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
    }
}