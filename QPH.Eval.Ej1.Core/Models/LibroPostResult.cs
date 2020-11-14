using System.Collections.Generic;
using System.Linq;

namespace QPH.Eval.Ej1.Business
{
    public class LibroPostResult
    {
        public LibroPostResult()
        {
            Errors = new Dictionary<string, string>();
        }
        public Dictionary<string, string> Errors { get; set; }
        public bool Success
        {
            get
            {
                return Errors.Count() == 0;
            }
        }
    }
}