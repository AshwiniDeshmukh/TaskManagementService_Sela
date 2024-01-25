using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using TaskManagementService.Models;

namespace TaskManagementService.Controllers
{
    /// <summary>
    /// Manages operations related to Task for an user.
    /// </summary>

    [Route(RouteConstants.TaskManagement.Root)]
    [ApiController]
    public class TaskManagementController : Controller
    {
        private readonly ITaskManagementService _service;

        public TaskManagementController(ITaskManagementService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("UserTask/{userKey:guid}")]
        /// <summary>
        /// Create a Task associated with an User. 
        /// </summary>
        /// <param name="userKey">The unique identifier of the user to create the Task for.</param>
        /// <param name="createUserTaskRequest">The request with details of Task to be created</param>
        /// <param name="token">This is provided by the framework to notify when a request is canceled.</param>
        /// <returns>A list of Tasks related to the User.</returns>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public int CreateUserTask([FromRoute] Guid userKey, CreateUserTask createUserTaskRequest,
            CancellationToken token)
        {
            var userTaskKey =  _service.CreateUserTask(userKey,
                new CreateUserTaskInfo { Title=createUserTaskRequest.Title, TaskDescription=createUserTaskRequest.TaskDescription, TaskStatusType=createUserTaskRequest.TaskStatusType
                , TaskType=createUserTaskRequest.TaskType, TaskDueDate=createUserTaskRequest.TaskDueDate
            } , token);

            return userTaskKey;

        }

        [HttpPut]
        [Route("UserTask/{userTaskKey:guid}")]
        /// <summary>
        /// Updates associated with an User. 
        /// </summary>
        /// <param name="userTaskKey">The unique identifier of the user to fetch list of Tasks for.</param>
        /// <param name="createUserTaskRequest">The request with details of Task to be updated</param>
        /// <param name="token">This is provided by the framework to notify when a request is canceled.</param>
        /// <returns>A list of Tasks related to the User.</returns>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Boolean UpdateUserTask([FromRoute] Guid userTaskKey, CreateUserTask createUserTaskRequest,
            CancellationToken token)
        {
            _service.UpdateUserTask(userTaskKey, new UpdateUserTaskInfo
           {
               Title = createUserTaskRequest.Title,
               TaskDescription = createUserTaskRequest.TaskDescription,
               TaskStatusType = createUserTaskRequest.TaskStatusType
                ,
               TaskType = createUserTaskRequest.TaskType,
               TaskDueDate = createUserTaskRequest.TaskDueDate
           }, token);

            return true;

        }

        [HttpGet]
        [Route("usertask/{userKey:guid}")]
        /// <summary>
        /// Retrieves list of Tasks associated with an User. 
        /// /// <param name="userKey">The unique identifier of the user to fetch list of Tasks for.</param>
        /// </summary>
        /// <returns>A list of Tasks related to the User.</returns>
        public IEnumerable<Task> GetUserTasks([FromRoute] Guid userKey)
        {
            CancellationToken Text = new CancellationToken() ;
            var userTasks =  _service.GetUserTasks(userKey, Text);

            return userTasks;

        }

        [HttpPatch("UserTask/{userTaskKey:guid}/remove")]
        /// <summary>
        /// Removes the Task associated with an User. 
        /// </summary>
        /// <param name="userTaskKey">The unique identifier of the user task to be deleted.</param>
        /// <param name="token">This is provided by the framework to notify when a request is canceled.</param>
        /// <returns>A list of Tasks related to the User.</returns>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Boolean DeleteUserTask([FromRoute] Guid userTaskKey,
            CancellationToken token)
        {
             _service.RemoveUserTask(userTaskKey, token);

            return true;

        }

        [HttpPatch("UserTask/{userTaskKey:guid}/restore")]
        /// <summary>
        /// Restores task associated with an User. 
        /// </summary>
        /// <param name="userTaskKey>TThe unique identifier of the user task to be restored</param>
        /// <param name="token">This is provided by the framework to notify when a request is canceled.</param>
        /// <returns>A list of Tasks related to the User.</returns>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public  Boolean RestoreUserTask([FromRoute] Guid userTaskKey,
            CancellationToken token)
        {
             _service.RestoreUserTask(userTaskKey, token);

            return true;

        }
    }
}
