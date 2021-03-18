using Repository.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Shared
{
    public interface IRepositoryShared
    {
        public bool CheckCredentials(string UserId, string Password);
        public bool CreateToDo(string UserId, string ToDo);
        public bool DeleteToDo(int Id);
        public List<UserTodosRepo> GetTodayToDos(string UserId);
        public List<UserTodosRepo> GetPreviousToDos(string UserId);
        public List<UserTodosRepo> GetComingToDos(string UserId);

        public bool UpdateToDo(int Id, string NewToDo);
        public bool MarkToDo(int Id);
        public bool UnmarkToDo(int id);
    }
}
