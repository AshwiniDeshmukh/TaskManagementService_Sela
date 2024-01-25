using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskManagementService;
using TaskManagementService.Models;
using Task = TaskManagementService.Models.Task;

namespace WCTS.PatientService.Repositories.Impl
{
    internal class TaskManagementRepository : ITaskManagementRepository
    {

        private readonly Database _database;

        public IEnumerable<Task> Tasks { get; set; }
        /// <summary>
        /// This repo class does use the PAC BaseRepository (IQueryCallFactory)
        /// </summary>
        public TaskManagementRepository(Database db)
            
        {
            _database = db;
        }

        ///// <inheritdoc/>
        //public async Task<TaskEntity> SearchUserTasksAsync(Guid userKey, CancellationToken token)
        //{
        //    var userTasks = await QueryAsync(new SearchDiagnosesDelegate(QueryScripts, userKey, criteria), token);
         
        //    return (userTasks, pagedKeys.TotalCount);
        //}

        /// <inheritdoc/>
        public  IEnumerable<TaskManagementService.Models.Task> GetUserTasksAsync(Guid userKey, CancellationToken token, bool? includeRemoved = false)
        {
            Tasks =_database.Tasks.ToList();
            return Tasks;
        }

        /// <inheritdoc/>
        public  int CreateUserTaskAsync(Guid userKey, CreateUserTaskInfo info, CancellationToken token)
        {
            Task task = new() { Title = info.Title, Description=info.TaskDescription };
            _database.Tasks.Add(task);
            _database.SaveChangesAsync();
            return _database.Tasks.FirstOrDefault().ID;
        }

        /// <inheritdoc/>
        public async System.Threading.Tasks.Task UpdateUserTaskAsync(Guid userTaskKey, UpdateUserTaskInfo info, CancellationToken token)
        {
            
        }

        /// <inheritdoc/>
        public async System.Threading.Tasks.Task RemoveUserTaskAsync(Guid userTaskKey, CancellationToken token)
        {
            
        }

        /// <inheritdoc/>
        public async System.Threading.Tasks.Task RestoreUserTaskAsync(Guid userTaskKey, CancellationToken token)
        {
            
        }
    }
}
