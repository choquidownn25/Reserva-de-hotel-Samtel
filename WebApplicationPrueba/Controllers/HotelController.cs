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
    [Route("api/Hotel")]
    [ApiController]
    [Consumes("application/json")]
    public class HotelController : ControllerBase
    {
        /// <summary>
        /// Trae la dll de la logica de negocio
        /// </summary>
        private HotelRepository hotelRepository;
        /// <summary>
        /// Mostrar todos los Hoteles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                hotelRepository = new HotelRepository();
                //Pasamos el listado de la conexión
                IEnumerable<Hotel> Items = hotelRepository.GetAll();
                int Count = Items.Count();
                return Ok(new { Items, Count });
            }
            catch (Exception e)
            {
                return BadRequest("Error : " + e.Message.ToString());
            }
        }

        /// <summary>
        /// Consultar
        /// </summary>
        /// <param name="id">Numero</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            hotelRepository = new HotelRepository();
            var dato = hotelRepository.GetById(id);
            if (dato != null)
                return Ok(dato);
            else
                return BadRequest("Error : " + dato.ToString());
        }

        /// <summary>
        /// Agregar
        /// </summary>
        /// <param name="payload">Clase</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Hotel payload)
        {
            hotelRepository = new HotelRepository();
            Hotel hotel = payload;
            var dato = hotelRepository.Add(hotel);
            if (dato != null)
                return Ok(hotel);
            else
                return BadRequest("Error : " + hotel.ToString());
        }

        /// <summary>
        /// Modificar
        /// </summary>
        /// <param name="id">Numero</param>
        /// <param name="value">Clase</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Hotel value)
        {
            hotelRepository = new HotelRepository();
            Hotel hotel = value;
            var dato = hotelRepository.Modify(hotel);
            if (dato != null)
                return Ok(dato);
            else
                return BadRequest("Error : " + dato.ToString());
        }

        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="value"> Clase</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Hotel value)
        {
            hotelRepository = new HotelRepository();
            Hotel hotel = value;
            var dato = hotelRepository.Delete(hotel.IdHotel);
            if (dato != null)
                return Ok(hotel);
            else
                return BadRequest("Error : " + hotel.ToString());
        }
    }
}
