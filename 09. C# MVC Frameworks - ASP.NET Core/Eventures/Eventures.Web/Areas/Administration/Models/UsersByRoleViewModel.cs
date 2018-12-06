using System.Collections.Generic;

namespace Eventures.Web.Areas.Administration.Models
{
    public class UsersByRoleViewModel<T>
    {
        public ICollection<T> Administrators { get; set; }

        public ICollection<T> Users { get; set; }
    }
}