using QPH.Eval.Ej1.Core;
using QPH.Eval.Ej1.Core.Models;
using System;
using System.Collections.Generic;

namespace QPH.Eval.Ej1.Business
{
    public class LibrosBusiness
    {
        private readonly ILibroRepository LibroRepository;

        public LibrosBusiness(ILibroRepository libroRepository)
        {
            LibroRepository = libroRepository;
        }

        #region Métodos CRUD
        public List<Libro> GetLibros(int page, string filter, bool? asc, SortingEnum customFilter, string customFilterValue)
        {
            page = page < 1 ? 1 : page;
            filter ??= "Nombre";
            asc = !asc.HasValue;

            return (List<Libro>)LibroRepository.GetLibros(page, 5, filter, asc.Value, customFilter, customFilterValue);
        }

        public LibroPostResult CreateLibro(Libro libro)
        {
            var librosPostResult = new LibroPostResult();

            ValidarLibro(libro, librosPostResult);

            LibroRepository.InsertLibro(libro);
            LibroRepository.Save();

            return librosPostResult;
        }

        public LibroPostResult UpdateLibro(Libro libro)
        {
            var librosPostResult = new LibroPostResult();

            ValidarLibro(libro, librosPostResult);

            LibroRepository.UpdateLibro(libro);
            LibroRepository.Save();

            return librosPostResult;
        }

        public void DeleteLibro(int libroId)
        {
            LibroRepository.DeleteLibro(libroId);
            LibroRepository.Save();
        }
        #endregion

        #region Validaciones
        private static void ValidarLibro(Libro libro, LibroPostResult librosPostResult)
        {
            if (libro.Nombre.Length > 150)
            {
                librosPostResult.Errors.Add("Nombre", "El nombre del libro no permite más de 150 caracteres.");
            }
            if (libro.Descripcion.Length > 300)
            {
                librosPostResult.Errors.Add("Descripción", "La descripción no permite más de 300 caracteres.");
            }
            if (libro.Autor.Length > 150)
            {
                librosPostResult.Errors.Add("Autor", "El autor no permite más de 150 caracteres.");
            }

            double antiguedadLibro = (DateTime.UtcNow.Date - libro.FechaDePublicacion.Date).TotalDays / 365;

            if (antiguedadLibro > 10)
            {
                librosPostResult.Errors.Add("Fecha De Publicación", "No se puede ingresar un libro con más de 10 años de publicación.");
            }
        } 
        #endregion
    }
}
