using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManagementService
{
    /// <summary>
    /// Provide the ability to manage User Tasks.
    /// </summary>
    public interface ITaskManagementService
    {
        ///// <summary>
        ///// Searches tasks by the given criteria.
        ///// </summary>
        ///// <param name="token">This is provided by the framework to notify when a request is cancelled.</param>
        ///// <returns>The results of the search.</returns>
     
        //Task<UserTask> SearchUserTasks(CancellationToken token);

        /// <summary>
        /// Gets list of User Tasks
        /// </summary>
        /// <param name="userKey">the unique identifier to get the list of tasks for an User</param>
        /// <param name="includeRemoved">Indicates if a removed patient allergy should be returned if available.</param>
        /// <param name="token">This is provided by the framework to notify when a request is cancelled.</param>
        /// <returns>returns Task of <see cref="UserTask"/></returns>
        IEnumerable<UserTask> GetUserTasks(Guid userKey, CancellationToken token, bool? includeRemoved = null);

        /// <summary>
        /// Creates a task with the given info
        /// </summary>
        /// <param name="userKey">The unique identifier of the user for which task is created.</param>
        /// <param name="info">Information about the new task</param>
        /// <param name="token">This is provided by the framework to notify when a request is cancelled.</param>
        /// <returns>Task Key of the newly user Task</returns>
        Guid CreateUserTask(Guid userKey, CreateUserTaskInfo info, CancellationToken token);

        /// <summary>
        /// Updates the task with the given key.
        /// </summary>
        /// <param name="userTaskKey">The unique identifier of the user task to update.</param>
        /// <param name="info">The data used to update the task.</param>
        /// <param name="token">This is provided by the framework to notify when a request is cancelled.</param>
        System.Threading.Tasks.Task UpdateUserTask(Guid userTaskKey, UpdateUserTaskInfo info, CancellationToken token);

        /// <summary>
        /// Removes the task with the given key.
        /// </summary>
        /// <param name="userTaskKey">The unique identifier of the user task to remove.</param>
        /// <param name="token"></param>
        System.Threading.Tasks.Task RemoveUserTask(Guid userTaskKey, CancellationToken token);

        /// <summary>
        /// Restores the patient allergy with the given key.
        /// </summary>
        /// <param name="userTaskKey">The unique identifier of the user task to restore.</param>
        /// <param name="token"></param>
        System.Threading.Tasks.Task RestoreUserTask(Guid userTaskKey, CancellationToken token);

    
    }
}
