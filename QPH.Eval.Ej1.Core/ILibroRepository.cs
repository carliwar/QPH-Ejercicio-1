using QPH.Eval.Ej1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QPH.Eval.Ej1.Core
{
    public interface ILibroRepository: IDisposable
    {
        Libro GetLibroById(int libroId);
        IEnumerable<Libro> GetLibros(int page, int pageSize, string currentFilter, bool ascOrder,
            SortingEnum customFilter, string customFilterValue);
        void InsertLibro(Libro libro);
        void DeleteLibro(int libroId);
        void UpdateLibro(Libro libro);
        void Save();
    }
}
