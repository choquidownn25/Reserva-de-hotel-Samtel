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
    public class HotelRepository : IHotel
    {
        #region Atributos
        SamtelContext samtelContext = new SamtelContext();
        private TextReader reader;
        private bool disposed = false; //Para detectar llamadas redundantes
        #endregion
        public Hotel Add(Hotel entity)
        {
            if (entity != null)
            {
                samtelContext.Hotel.Add(entity);
                samtelContext.SaveChanges();
                return entity;
            }
            else
                throw new ArgumentNullException(paramName: nameof(entity), message: "Entidad no pueden ser null algunos de los campos");

        }

        public Hotel Delete(int id)
        {
            if (id > 0)
            {
                Hotel Hotel = samtelContext.Hotel.Find(id);
                samtelContext.Hotel.Remove(Hotel);
                samtelContext.SaveChanges();
                return Hotel;
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

        public IEnumerable<Hotel> GetAll()
        {
            using (var context = new SamtelContext())
            {
                var data = context.Hotel.ToList(); // Return the list of data from the database
                return data;
            }
        }

        public Hotel GetById(int id)
        {
            Hotel brands = samtelContext.Hotel
               .Where(x => x.IdHotel == id)
               .FirstOrDefault();
            return brands;
        }

        public Hotel Modify(Hotel entity)
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
