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
        public IHttpActionResult Get(string id)
        {
            Todo item = GetTodoById(id);

            if (item != null)
            {
                return Ok(item);
            }
            
            return Content(HttpStatusCode.NotFound, "Invalid id");
        }

        // POST: api/todo
        public IHttpActionResult Post([FromBody] Todo newItem)
        {
            if (String.IsNullOrEmpty(newItem.Name) || String.IsNullOrEmpty(newItem.Priority))
            {
                return Content(HttpStatusCode.NotFound, "Invalid post data");
            }

            todoList.Add(newItem);
            return Ok("New item added.");
        }

        // PATCH: api/todo/{id}
        public IHttpActionResult Patch(string id, [FromBody] Todo todoPatch)
        {
            Todo item = GetTodoById(id);

            if (item != null)
            {
                item.Name = todoPatch.Name;
                item.Description = todoPatch.Description;
                item.Deadline = todoPatch.Deadline;
                item.Category = todoPatch.Category;
                item.ParentId = todoPatch.ParentId;
                item.Responsible = todoPatch.Responsible;
                item.Priority = todoPatch.Priority;
                item.Status = todoPatch.Status;

                return Ok("Item patched.");
            }

            return Content(HttpStatusCode.NotFound, "Invalid id");
        }

        // DELETE: api/todo/{id}
        public IHttpActionResult Delete(string id)
        {
            Todo item = GetTodoById(id);

            if (item != null)
            {
                todoList.Remove(GetTodoById(id));
                return Ok("Item deleted.");
            }

            return Content(HttpStatusCode.NotFound, "Invalid id");
        }

        private Todo GetTodoById(string id)
        {
            try
            {
                Guid guid = Guid.Parse(id);
            }
            catch (FormatException)
            {
                return null;
            }

            return todoList.Find(item => item.Id == new Guid(id));
        }
    }
}
