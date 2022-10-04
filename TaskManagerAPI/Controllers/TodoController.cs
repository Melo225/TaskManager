using TaskManagerAPI.Services;
using TaskManagerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using TaskManagerAPI.IdentityAuth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TodoController: ControllerBase
    {
        
        private readonly TodoService _todoService;
        private readonly ITodoList<Todo> _Todo;

        public TodoController(ITodoList<Todo> Todo, TodoService TodoService)
        {
            _todoService = TodoService;
            _Todo = Todo;

        }


        //Create Task

        [HttpPost("CreateTask")]
        public async Task<Object> CreateTask([FromBody] Todo todo)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {

                await _todoService.CreateTask(todo);
                return true;

            }
            /* try
             {
                 await _todoService.CreateTask(todo);
                 return true;
             }
             catch (Exception)
             {

                 return false;
             }*/

            return false;
        }

        //Delete task  
        [HttpDelete("DeleteTask")]
        public bool DeleteTask(int TaskId)
        {
            try
            {
                _todoService.DeleteTask(TaskId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Update Task  
        [HttpPut("UpdateTask")]
        public bool UpdateTask(Todo Object)
        {
            try
            {
                _todoService.UpdateTask(Object);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //GET All Task by Id  
        [HttpGet("GetAllTaskById")]
        public Object GetAllTaskById(int TaskId)
        {
            var data = _todoService.GetTaskById(TaskId);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //GET All Task  
        [HttpGet("GetAllTasks")]
        public Object GetAllTasks()
        {
           // var identity = HttpContext.User.Identity as ClaimsIdentity;

            var data = _todoService.GetAllTasks();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

    }
}

