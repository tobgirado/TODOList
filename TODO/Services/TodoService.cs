using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Helpers;
using TODO.Model;

namespace TODO.Services
{
    public interface ITodoService
    {
        IList<Todo> Get();
        IList<Todo> Get(bool completed);
        Todo Get(int id);
        Todo Post(Todo todo);
        Todo Put(Todo todo);
        bool Delete(int id);
        bool Exists(int id);
    }
    public class TodoService : ITodoService
    {
        private readonly DataContext _context;

        public TodoService(DataContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            if (Exists(id))
            {
                var todo = Get(id);
                _context.Todos.Remove(todo);
                _context.SaveChanges();
                return true;
            }
            return false;

        }

        public bool Exists(int id)
        {
            return _context.Todos.Where(x => x.Id == id).Any();
        }

        public IList<Todo> Get()
        {
            return _context.Todos.ToList();
        }

        public IList<Todo> Get(bool completed)
        {
            return _context.Todos.Where(x => x.Completed == completed).ToList();
        }

        public Todo Get(int id)
        {
            return _context.Todos.Where(x => x.Id == id).FirstOrDefault();
        }

        public Todo Post(Todo todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
            return todo;
        }

        public Todo Put(Todo todo)
        {
            _context.Update(todo);
            _context.SaveChanges();
            return todo;
        }
    }
}
