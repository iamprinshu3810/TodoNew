using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListApi.Dto
{
    public class UserCredentials
    {
        public string userId { get; set; }
        public string password { get; set; }
        public string token { get; set; }
    }
}
