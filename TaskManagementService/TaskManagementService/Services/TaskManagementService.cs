using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManagementService
{
    /// <summary>
    /// Standard implementation of <see cref="ITaskManagementService"/>.
    /// </summary>
    internal class TaskManagementService : ITaskManagementService
    {
        private readonly ITaskManagementRepository _taskManagementRepo;
        private readonly ILogger<TaskManagementService> _logger;

        public TaskManagementService(
            ITaskManagementRepository taskManagementRepository
            ILogger<TaskManagementService> logger)
        {
            _taskManagementRepo = taskManagementRepository;
            _logger = logger;
        }

        ///// <inheritdoc/>
        //public async Task<UserTask> SearchUserTasks(UserTask searchCriteria, CancellationToken token)
        //{
            
        //    try
        //    {
        //        return await _taskManagementRepo.SearchUserTasksAsync(token);
        //    }
        //    catch (Exception e)
        //    {
        //        //throw ($"Error search patient allergies with criteria: [{searchCriteria}].", e);
        //    }
        //}

        /// <inheritdoc/>
        public async Task<IEnumerable<UserTask>> GetUserTasks(Guid userKey, CancellationToken token, bool? includeRemoved = null)
        {
            try
            {
                return await _taskManagementRepo.GetUserTasksAsync(userKey, token, includeRemoved);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<Guid> CreateUserTask(Guid userKey, CreateUserTaskInfo info, CancellationToken token)
        {
            
            try
            {
                var patientAllergyKey = await _taskManagementRepo.CreateUserTaskAsync(userKey, info, token);
                return patientAllergyKey;
            }
         
            catch (Exception e)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async System.Threading.Tasks.Task UpdateUserTask(Guid userTaskKey, UpdateUserTaskInfo info, CancellationToken token)
        {
            try
            {
                    await _taskManagementRepo.UpdateUserTaskAsync(userTaskKey, info, token);

  
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async System.Threading.Tasks.Task RemoveUserTask(Guid userTaskKey, CancellationToken token)
        {
            try
            {
                await _taskManagementRepo.RemoveUserTaskAsync(userTaskKey, token);

            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async System.Threading.Tasks.Task RestoreUserTask(Guid userTaskKey, CancellationToken token)
        {
            try
            {
                await _taskManagementRepo.RestoreUserTaskAsync(userTaskKey, token);

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
