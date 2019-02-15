using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TodoApp.Models
{
    public class Todo
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string Priority { get; set; }
        [StringLength(50)]
        public string Responsible { get; set; }
        public Nullable<DateTime> Deadline { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        public Nullable<int> Category { get; set; }
        public Nullable<int> ParentId { get; set; }
    }
}