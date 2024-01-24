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
        private readonly IPatientAllergyRepository _patientAllergyRepo;
        private readonly ILogger<TaskManagementService> _logger;

        public TaskManagementService(
            IPatientAllergyRepository patientAllergyRepository
            ILogger<TaskManagementService> logger)
        {
            _patientAllergyRepo = Validator.ValidateValue(patientAllergyRepository, nameof(patientAllergyRepository));
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<UserTask> SearchUserTasks(UserTask searchCriteria, CancellationToken token)
        {
            
            try
            {
                return await _patientAllergyRepo.SearchPatientAllergiesAsync(searchCriteria, token);
            }
            catch (Exception e)
            {
                //throw ($"Error search patient allergies with criteria: [{searchCriteria}].", e);
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UserTask>> GetUserTasks(IEnumerable<Guid> userKeys, CancellationToken token, bool? includeRemoved = null)
        {
            try
            {
                return await _patientAllergyRepo.GetPatientAllergiesAsync(userKeys, token, includeRemoved);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<Guid> CreateUserTask(Guid userKey, CreatePatientAllergyInfo info, CancellationToken token)
        {
            Validator.ValidateValue(info, nameof(info));
            try
            {
               
                var patientAllergyKey = await _patientAllergyRepo.CreatePatientAllergyAsync(userKey, info, token);
                return patientAllergyKey;
            }
         
            catch (Exception e)
            {
                throw;
            }
        }

        /// <inheritdoc/>
        public async System.Threading.Tasks.Task UpdateUserTask(Guid userTaskKey, UpdatePatientAllergyInfo info, CancellationToken token)
        {
            try
            {
                    var oldAllergy = (await _patientAllergyRepo.GetPatientAllergiesAsync(new[] { userTaskKey }, token)).First();
                    await _patientAllergyRepo.UpdatePatientAllergyAsync(userTaskKey, info, token);

                    var newAllergy = (await _patientAllergyRepo.GetPatientAllergiesAsync(new[] { userTaskKey }, token)).First();
  
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
                var oldAllergy = (await _patientAllergyRepo.GetPatientAllergiesAsync(new[] { userTaskKey }, token)).First();

                await _patientAllergyRepo.RemovePatientAllergyAsync(userTaskKey, token);

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
                var oldAllergy = (await _patientAllergyRepo.GetPatientAllergiesAsync(new[] { userTaskKey }, token, true)).First();

                await _patientAllergyRepo.RestorePatientAllergyAsync(userTaskKey, token);

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
