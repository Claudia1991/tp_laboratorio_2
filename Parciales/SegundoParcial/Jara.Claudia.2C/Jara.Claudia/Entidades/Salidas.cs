using System;

namespace Entidades
{
    public class Salidas
    {
        private DateTime fechaFin;
        private DateTime fechaInicio;

        public DateTime FechaFin { get => this.fechaFin; set => this.fechaFin = value; }
        public DateTime FechaInicio { get => this.fechaInicio; set => this.fechaInicio = value; }
        public int TiempoTotal { get => FechaInicio.DiferenciaEnMinutos(FechaFin); }

        public Salidas()
        {
            FechaInicio = DateTime.Now;
        }
        public void FinalizarSalida()
        {
            FechaFin = DateTime.Now;
        }
    }
}
