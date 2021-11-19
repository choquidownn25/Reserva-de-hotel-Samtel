using CapaConexion.Models;
using CapaService.Servicio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaRepository.Repositorio
{
    public class UsuarioRepository : IUsuario
    {
        #region Atributos
        SamtelContext samtelContext = new SamtelContext();
        private TextReader reader;
        private bool disposed = false; //Para detectar llamadas redundantes
        #endregion
        public Usuario Add(Usuario entity)
        {
            if (entity != null)
            {
                samtelContext.Usuario.Add(entity);
                samtelContext.SaveChanges();
                return entity;
            }
            else
                throw new ArgumentNullException(paramName: nameof(entity), message: "Entidad no pueden ser null algunos de los campos");

        }

        public Usuario Delete(int id)
        {
            if (id > 0)
            {
                Usuario Usuario = samtelContext.Usuario.Find(id);
                samtelContext.Usuario.Remove(Usuario);
                samtelContext.SaveChanges();
                return Usuario;
            }
            else
                throw new ArgumentException("Debe ingresar un numero valido");
        }

        public void Dispose()
        {
            // Elimine los recursos no administrados.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (reader != null)
                    {
                        reader.Dispose();
                    }
                }

                disposed = true;
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            using (var context = new SamtelContext())
            {
                var data = context.Usuario.ToList(); // Return the list of data from the database
                return data;
            }
        }

        public Usuario GetById(int id)
        {
            Usuario usuario = samtelContext.Usuario
               .Where(x => x.IdUsuario == id)
               .FirstOrDefault();
            return usuario;
        }

        public Usuario Modify(Usuario entity)
        {
            if (entity != null)
            {
                samtelContext.Entry(entity).State = EntityState.Modified;
                samtelContext.SaveChanges();
                return entity;
            }
            else
                throw new ArgumentNullException(paramName: nameof(entity), message: "Entidad no pueden ser null algunos de los campos");
        }
    }
}
