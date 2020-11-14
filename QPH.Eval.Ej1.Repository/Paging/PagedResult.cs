using System;
using System.Collections.Generic;
using System.Text;

namespace QPH.Eval.Ej1.Repository.Paging
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}
