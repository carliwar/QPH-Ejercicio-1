using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QPH.Eval.Ej1._REST.Models
{
    public class LibroCreateRequest
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Autor { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public DateTime FechaDePublicacion { get; set; }
        [Required]
        public int NumeroDeEjemplares { get; set; }
        [Required]
        public double Costo { get; set; }

    }
}
