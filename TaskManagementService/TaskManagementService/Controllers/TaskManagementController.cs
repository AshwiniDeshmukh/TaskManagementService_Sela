using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManagementService.Controllers
{
    /// <summary>
    /// Manages operations related to Task for an user.
    /// </summary>

    [Authorize]
    public class TaskManagementController : Controller
    {
        private readonly ITaskManagementService _service;

        public TaskManagementController(ITaskManagementService service)
        {
            _service = service;
        }

        /// <summary>
        /// Create a Task associated with an User. 
        /// </summary>
        /// <param name="userKey">The unique identifier of the user to create the Task for.</param>
        /// <param name="createUserTaskRequest">The request with details of Task to be created</param>
        /// <param name="token">This is provided by the framework to notify when a request is canceled.</param>
        /// <returns>A list of Tasks related to the User.</returns>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUserTask([FromRoute] Guid userKey, CreateUserTask createUserTaskRequest,
            CancellationToken token)
        {
            var userTaskKey = await _service.CreateUserTask(userKey, createUserTaskRequest, token);

            return userTaskKey;

        }

        /// <summary>
        /// Updates associated with an User. 
        /// </summary>
        /// <param name="userTaskKey">The unique identifier of the user to fetch list of Tasks for.</param>
        /// <param name="createUserTaskRequest">The request with details of Task to be updated</param>
        /// <param name="token">This is provided by the framework to notify when a request is canceled.</param>
        /// <returns>A list of Tasks related to the User.</returns>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUserTask([FromRoute] Guid userTaskKey, CreateUserTask createUserTaskRequest,
            CancellationToken token)
        {
           await _service.UpdateUserTask(userTaskKey, createUserTaskRequest, token);

            return "";

        }

        /// <summary>
        /// Retrieves list of Tasks associated with an User. 
        /// </summary>
        /// <param name="userKey">The unique identifier of the user to fetch list of Tasks for.</param>
        /// <param name="token">This is provided by the framework to notify when a request is canceled.</param>
        /// <returns>A list of Tasks related to the User.</returns>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserTasks([FromRoute] Guid userKey,
            CancellationToken token)
        {
            var userTasks = await _service.GetUserTasks(userKey, token);

            return userTasks;

        }

        /// <summary>
        /// Removes the Task associated with an User. 
        /// </summary>
        /// <param name="userTaskKey">The unique identifier of the user task to be deleted.</param>
        /// <param name="token">This is provided by the framework to notify when a request is canceled.</param>
        /// <returns>A list of Tasks related to the User.</returns>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUserTask([FromRoute] Guid userTaskKey,
            CancellationToken token)
        {
            await _service.RemoveUserTask(userTaskKey, token);

            return Respond.Ok(MapResponses());

        }

        /// <summary>
        /// Restores task associated with an User. 
        /// </summary>
        /// <param name="userTaskKey>TThe unique identifier of the user task to be restored</param>
        /// <param name="token">This is provided by the framework to notify when a request is canceled.</param>
        /// <returns>A list of Tasks related to the User.</returns>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RestoreUserTask([FromRoute] Guid userTaskKey,
            CancellationToken token)
        {
            await _service.RestoreUserTask(userTaskKey, token);

            return Respond.Ok(MapResponses());

        }
    }
}
