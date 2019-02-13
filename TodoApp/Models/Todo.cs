using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TodoApp.Models.Enums;

namespace TodoApp.Models
{
    public class Todo
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public String Name { get; set; }

        public String Description { get; set; }

        [Required]
        public String Priority { get; set; }

        public String Responsible { get; set; }

        public DateTime Deadline { get; set; }

        public String Status { get; set; }

        public CategoryEnum Category { get; set; }

        public int ParentId { get; set; }

        public Todo() { }
    }
}