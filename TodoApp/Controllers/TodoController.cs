using System;
using System.Web.Http;
using TodoApp.Models;
using TodoService;

namespace TodoApp.Controllers
{
    public class TodoController : ApiController
    {
        private TodoManager manager = new TodoManager();

        // GET: api/todo
        public IHttpActionResult Get()
        {
            return Ok(manager.GetAllTodo());
        }

        // GET: api/todo/{id}
        public IHttpActionResult Get(Guid id)
        {
            Todo todo = manager.GetTodo(id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        // POST: api/todo
        public IHttpActionResult Post([FromBody] Todo newItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            manager.AddTodo(newItem);

            return Ok("New item added.");
        }

        // PATCH: api/todo/{id}
        public IHttpActionResult Patch(Guid id, [FromBody] Todo todoPatch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            bool isPatched = manager.PatchTodo(id, todoPatch);

            return isPatched ? (IHttpActionResult)Ok("Item patched.") : NotFound();
        }

        // DELETE: api/todo/{id}
        public IHttpActionResult Delete(Guid id)
        {
            bool isDeleted = manager.DeleteTodo(id);

            return isDeleted ? (IHttpActionResult)Ok("Item deleted.") : NotFound();
        }
    }
}
