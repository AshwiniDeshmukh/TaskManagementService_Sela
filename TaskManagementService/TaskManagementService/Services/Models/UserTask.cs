using System;

namespace TaskManagementService
{
    /// <summary>
    /// Holds information relational record 
    /// </summary>
    public class UserTask
    {
        public UserTask(string title, string description,TaskStatusType taskStatus, TaskType taskType , DateTime taskDueDate)
        {
            TaskType = taskType;
            Title = title;
            TaskStatusType = taskStatus;
            TaskType = taskType;
            TaskDueDate = taskDueDate;
        }

        /// <summary>
        /// The type of Task.
        /// </summary>
        public TaskType TaskType { get; set; }

        /// <summary>
        /// The name of the Task.
        /// </summary>

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
