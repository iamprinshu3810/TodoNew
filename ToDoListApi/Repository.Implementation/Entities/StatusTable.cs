using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Repository.Implementation.Entities
{
    public partial class StatusTable
    {
        public StatusTable()
        {
            UserTodos = new HashSet<UserTodos>();
        }

        public int Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<UserTodos> UserTodos { get; set; }
    }
}
