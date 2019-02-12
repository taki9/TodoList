using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class TodoController : ApiController
    {
        private static List<Todo> todoList = new List<Todo>
        {
            new Todo(name: "Workout", priority: "minor"),
            new Todo(id: 1, name: "Go shopping", priority: "major"),
            new Todo(id: 2, name: "Learn .NET", priority: "critical", status: "in progress", deadline: new DateTime(2019, 05, 11))
        };

        // GET: api/todo
        public string Get()
        {
            return JsonConvert.SerializeObject(todoList);
        }

        // GET: api/todo/5
        public string Get(int id)
        {
            try
            {
                return JsonConvert.SerializeObject(todoList[id]);
            } catch (ArgumentOutOfRangeException)
            {
                return "Error: Invalid id";
            }
        }

        // POST: api/todo
        public void Post([FromBody]string value)
        {
            Todo newItem = JsonConvert.DeserializeObject<Todo>(value);

            todoList.Add(newItem);
        }

        // PATCH: api/todo/5
        public void Patch(int id, [FromBody]string value)
        {

        }

        // DELETE: api/todo/5
        public void Delete(int id)
        {
            todoList.RemoveAt(id);
        }
    }
}
