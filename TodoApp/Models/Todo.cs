using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoApp.Models.Enums;

namespace TodoApp.Models
{
    public class Todo
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Priority { get; set; }
        public String Responsible { get; set; }
        public DateTime Deadline { get; set; }
        public String Status { get; set; }
        public CategoryEnum Category { get; set; }
        public int ParentId { get; set; }

        public Todo(
            String name,
            String priority,
            String description = "",
            String responsible = "",
            DateTime? deadline = null,
            String status = "todo",
            CategoryEnum category = CategoryEnum.TASK,
            int parent = 0
        ) {
            if (deadline == null)
            {
                deadline = DateTime.Now.AddDays(1);
            }

            Id = Guid.NewGuid();
            Name = name;
            Priority = priority;
            Responsible = responsible;
            Description = description;
            Deadline = (DateTime)deadline;
            Status = status;
            Category = category;
            ParentId = parent;
        }
    }
}