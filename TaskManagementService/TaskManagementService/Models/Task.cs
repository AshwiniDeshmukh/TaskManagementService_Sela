using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementService.Models
{
    public class Task
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; }
        public TaskStatusType TaskStatus { get; set; }
    }
}