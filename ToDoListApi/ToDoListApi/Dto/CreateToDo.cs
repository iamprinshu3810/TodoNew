using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListApi.Dto
{
    public class CreateToDo
    {
        public string userId { get; set; }
        public string toDo { get; set; }
    }
}
