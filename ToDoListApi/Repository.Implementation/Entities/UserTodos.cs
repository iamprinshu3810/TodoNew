using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementation.Entities
{
    public partial class UserTodos
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ToDo { get; set; }
        public DateTime DateCreated { get; set; }
        public int StatusId { get; set; }

        public virtual StatusTable Status { get; set; }
        public virtual UserTable User { get; set; }
    }
}
