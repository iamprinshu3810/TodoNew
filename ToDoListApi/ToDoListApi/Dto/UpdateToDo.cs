using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListApi.Dto
{
    public class UpdateToDo
    {
        public int id { get; set; }
        public string newToDo { get; set; }
    }
}
