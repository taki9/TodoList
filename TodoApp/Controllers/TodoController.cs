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
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, todoList);
        }

        // GET: api/todo/{id}
        public HttpResponseMessage Get(string id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, GetTodoById(new Guid(id)));
            }
            catch (ArgumentOutOfRangeException)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error: Invalid id");
            }
        }

        // POST: api/todo
        public HttpResponseMessage Post([FromBody] Todo newItem)
        {
            if (String.IsNullOrEmpty(newItem.Name) || String.IsNullOrEmpty(newItem.Priority))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error: Invalid post data");
            }

            todoList.Add(newItem);
            return Request.CreateResponse(HttpStatusCode.OK, "New item added.");
        }

        // PATCH: api/todo/{id}
        public HttpResponseMessage Patch(string id, [FromBody] JsonPatchDocument<Todo> todoPatch)
        {
            try
            {
                todoPatch.ApplyTo(GetTodoById(new Guid(id)));
            } catch (ArgumentOutOfRangeException)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error: Invalid id");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Item patched.");
        }

        // DELETE: api/todo/{id}
        public HttpResponseMessage Delete(string id)
        {
            todoList.Remove(GetTodoById(new Guid(id)));
            return Request.CreateResponse(HttpStatusCode.OK, "Item deleted.");
        }

        private Todo GetTodoById(Guid id)
        {
            return todoList.Find(item => item.Id == id);
        }
    }
}
