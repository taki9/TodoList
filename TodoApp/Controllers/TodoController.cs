using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using TodoApp.Models;
using TodoApp.Models.Enums;

namespace TodoApp.Controllers
{
    public class TodoController : ApiController
    {

        private static List<Todo> todoList = new List<Todo>
        {
            new Todo {
                Id = Guid.NewGuid(),
                Name = "Workout",
                Description = "",
                Priority = "minor",
                Responsible = "John Snow",
                Deadline = DateTime.Now.AddDays(1),
                Status = "todo",
                Category = CategoryEnum.TASK,
                ParentId = 0,
            },
            new Todo {
                Id = Guid.NewGuid(),
                Name = "Go shopping",
                Description = "",
                Priority = "major",
                Responsible = "Bran Stark",
                Deadline = DateTime.Now.AddHours(3),
                Status = "todo",
                Category = CategoryEnum.TASK,
                ParentId = 0
            },
            new Todo {
                Id = Guid.NewGuid(),
                Name = "Learn .NET",
                Description = "",
                Priority = "critical",
                Responsible = "Varys",
                Deadline = new DateTime(2019, 05, 11),
                Status = "in progress",
                Category = CategoryEnum.EPIC,
                ParentId = 0
            }
        };

        // GET: api/todo
        public IHttpActionResult Get()
        {
            return Ok(todoList);
        }

        // GET: api/todo/{id}
        public IHttpActionResult Get(Guid id)
        {
            Todo todo = todoList.Find(item => item.Id == id);

            if (todo is null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        // POST: api/todo
        public IHttpActionResult Post([FromBody] Todo newItem)
        {
            if (String.IsNullOrEmpty(newItem.Name) || String.IsNullOrEmpty(newItem.Priority))
            {
                return NotFound();
            }

            todoList.Add(newItem);
            return Ok("New item added.");
        }

        // PATCH: api/todo/{id}
        public IHttpActionResult Patch(Guid id, [FromBody] Todo todoPatch)
        {
            Todo todo = todoList.Find(item => item.Id == id);

            if (todo is null)
            {
                return NotFound();
            }

            todo.Name = todoPatch.Name;
            todo.Description = todoPatch.Description;
            todo.Deadline = todoPatch.Deadline;
            todo.Category = todoPatch.Category;
            todo.ParentId = todoPatch.ParentId;
            todo.Responsible = todoPatch.Responsible;
            todo.Priority = todoPatch.Priority;
            todo.Status = todoPatch.Status;

            return Ok("Item patched.");
        }

        // DELETE: api/todo/{id}
        public IHttpActionResult Delete(Guid id)
        {
            Todo todo = todoList.Find(item => item.Id == id);

            if (todo is null)
            {
                return NotFound();
            }

            todoList.Remove(todo);
            return Ok("Item deleted.");
        }
    }
}
