using Microsoft.EntityFrameworkCore;
using QPH.Eval.Ej1.Core;
using QPH.Eval.Ej1.Core.Models;
using System.Linq;
using System.Reflection;

namespace QPH.Eval.Ej1.Repository
{
    public static class QueryHelper
    {
        public static IQueryable<Libro> GetQuery(IQueryable<Libro> libros, string currentFilter, SortingEnum customFilter, string customFilterValue, bool ascOrder)
        {
            PropertyInfo prop = typeof(Libro).GetProperty(currentFilter);

            if (customFilter == SortingEnum.None)
            {
                if (ascOrder)
                {
                    libros = libros.OrderBy(t => EF.Property<string>(t, currentFilter));
                }
                else
                {
                    libros = libros.OrderByDescending(t => EF.Property<string>(t, currentFilter));
                }
            }
            else
            {
                switch (customFilter)
                {
                    case SortingEnum.Contains:
                        libros = libros.Where(t => EF.Property<string>(t, currentFilter).ToString().Contains(customFilterValue));
                        break;
                    case SortingEnum.NotContains:
                        libros = libros.Where(t => !EF.Property<string>(t, currentFilter).ToString().Contains(customFilterValue));
                        break;
                    case SortingEnum.Equals:
                        libros = libros.Where(t => EF.Property<string>(t, currentFilter).ToString() == customFilterValue);
                        break;
                    case SortingEnum.NotEqual:
                        libros = libros.Where(t => EF.Property<string>(t, currentFilter).ToString() != customFilterValue);
                        break;
                    case SortingEnum.StartsWith:
                        libros = libros.Where(t => EF.Property<string>(t, currentFilter).ToString().StartsWith(customFilterValue));
                        break;
                    case SortingEnum.EndsWith:
                        libros = libros.Where(t => EF.Property<string>(t, currentFilter).ToString().EndsWith(customFilterValue));
                        break;

                }
            }
            return libros;
        }
    }
}
