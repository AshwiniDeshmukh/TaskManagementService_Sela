using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementService
{
    /// <summary>
    /// Request to Add patient allergy
    /// </summary>
    public class CreateUserTask
    {
        /// <summary>
        /// The type of Task.
        /// </summary>
        public TaskType TaskType { get; set; }

        /// <summary>
        /// The name of the Task.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// The description of the task.
        /// </summary>
        public string TaskDescription { get; set; }

        /// <summary>
        /// The description of the task.
        /// </summary>
        
        public DateTime TaskDueDate { get; set; }

        /// <summary>
        /// The clinical status of the allergy.
        /// </summary>
        public TaskStatusType TaskStatusType { get; set; }


  
    }
}
