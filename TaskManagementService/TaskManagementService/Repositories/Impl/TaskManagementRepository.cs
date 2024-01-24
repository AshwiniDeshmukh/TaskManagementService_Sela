using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskManagementService;

namespace WCTS.PatientService.Repositories.Impl
{
    internal class TaskManagementRepository : RepositoryBase, ITaskManagementRepository
    {

    //    private readonly IDatabase _database;

        /// <summary>
        /// This repo class does use the PAC BaseRepository (IQueryCallFactory)
        /// </summary>
        public TaskManagementRepository(IQueryCallFactory callFactory, IDatabase database, ICurrentUser currentUser)
            : base(callFactory, database)
        {
            _database = Validator.CheckIsNotNull(database, nameof(database));
        }

        ///// <inheritdoc/>
        //public async Task<TaskEntity> SearchUserTasksAsync(Guid userKey, CancellationToken token)
        //{
        //    var userTasks = await QueryAsync(new SearchDiagnosesDelegate(QueryScripts, userKey, criteria), token);
         
        //    return (userTasks, pagedKeys.TotalCount);
        //}

        /// <inheritdoc/>
        public async Task<IEnumerable<UserTask>> GetUserTasksAsync(Guid userKey, CancellationToken token, bool? includeRemoved = false)
        {
            var entities = await QueryAsync(new GetUserTaskDelegate(QueryScripts, userKey, includeRemoved),
                token);

            return entities.ToModels();
        }

        /// <inheritdoc/>
        public async Task<Guid> CreateUserTaskAsync(Guid userKey, CreateUserTaskInfo info, CancellationToken token)
        {
            return await QueryAsync(new CreateUserTaskDelegate(QueryScripts, userKey, info), token);
        }

        /// <inheritdoc/>
        public async System.Threading.Tasks.Task UpdateUserTaskAsync(Guid userTaskKey, UpdateUserTaskInfo info, CancellationToken token)
        {
            await QueryAsync(new UpdateUserTaskDelegate(QueryScripts, userTaskKey, info), token);
        }

        /// <inheritdoc/>
        public async System.Threading.Tasks.Task RemoveUserTaskAsync(Guid userTaskKey, CancellationToken token)
        {
            await QueryAsync(new RemoveUserTaskDelegate(QueryScripts, userTaskKey), token);
        }

        /// <inheritdoc/>
        public async System.Threading.Tasks.Task RestoreDiagnosisAsync(Guid userTaskKey, CancellationToken token)
        {
            await QueryAsync(new RestoreUserTaskDelegate(QueryScripts, userTaskKey), token);
        }
    }
}
