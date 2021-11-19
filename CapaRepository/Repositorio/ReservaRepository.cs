using CapaConexion.Models;
using CapaService.Servicio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace CapaRepository.Repositorio
{
    public class ReservaRepository : IReserva
    {
        #region Atributos
        SamtelContext samtelContext = new SamtelContext();
        private TextReader reader;
        private bool disposed = false; //Para detectar llamadas redundantes
        #endregion
        public Reserva Add(Reserva entity)
        {
            if (entity != null)
            {
                samtelContext.Reserva.Add(entity);
                samtelContext.SaveChanges();
                return entity;
            }
            else
                throw new ArgumentNullException(paramName: nameof(entity), message: "Entidad no pueden ser null algunos de los campos");

        }

        public Reserva Delete(int id)
        {
            if (id > 0)
            {
                Reserva Reserva = samtelContext.Reserva.Find(id);
                samtelContext.Reserva.Remove(Reserva);
                samtelContext.SaveChanges();
                return Reserva;
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

        public IEnumerable<Reserva> GetAll()
        {
            using (var context = new SamtelContext())
            {
                var data = context.Reserva.ToList(); // Return the list of data from the database
                return data;
            }
        }

        public Reserva GetById(int id)
        {
            Reserva Reserva = samtelContext.Reserva
               .Where(x => x.IdReserva == id)
               .FirstOrDefault();
            return Reserva;
        }

        public Reserva Modify(Reserva entity)
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
