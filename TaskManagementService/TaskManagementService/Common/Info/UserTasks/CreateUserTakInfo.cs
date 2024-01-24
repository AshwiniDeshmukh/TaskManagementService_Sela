using System;
using System.Linq;

namespace TaskManagementService
{
    /// <summary>
    /// Contains information used to create a task for an User in the system.
    /// </summary>
    public class CreateUserTaskInfo
    {
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

        /// <summary>
        /// Returns a string representation of the object.
        /// </summary>
        public override string ToString()
        {
            return string.Join(string.Empty,
                GetType().GetProperties().Select(propertyInfo => $"{propertyInfo.Name}:[{propertyInfo.GetValue(this)}]").ToList()
            );
        }
    }
}
