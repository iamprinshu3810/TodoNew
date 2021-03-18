using Manager.Shared;
using Repository.Shared;
using Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using Repository.Shared.Dto;
using Manager.Shared.Dto;

namespace Manager.Implementation
{
    public class ManagerImplementation:IManagerShared
    {
        IRepositoryShared _repository;
        public ManagerImplementation(IRepositoryShared repository)
        {
            _repository = repository;
        }
        public bool CheckCredentials( string UserId, string Password)
        {
            bool isAuthorised = _repository.CheckCredentials(UserId, Password);
            return isAuthorised;
        }
        public bool CreateToDo(string UserId, string ToDo)
        {
            bool isCreated = _repository.CreateToDo(UserId, ToDo);
            return isCreated;
        }
        public bool DeleteToDo(int Id)
        {
            bool isDeleted = _repository.DeleteToDo(Id);
            return isDeleted;
        }
        public List<ToDosManager> GetTodayToDos(string UserId)
        {
            List<ToDosManager>rtoDo  = new List<ToDosManager>();
            List<UserTodosRepo> toDos = _repository.GetTodayToDos(UserId);
            foreach(var t in toDos)
            {
                rtoDo.Add(new ToDosManager()
                {
                    toDo=t.toDo,
                    status=t.status,
                     id = t.id
                });
            }
            return rtoDo;
        }
        public List<ToDosManager> GetPreviousToDos(string UserId)
        {
            List<ToDosManager> rtoDo = new List<ToDosManager>();
            List<UserTodosRepo> toDos = _repository.GetPreviousToDos(UserId);
            foreach (var t in toDos)
            {
                rtoDo.Add(new ToDosManager()
                {
                    toDo = t.toDo,
                    status = t.status,
                    id = t.id
                });
            }
            return rtoDo;
        }
        public List<ToDosManager> GetComingToDos(string UserId)
        {
            List<ToDosManager> rtoDo = new List<ToDosManager>();
            List<UserTodosRepo> toDos = _repository.GetComingToDos(UserId);
            foreach (var t in toDos)
            {
                rtoDo.Add(new ToDosManager()
                {
                    toDo = t.toDo,
                    status = t.status,
                    id = t.id
                });
            }
            return rtoDo;
        }
        public bool UpdateToDo(int Id, string NewToDo)
        {
           bool isUpdated = _repository.UpdateToDo(Id, NewToDo);
            return isUpdated;
        }
        public bool MarkToDo(int Id)
        {
            bool isMarked = _repository.MarkToDo(Id);
            return isMarked;
        }
        public bool UnmarkToDo(int id)
        {
            bool isMarked = _repository.UnmarkToDo(id);
            return isMarked;
        }
    }
}
