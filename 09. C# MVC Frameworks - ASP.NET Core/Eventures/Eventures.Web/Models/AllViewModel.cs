using System.Collections.Generic;

namespace Eventures.Web.Models
{
    public class AllViewModel<T>
    {
        public int PageSize { get; set; } = 3;

        public int Page { get; set; } = 1;

        public int TotalPages { get; set; }

        public bool HasPreviousPage => this.Page > 1;

        public bool HasNextPage => this.Page < this.TotalPages;

        public string Author { get; set; }

        public ICollection<T> Entities { get; set; }
    }
}