using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManagementService
{
    public interface ITaskManagementRepository
    {
        /// <summary>
        /// Search for tasks with the given criteria.
        /// </summary>
        /// <param name="userKey">The User to search the Tasks For.</param>
        /// <param name="criteria">The criteria used to search for the tasks.</param>
        /// <param name="token">This is provided by the framework to notify when a request is canceled.</param>
        /// <returns>Paged response containing the task that match the given criteria.</returns>
        Task<TaskEntity> SearchUserTasksAsync(Guid userKey, CancellationToken token);

        /// <summary>
        /// Retrieve the user tasks with the given keys.
        /// </summary>
        /// <param name="userKey">The unique identifiers of the user to retrieve tasks for.</param>
        /// <param name="token">This is provided by the framework to notify when a request is canceled.</param>
        /// <param name="includeRemoved">Indicates if removed records should be included in results.</param>
        /// <returns>The tasks with the given keys.</returns>
        Task<IEnumerable<UserTask>> GetUserTasksAsync(Guid userKey, CancellationToken token, bool? includeRemoved = false);

        /// <summary>
        /// Creates a task for the us with the given key.
        /// </summary>
        /// <param name="userKey">The unique identifier of the uset to create a task for.</param>
        /// <param name="info">The information used to create the task.</param>
        /// <param name="token">This is provided by the framework to notify when a request is canceled.</param>
        /// <returns>The unique identifier of the created task.</returns>
        Task<Guid> CreateUserTaskAsync(Guid userKey, CreateUserTaskInfo info, CancellationToken token);

        /// <summary>
        /// Updates a task with the given info.
        /// </summary>
        /// <param name="userTaskKey">The unique identifier of the task to update.</param>
        /// <param name="info">The information used to update the task</param>
        /// <param name="token">This is provided by the framework to notify when a request is canceled.</param>
        System.Threading.Tasks.Task UpdateUserTaskAsync(Guid userTaskKey, UpdateUserTaskInfo info, CancellationToken token);

        /// <summary>
        /// Deletes a UserTask.
        /// </summary>
        /// <param name="userTaskKey">The unique identifier of the UserTask to delete.</param>
        /// <param name="token">This is provided by the framework to notify when a request is canceled.</param>
        System.Threading.Tasks.Task RemoveUserTaskAsync(Guid userTaskKey, CancellationToken token);

        /// <summary>
        /// Restores a previously deleted UserTask.
        /// </summary>
        /// <param name="userTaskKey">The unique identifier of the UserTask to restore.</param>
        /// <param name="token">This is provided by the framework to notify when a request is canceled.</param>
        System.Threading.Tasks.Task RestoreUserTaskAsync(Guid userTaskKey, CancellationToken token);

    }
}
