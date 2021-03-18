using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApi.Dto;
using ToDoListApi.Service;

namespace ToDoListApi.Controllers
{
    
    [Route("[Controller]")]
    [ApiController]

    public class AuthenticationController : Controller
    {
        IAuthenticateService _authenticateService;
        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        [HttpPost]
        public IActionResult Post([FromBody] UserCredentials Model)
        {
            var user = _authenticateService.Authenticate(Model.userId, Model.password);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }
    }
}
