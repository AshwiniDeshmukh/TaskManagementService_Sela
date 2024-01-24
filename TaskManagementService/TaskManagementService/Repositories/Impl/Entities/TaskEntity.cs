using System;

namespace TaskManagementService
{
    /// <summary>
    /// Contains information used to create a task for an User in the system.
    /// </summary>
    public class TaskEntity
    {
            /// <summary>
            /// The type of Task.
            /// </summary>
            public TaskType TaskType { get;}

            /// <summary>
            /// The name of the Task.
            /// </summary>

            public string Title { get;}

            /// <summary>
            /// The description of the task.
            /// </summary>
            public string TaskDescription { get;}

            /// <summary>
            /// The description of the task.
            /// </summary>

            public DateTime TaskDueDate { get;}

            /// <summary>
            /// The clinical status of the allergy.
            /// </summary>
            public TaskStatusType TaskStatusType { get;}
        }
}
