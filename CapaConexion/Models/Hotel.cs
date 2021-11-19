using System;
using System.Collections.Generic;

namespace CapaConexion.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int IdHotel { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Logitud { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int NumeroHabitacion { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
