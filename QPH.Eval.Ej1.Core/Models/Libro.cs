using System;

namespace QPH.Eval.Ej1.Core.Models
{
    public class Libro
    {
        public int LibroId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Autor { get; set; }
        public DateTime FechaDePublicacion { get; set; }
        public int NumeroDeEjemplares { get; set; }
        public double Costo { get; set; }

    }
}
