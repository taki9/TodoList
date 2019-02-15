using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoApp.Models;

namespace TodoService
{
    public class TodoManager
    {
        private TodoContext db = new TodoContext();

        public IEnumerable<Todo> GetAllTodo()
        {
            return db.Todos;
        }

        public Todo GetTodo(Guid id)
        {
            return db.Todos.Find(id);
        }

        public bool AddTodo(Todo newItem)
        {
            newItem.Id = Guid.NewGuid();
            db.Todos.Add(newItem);
            db.SaveChanges();

            return true;
        }

        public bool PatchTodo(Guid id, Todo todoPatch)
        {
            Todo todo = db.Todos.Find(id);

            if (todo is null)
            {
                return false;
            }

            todoPatch.Id = id;
            db.Entry(todo).CurrentValues.SetValues(todoPatch);
            db.SaveChanges();

            return true;
        }

        public bool DeleteTodo(Guid id)
        {
            Todo todo = db.Todos.Find(id);
            if (todo is null)
            {
                return false;
            }

            db.Todos.Remove(todo);
            db.SaveChanges();

            return true;
        }
    }
}