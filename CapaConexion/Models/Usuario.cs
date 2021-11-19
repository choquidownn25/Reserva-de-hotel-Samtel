using System;
using System.Collections.Generic;

namespace CapaConexion.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Mail { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
