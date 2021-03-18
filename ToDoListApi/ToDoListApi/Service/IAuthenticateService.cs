using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApi.Dto;

namespace ToDoListApi.Service
{
    public interface IAuthenticateService
    {
        UserCredentials Authenticate(string UserId, string Password);
    }
}
