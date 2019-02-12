using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
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
            new Todo(name: "Go shopping", priority: "major"),
            new Todo(name: "Learn .NET", priority: "critical", status: "in progress", deadline: new DateTime(2019, 05, 11))
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
        public object Post([FromBody] Todo newItem)
        {
            if (newItem.Name == null || newItem.Priority == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error: Invalid post data");
            }

            todoList.Add(newItem);
            return Request.CreateResponse(HttpStatusCode.OK, "New item added.");
        }

        // PATCH: api/todo/5
        public object Patch(int id, [FromBody] JsonPatchDocument<Todo> todoPatch)
        {
            todoPatch.ApplyTo(todoList[id]);
            return Request.CreateResponse(HttpStatusCode.OK, "Item pathed.");
        }

        // DELETE: api/todo/5
        public void Delete(int id)
        {
            todoList.RemoveAt(id);
        }
    }
}
