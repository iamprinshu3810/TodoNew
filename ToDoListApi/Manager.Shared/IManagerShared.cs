using Manager.Shared.Dto;
using Repository.Implementation.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Shared
{
    public interface IManagerShared
    {
        public bool CheckCredentials(string UserId, string Password);
        public bool CreateToDo(string UserId, string ToDo);
        public bool DeleteToDo( int Id);
        public List<ToDosManager> GetTodayToDos(string UserId);
        public List<ToDosManager> GetPreviousToDos(string UserId);
        public List<ToDosManager> GetComingToDos(string UserId);

        public bool UpdateToDo(int Id,string NewToDo);
        public bool MarkToDo(int Id);
        public bool UnmarkToDo(int id);
    }
}
