using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class TodoController : ApiController
    {
        private TodoDataEntities db = new TodoDataEntities();

        // GET: api/todo
        public IHttpActionResult Get()
        {
            return Ok(db.Todo);
        }

        // GET: api/todo/{id}
        public IHttpActionResult Get(Guid id)
        {
            Todo todo = db.Todo.Find(id);
            if (todo is null)
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
                return BadRequest(ModelState);
            }

            db.Todo.Add(newItem);
            db.SaveChanges();

            return Ok("New item added.");
        }

        // PATCH: api/todo/{id}
        public IHttpActionResult Patch(Guid id, [FromBody] Todo todoPatch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Todo todo = db.Todo.Find(id);

            if (todo is null)
            {
                return NotFound();
            }

            db.Entry(todoPatch).State = EntityState.Modified;
            db.SaveChanges();

            return Ok("Item patched.");
        }

        // DELETE: api/todo/{id}
        public IHttpActionResult Delete(Guid id)
        {
            Todo todo = db.Todo.Find(id);
            if (todo is null)
            {
                return NotFound();
            }

            db.Todo.Remove(todo);
            db.SaveChanges();

            return Ok("Item deleted.");
        }
    }
}
