using Microsoft.EntityFrameworkCore;
using QPH.Eval.Ej1.Core;
using QPH.Eval.Ej1.Core.Models;
using System;
using System.Collections.Generic;
using QPH.Eval.Ej1.Repository.Paging;
using System.Linq;

namespace QPH.Eval.Ej1.Repository
{
    public class LibroRepository : ILibroRepository
    {
        private readonly QPHContext LibroContext;
        private bool disposed = false;

        public LibroRepository(QPHContext libroContext)
        {
            LibroContext = libroContext;
        }

        public Libro GetLibroById(int id)
        {
            return LibroContext.Libro.Find(id);
        }



        public IEnumerable<Libro> GetLibros(int page, int pageSize, string currentFilter, bool ascOrder, 
            SortingEnum customFilter, string customFilterValue)
        {
            IQueryable<Libro> libros = LibroContext.Libro.AsQueryable();
            
            if(currentFilter != null)
            {
                libros = QueryHelper.GetQuery(libros, currentFilter, customFilter, customFilterValue, ascOrder);
            }
            

            return libros.GetPaged<Libro>(page, pageSize).Results.ToList();
        }

        public void InsertLibro(Libro libro)
        {
            LibroContext.Libro.Add(libro);
        }

        public void UpdateLibro(Libro libro)
        {
            LibroContext.Entry(libro).State = EntityState.Modified;
        }

        public void DeleteLibro(int libroId)
        {
            Libro libro = LibroContext.Libro.Find(libroId);
            LibroContext.Libro.Remove(libro);
        }

        public void Save()
        {
            LibroContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    LibroContext.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
