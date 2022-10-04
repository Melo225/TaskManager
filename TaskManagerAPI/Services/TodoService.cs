using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerAPI.Models;


namespace TaskManagerAPI.Services
{
    public class TodoService
    {
        private readonly ITodoList<Todo> _todo;

        public TodoService(ITodoList<Todo> todo)
        {
            _todo = todo;
        }


        // Get Tasks Details By Task Id  
        public IEnumerable<Todo> GetTaskById(int TaskId)
        {
            return _todo.GetAll().Where(x => x.id == TaskId).ToList();
        }

        //GET All Task Details   
        public IEnumerable<Todo> GetAllTasks()
        {
            try
            {
                return _todo.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Get Task by Task Id  
        public Todo GetTaskByTaskId(int TaskId)
        {
            return _todo.GetAll().Where(x => x.id == TaskId).FirstOrDefault();
        }


        //Create New Task 
        public async Task<Todo> CreateTask(Todo todo)
        {
            return await _todo.Create(todo);
        }



        //Delete Task   
        public bool DeleteTask(int TaskId)
        {

            try
            {
                var DataList = _todo.GetAll().Where(x => x.id == TaskId).ToList();
                foreach (var item in DataList)
                {
                    _todo.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }


        //Update Task Details  
        public bool UpdateTask(Todo todo)
        {
            try
            {
                var DataList = _todo.GetAll().Where(x => x.IsDeleted != true).ToList();
                foreach (var item in DataList)
                {
                    _todo.Update(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }


    }


}

