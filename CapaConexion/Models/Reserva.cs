using System;
using System.Collections.Generic;

namespace CapaConexion.Models
{
    public partial class Reserva
    {
        public int IdReserva { get; set; }
        public int IdUsuario { get; set; }
        public int IdHabitacion { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public bool Estado { get; set; }
        public int IdHotel { get; set; }

        public virtual Hotel IdHotelNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
