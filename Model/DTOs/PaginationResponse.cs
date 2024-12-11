using System.Collections.Generic;

namespace Estore.Model.DTOs
{
    public class PaginationResponse<T>
    {
        public int pageindex { get; set; }
        public int pagesize { get; set; }
        public int count { get; set; }
        public IEnumerable<T> data { get; set; }

    }
}
