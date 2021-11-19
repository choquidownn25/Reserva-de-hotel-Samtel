using CapaConexion.Models;
using CapaRepository.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationPrueba.Controllers
{
    [Route("api/Reserva")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        /// <summary>
        /// Trae la dll de la logica de negocio
        /// </summary>
        private ReservaRepository ReservaRepository;
        // GET: api/<ReservaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                ReservaRepository = new ReservaRepository();
                //Pasamos el listado de la conexión
                IEnumerable<Reserva> Items = ReservaRepository.GetAll();
                int Count = Items.Count();
                return Ok(new { Items, Count });
            }
            catch (Exception e)
            {
                return BadRequest("Error : " + e.Message.ToString());
            }
        }

        // GET api/<ReservaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ReservaRepository = new ReservaRepository();
            var dato = ReservaRepository.GetById(id);
            if (dato != null)
                return Ok(dato);
            else
                return BadRequest("Error : " + dato.ToString());
        }

        /// <summary>
        /// Se guardan las reservas del hotel
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Reserva payload)
        {
            ReservaRepository = new ReservaRepository();
            Reserva Reserva = payload;
            if (payload.IdHabitacion <= 1)
            {
                var dato = ReservaRepository.Add(Reserva);
                if (dato != null)
                    return Ok(Reserva);
                else
                    return BadRequest("Error : " + Reserva.ToString());
            }
            else
            {
                return Ok("Cordial Saludo estiamdo cliente, solo requiere reservar una habitación");
            }
            
        }

        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="id"> Numero</param>
        /// <param name="value">Clase Reserva</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Reserva value)
        {
            ReservaRepository = new ReservaRepository();
            Reserva Reserva = value;
            var dato = ReservaRepository.Modify(Reserva);
            if (dato != null)
                return Ok(dato);
            else
                return BadRequest("Error : " + dato.ToString());
        }

        // DELETE api/<ReservaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Reserva value)
        {
            ReservaRepository = new ReservaRepository();
            Reserva Reserva = value;
            var dato = ReservaRepository.Delete(Reserva.IdReserva);
            if (dato != null)
                return Ok(Reserva);
            else
                return BadRequest("Error : " + Reserva.ToString());
        }
    }
}
