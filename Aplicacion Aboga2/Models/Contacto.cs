using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacion_Aboga2.Models
{
    public class Contacto
    {
        private int _IdContacto;
        private string _Nombre;
        private string _Apellido;
        private int _NumTelefono;
        private bool _Estado;
        


        public Contacto(int IdContacto, string Nombre, string Apellido, int NumTelefono, bool Estado)
        {
            this._IdContacto = IdContacto;
            this._Nombre = Nombre;
            this._Apellido = Apellido;
            this._NumTelefono = NumTelefono;
            this._Estado = Estado;
        }

        public Contacto()
        {

        }

        public int IdContacto { get => _IdContacto; set => _IdContacto = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public int NumTelefono { get => _NumTelefono; set => _NumTelefono = value; }
        public bool Estado { get => _Estado; set => _Estado = value; }
        
    }
}
    