using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Repository.Implementation.Entities
{
    public partial class UserTable
    {
        public UserTable()
        {
            UserTodos = new HashSet<UserTodos>();
        }

        public string Id { get; set; }
        public string Psw { get; set; }

        public virtual ICollection<UserTodos> UserTodos { get; set; }
    }
}
