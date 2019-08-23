using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacion_Aboga2.Models
{
    public class ExpedienteFojas
    {

        private int _IdFojas;
        private int _IdExpediente;
        private DateTime _FechaInicio;
        private DateTime _FechaFin;
        private string _EstadoEspecifico;
        private string _Descripcion;

        public ExpedienteFojas(int IdFojas, int IdExpediente, DateTime FechaInicio, DateTime FechaFin, string EstadoEspecifico, string Descripcion)
        {
            _IdFojas = IdFojas;
            _IdExpediente = IdExpediente;
            _FechaInicio = FechaInicio;
            _FechaFin = FechaFin;
            _EstadoEspecifico = EstadoEspecifico;
            _Descripcion = Descripcion;
        }
        public ExpedienteFojas() {




        }


        public int IdFojas { get => _IdFojas; set => _IdFojas = value; }
        public int IdExpediente { get => _IdExpediente; set => _IdExpediente = value; }
        public DateTime FechaInicio { get => _FechaInicio; set => _FechaInicio = value; }
        public DateTime FechaFin { get => _FechaFin; set => _FechaFin = value; }
        public string EstadoEspecifico { get => _EstadoEspecifico; set => _EstadoEspecifico = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
    }
}