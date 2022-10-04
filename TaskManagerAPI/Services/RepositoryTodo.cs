using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerAPI.DBContext;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Services
{
    public class RepositoryTodo: ITodoList<Todo>
    {
        ApplicationDbContext _dbContext;
        public RepositoryTodo(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<Todo> Create(Todo _object)
        {
            var obj = await _dbContext.Todos.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Todo _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Todo> GetAll()
        {
            try
            {
                return _dbContext.Todos.Where(x => x.IsDeleted == false).ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public Todo GetById(int Id)
        {
            return _dbContext.Todos.Where(x => x.IsDeleted == false && x.id == Id).FirstOrDefault();
        }

        public void Update(Todo _object)
        {
            _dbContext.Todos.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}

