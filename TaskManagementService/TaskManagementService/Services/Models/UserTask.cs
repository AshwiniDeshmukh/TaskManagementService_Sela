using System;

namespace TaskManagementService
{
    /// <summary>
    /// Holds information relational record 
    /// </summary>
    public class UserTask
    {
        public UserTask(Guid patientAssessmentKey, Guid patientAllergyKey, bool isSelected,
            int version, string versionBy, DateTime versionOn)
        {
            PatientAssessmentKey = patientAssessmentKey;
            PatientAllergyKey = patientAllergyKey;
            IsSelected = isSelected;
            VersionInfo = new VersionInfo(version, versionOn, versionBy);
        }

        /// <summary>
        /// The unique identifier of the patient assessment.
        /// </summary>
        public Guid PatientAssessmentKey { get; }

        /// <summary>
        /// The unique identifier of the patient allergy.
        /// </summary>
        public Guid PatientAllergyKey { get; }

        /// <summary>
        /// The selection value of the allergy on the patient assessment.
        /// </summary>
        public bool IsSelected { get; }

        /// <summary>
        /// Contains versioning information for the record.
        /// </summary>
        public VersionInfo VersionInfo { get; }
    }
}
