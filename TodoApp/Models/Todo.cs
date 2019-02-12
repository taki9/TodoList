using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public enum CategoryEnum {
        BUG,
        TASK,
        EPIC
    }

    public class Todo
    {
        public int Id { get; set; }
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
            int id  = 0,
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

            Name = name;
            Responsible = responsible;
            Id = id;
            Description = description;
            Deadline = (DateTime)deadline;
            Status = status;
            Category = category;
            ParentId = parent;
        }
    }
}