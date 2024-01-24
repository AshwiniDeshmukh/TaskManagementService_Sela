using System;

namespace TaskManagementService
{
    public class TaskEntity
    {
        /// <summary>
        /// The unique identifier of the diagnosis.
        /// </summary>
        public Guid DiagnosisKey { get; }

        /// <summary>
        /// The ICD-10 Code representing the diagnosis.
        /// </summary>
        public string ICD10Code { get; }

        /// <summary>
        /// The description of the diagnosis.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The name of the field that was changed.
        /// </summary>
        public string FieldName { get; }

        /// <summary>
        /// The value of the field before the change.
        /// </summary>
        public string OldValue { get; }

        /// <summary>
        /// The value of the field after the change.
        /// </summary>
        public string NewValue { get; }

        /// <summary>
        /// The date when the change happened.
        /// </summary>
        public DateTime CreatedOn { get; }

        /// <summary>
        /// The user that made the change.
        /// </summary>
        public string CreatedBy { get; }
    }
}
