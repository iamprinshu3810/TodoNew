using Manager.Implementation;
using Manager.Shared;
using Manager.Shared.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApi.Dto;

namespace ToDoListApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        IManagerShared _manager;
        public UserController(IManagerShared manager)
        {
            _manager = manager;
        }
      
        [HttpPost("CreateToDo")]
        public bool CreateToDo([FromBody]CreateToDo c)
        {
            bool isCreated = _manager.CreateToDo(c.userId, c.toDo);
            return isCreated;
        }
        [HttpPost("DeleteToDo")]
        public bool DeleteToDo([FromBody]DeleteToDo d)
        {
            bool isDeleted = _manager.DeleteToDo( d.id);
            return isDeleted;
        }
        [HttpPost("GetTodayToDos")]
        public List<ToDos> GetTodayToDos([FromBody] GetTodo g)
        {
            List<ToDos> toDo = new List<ToDos>();
            List<ToDosManager> toDoManager = _manager.GetTodayToDos(g.userId);
            foreach(var t in toDoManager )
            {
                toDo.Add(new ToDos()
                {
                    toDo = t.toDo,
                    status = t.status,
                    id = t.id
                });
            }
            return toDo;
        }
        [HttpPost("GetPreviousToDos")]
        public List<ToDos> GetPreviousToDos([FromBody] GetTodo g)
        {
            List<ToDos> toDo = new List<ToDos>();
            List<ToDosManager> toDoManager = _manager.GetPreviousToDos(g.userId);
            foreach (var t in toDoManager)
            {
                toDo.Add(new ToDos()
                {
                    toDo = t.toDo,
                    status = t.status,
                    id = t.id
                });
            }
            return toDo;
        }
        [HttpPost("GetComingToDos")]
        public List<ToDos> GetComingToDos([FromBody] GetTodo g)
        {
            List<ToDos> toDo = new List<ToDos>();
            List<ToDosManager> toDoManager = _manager.GetComingToDos(g.userId);
            foreach (var t in toDoManager)
            {
                toDo.Add(new ToDos()
                {
                    toDo = t.toDo,
                    status = t.status,
                    id = t.id
                });
            }
            return toDo;
        }
        [HttpPost("UpdateToDo")]
        public bool UpdateToDo([FromBody] UpdateToDo u)
        {
            bool isUpdated = _manager.UpdateToDo(u.id,u.newToDo);
            return isUpdated;
        }
        [HttpPost("MarkToDo")]
        public bool MarkToDo([FromBody]ChangeToDoState m)
        {
            bool isMarked = _manager.MarkToDo(m.id);
            return isMarked;
        }
        [HttpPost("UnmarkToDo")]
        public bool UnmarkToDo([FromBody]ChangeToDoState s)
        {
            bool isMarked = _manager.UnmarkToDo(s.id);
            return isMarked;
        }
    }
}
