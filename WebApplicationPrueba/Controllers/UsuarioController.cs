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
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Trae la dll de la logica de negocio
        /// </summary>
        private UsuarioRepository UsuarioRepository;
        /// <summary>
        /// Muestra todos los usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                UsuarioRepository = new UsuarioRepository();
                //Pasamos el listado de la conexión
                IEnumerable<Usuario> Items = UsuarioRepository.GetAll();
                int Count = Items.Count();
                return Ok(new { Items, Count });
            }
            catch (Exception e)
            {
                return BadRequest("Error : " + e.Message.ToString());
            }
        }

        /// <summary>
        /// Busquerda por usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            UsuarioRepository = new UsuarioRepository();
            var dato = UsuarioRepository.GetById(id);
            if (dato != null)
                return Ok(dato);
            else
                return BadRequest("Error : " + dato.ToString());
        }

        /// <summary>
        /// Agregar Usuario
        /// </summary>
        /// <param name="payload"> Clase</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Usuario payload)
        {
            UsuarioRepository = new UsuarioRepository();
            Usuario Usuario = payload;
            var dato = UsuarioRepository.Add(Usuario);
            if (dato != null)
                return Ok(Usuario);
            else
                return BadRequest("Error : " + Usuario.ToString());
        }
        /// <summary>
        /// Modificar usuario
        /// </summary>
        /// <param name="id">Numero</param>
        /// <param name="value">Clase</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario value)
        {
            UsuarioRepository = new UsuarioRepository();
            Usuario Usuario = value;
            var dato = UsuarioRepository.Modify(Usuario);
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
        public IActionResult Delete(Usuario value)
        {
            UsuarioRepository = new UsuarioRepository();
            Usuario Usuario = value;
            var dato = UsuarioRepository.Delete(Usuario.IdUsuario);
            if (dato != null)
                return Ok(Usuario);
            else
                return BadRequest("Error : " + Usuario.ToString());
        }
    }
}
