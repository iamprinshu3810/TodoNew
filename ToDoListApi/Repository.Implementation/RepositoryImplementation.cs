using Repository.Implementation.Entities;
using Repository.Shared;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Repository.Shared.Dto;

namespace Repository.Implementation
{
    public class RepositoryImplementation:IRepositoryShared
    {
        ToDoListContext context = new ToDoListContext();
        public bool CheckCredentials(string UserId, string Password)
        {
            bool isAuthorised = false;
            try
            {
                using(context)
                {
                    var query = from u in context.UserTable
                                where u.Id ==UserId && u.Psw == Password
                                select u;
                    var user = query.ToList();
                    if (user.Count > 0)
                    {
                        isAuthorised = true;
                    }
                    context.SaveChanges();
                }
                return isAuthorised;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool CreateToDo(string UserId, string ToDo)
        {
            try
            {
                using (context)
                {
                    context.UserTodos.Add(new UserTodos()
                    {
                        UserId = UserId,
                        ToDo = ToDo,
                        DateCreated = DateTime.Today,
                        StatusId = 2
                    });
                    context.SaveChanges();
                }
                return true;
            }

            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteToDo( int Id)
        {
            try
            {
                using (context)
                {
                    var todoToRemove = context.UserTodos.First(a => a.Id==Id);
                    context.UserTodos.Remove(todoToRemove);
                    context.SaveChanges();
                }
                return true;
            }

            catch (Exception e)
            {
                return false;
            }
        }
        public List<UserTodosRepo> GetTodayToDos(string UserId)
        {
            List<UserTodosRepo> toDos = new List<UserTodosRepo>();
            try
            {
                using (context)
                {
                    var query = from u in context.UserTable
                                join t in context.UserTodos on u.Id equals t.UserId
                                join s in context.StatusTable on t.StatusId equals s.Id
                                where t.DateCreated == DateTime.Today
                                select new UserTodosRepo()
                                {
                                    toDo=t.ToDo,
                                    status=s.Status,
                                    id = t.Id
                                };
                     toDos = query.ToList();
                    context.SaveChanges();
                }
                return toDos;
            }

            catch (Exception e)
            {
                return toDos;
            }
        }
        public List<UserTodosRepo> GetPreviousToDos(string UserId)
        {
            List<UserTodosRepo> toDos = new List<UserTodosRepo>();
            try
            {
                using (context)
                {
                    var query = from u in context.UserTable
                                join t in context.UserTodos on u.Id equals t.UserId
                                join s in context.StatusTable on t.StatusId equals s.Id
                                where t.DateCreated < DateTime.Today
                                select new UserTodosRepo()
                                {
                                    toDo = t.ToDo,
                                    status = s.Status,
                                    id=t.Id
                                };
                    toDos = query.ToList();
                    context.SaveChanges();
                }
                return toDos;
            }

            catch (Exception e)
            {
                return toDos;
            }
        }
        public List<UserTodosRepo> GetComingToDos(string UserId)
        {
            List<UserTodosRepo> toDos = new List<UserTodosRepo>();
            try
            {
                using (context)
                {
                    var query = from u in context.UserTable
                                join t in context.UserTodos on u.Id equals t.UserId
                                join s in context.StatusTable on t.StatusId equals s.Id
                                where t.DateCreated > DateTime.Today
                                select new UserTodosRepo()
                                {
                                    toDo = t.ToDo,
                                    status = s.Status,
                                    id=t.Id
                                };
                    toDos = query.ToList();
                    context.SaveChanges();
                }
                return toDos;
            }

            catch (Exception e)
            {
                return toDos;
            }
        }
        public bool UpdateToDo(int Id, string NewToDo)
        {
            try
            {
                using(context)
                {
                    var toDo = context.UserTodos.First(a => a.Id==Id);
                    toDo.ToDo = NewToDo;
                    context.SaveChanges();

                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public bool MarkToDo(int Id)
        {
            try
            {
                using (context)
                {
                    var toDo = context.UserTodos.First(a => a.Id==Id);
                    toDo.StatusId = 1;
                    context.SaveChanges();

                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public bool UnmarkToDo(int Id)
        {
            try
            {
                using (context)
                {
                    var toDo = context.UserTodos.First(a => a.Id == Id);
                    toDo.StatusId = 2;
                    context.SaveChanges();

                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
