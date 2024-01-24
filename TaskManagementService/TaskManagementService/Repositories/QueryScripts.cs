using Atlas.Data;
using Atlas.Utilities;
using System;

namespace WCTS.PatientService.Repositories
{
    internal class QueryScripts
    {
        internal DataProviderType DataProviderType { get; set; }

        // Use the old class name as the instance name, to avoid re-naming the calls in the Repositories
        internal PatientScripts Patient;
        internal PatientEnrollmentScripts PatientEnrollment;
        internal PatientInformationScripts PatientInformation;
        internal PatientIdentifierScripts PatientIdentifier;
        internal DiagnosisScripts Diagnosis;
        internal PatientAllergyScripts PatientAllergy;
        internal PatientMedicationScripts PatientMedication;
        internal PatientAssessmentScripts PatientAssessment;
        internal PatientVitalsMeasurementScripts PatientVitalsMeasurement;
        internal PatientInfusionTimerScripts PatientInfusionTimer;
        internal PatientInfusionTimerEventScripts PatientInfusionTimerEvent;
        internal PatientOrderScripts PatientOrder;
        internal PatientAssessmentAllergyScripts PatientAssessmentAllergy;
        internal PatientAssessmentMedicationProfileScripts PatientAssessmentMedicationProfile;
        internal PatientAssessmentDiagnosisScripts PatientAssessmentDiagnosis;
        internal PatientAssessmentDemographicsScripts PatientAssessmentDemographics;

        /// <summary>
        /// The tests know the provider type from the SetupFixture parameter, from which the RepositoryTestBase creates the RepoTestHelper,
        /// which produces a Database.
        /// The service configures the Database from settings.
        /// Both invoke the repositories, which always inject the Database, from which the RepositoryBase creates the correct QueryScript instance.
        /// </summary>
        public QueryScripts(DataProviderType dataProviderType)
        {
            this.DataProviderType = dataProviderType;
            string providerFolder = GetProviderFolder(dataProviderType);
            CreateScripts(providerFolder);
        }

        /// <summary>
        /// TODO REMOVE when update to latest WCTS.SF, and use extension dataProviderType.ProviderFolder();
        /// </summary>
        private string GetProviderFolder(DataProviderType dataProviderType)
        {
            switch (dataProviderType)
            {
                case DataProviderType.MsSqlServer:
                    return "SqlServer";
                case DataProviderType.PostgreSql:
                    return "Postgres";
                default:
                    throw new NotImplementedException("PatientService supports only SqlServer and PostgreSql.");
            }
        }

        /// <summary>
        /// Instantiate the classes with the configured folder
        /// </summary>
        private void CreateScripts(string providerFolder)
        {
            Patient = new PatientScripts(providerFolder);
            PatientEnrollment = new PatientEnrollmentScripts(providerFolder);
            PatientInformation = new PatientInformationScripts(providerFolder);
            PatientIdentifier = new PatientIdentifierScripts(providerFolder);
            Diagnosis = new DiagnosisScripts(providerFolder);
            PatientAllergy = new PatientAllergyScripts(providerFolder);
            PatientMedication = new PatientMedicationScripts(providerFolder);
            PatientAssessment = new PatientAssessmentScripts(providerFolder);
            PatientVitalsMeasurement = new PatientVitalsMeasurementScripts(providerFolder);
            PatientInfusionTimer = new PatientInfusionTimerScripts(providerFolder);
            PatientInfusionTimerEvent = new PatientInfusionTimerEventScripts(providerFolder);
            PatientOrder = new PatientOrderScripts(providerFolder);
            PatientAssessmentAllergy = new PatientAssessmentAllergyScripts(providerFolder);
            PatientAssessmentMedicationProfile = new PatientAssessmentMedicationProfileScripts(providerFolder);
            PatientAssessmentDiagnosis = new PatientAssessmentDiagnosisScripts(providerFolder);
            PatientAssessmentDemographics = new PatientAssessmentDemographicsScripts(providerFolder);
        }

        internal class PatientScripts
        {
            public string GetPatients { get; private set; }
            public string UpdatePatient { get; private set; }
            public string CreatePatient { get; private set; }
            public string GetPatientKeysForSync { get; private set; }
            public string FilterInvalidPatientKeys { get; private set; }
            public string GetPatientsAll { get; private set; }
            public string SearchPatients { get; private set; }
            public string GetNextMRN { get; private set; }
            public string SetMRNStartValue { get; private set; }
            public PatientScripts(string providerFolder)
            {
                GetPatients = EmbeddedResource.GetQueryScript($"{providerFolder}.Patient.GetPatients.sql");
                UpdatePatient = "placeholder";//EmbeddedResource.GetQueryScript($"{providerFolder}.Patient.UpdatePatient.sql");
                CreatePatient = "placeholder";//EmbeddedResource.GetQueryScript($"{providerFolder}.Patient.CreatePatient.sql");
                GetPatientKeysForSync = EmbeddedResource.GetQueryScript($"{providerFolder}.Patient.GetPatientKeysForSync.sql");
                FilterInvalidPatientKeys = "placeholder";//EmbeddedResource.GetQueryScript(${providerFolder}Patient.FilterInvalidPatientKeys.sql");
                GetPatientsAll = EmbeddedResource.GetQueryScript($"{providerFolder}.Patient.GetPatientsAll.sql");
                SearchPatients = EmbeddedResource.GetQueryScript($"{providerFolder}.Patient.SearchPatients.sql");
                GetNextMRN = "placeholder";//EmbeddedResource.GetQueryScript($"{providerFolder}.Patient.GetNextMRN.sql");
                SetMRNStartValue = "placeholder";//EmbeddedResource.GetQueryScript($"{providerFolder}.Patient.SetMRNStartValue.sql");
            }
        }

        internal class PatientEnrollmentScripts
        {
            public string CreatePatientEnrollment { get; private set; }
            public string RemoveAllPatientEnrollments { get; private set; }
            public string FetchPatientEnrollments { get; private set; }
            public PatientEnrollmentScripts(string providerFolder)
            {
                CreatePatientEnrollment = "placeholder";//EmbeddedResource.GetQueryScript($"{providerFolder}.PatientEnrollment.CreatePatientEnrollment.sql");
                RemoveAllPatientEnrollments = "placeholder";//EmbeddedResource.GetQueryScript($"{providerFolder}.PatientEnrollment.RemoveAllPatientEnrollments.sql");
                FetchPatientEnrollments = "placeholder";//EmbeddedResource.GetQueryScript($"{providerFolder}.PatientEnrollment.FetchPatientEnrollments.sql");
            }
        }

        internal class PatientInformationScripts
        {
            public string UpsertPatientInformation { get; private set; }
            public string GetPatientInformation { get; private set; }

            public PatientInformationScripts(string providerFolder)
            {
                UpsertPatientInformation = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientInformation.UpsertPatientInformation.sql");
                GetPatientInformation = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientInformation.GetPatientInformation.sql");
            }
        }

        internal class PatientIdentifierScripts
        {
            public string CreatePatientIdentifier { get; private set; }
            public string RemoveAllPatientIdentifiers { get; private set; }
            public string FetchPatientIdentifiers { get; private set; }
            public PatientIdentifierScripts(string providerFolder)
            {
                CreatePatientIdentifier = "placeholder";//EmbeddedResource.GetQueryScript($"{providerFolder}.PatientIdentifier.CreatePatientIdentifier.sql");
                RemoveAllPatientIdentifiers = "placeholder";//EmbeddedResource.GetQueryScript($"{providerFolder}.PatientIdentifier.RemoveAllPatientIdentifiers.sql");
                FetchPatientIdentifiers = "placeholder";//EmbeddedResource.GetQueryScript($"{providerFolder}.PatientIdentifier.FetchPatientIdentifiers.sql");
            }
        }

        //        internal  class PatientStatus
        //        {
        //            public  readonly string CreatePatientStatus = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientStatus.CreatePatientStatus.sql");
        //            public  readonly string RemoveAllPatientStatuses = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientStatus.RemoveAllPatientStatuses.sql");
        //        }
        //        
        //        internal  class PatientSite
        //        {
        //            public  readonly string CreatePatientSite = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientSite.CreatePatientSite.sql");
        //            public  readonly string RemoveAllPatientSites = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientSite.RemoveAllPatientSites.sql");
        //        }
        //
        //        internal  class BulkImport
        //        {
        //            public  readonly string CreatePendingImport = EmbeddedResource.GetQueryScript($"{providerFolder}.BulkImport.CreatePendingImport.sql");
        //            public  readonly string UpdatePendingImport = EmbeddedResource.GetQueryScript($"{providerFolder}.BulkImport.UpdatePendingImport.sql");
        //            public  readonly string UpdatePendingImportStatus = EmbeddedResource.GetQueryScript($"{providerFolder}.BulkImport.UpdatePendingImportStatus.sql");
        //            public  readonly string GetPendingImports = EmbeddedResource.GetQueryScript($"{providerFolder}.BulkImport.GetPendingImports.sql");
        //            public  readonly string SearchPendingImports = EmbeddedResource.GetQueryScript($"{providerFolder}.BulkImport.SearchPendingImports.sql");
        //            public  readonly string RemovePendingImport = EmbeddedResource.GetQueryScript($"{providerFolder}.BulkImport.RemovePendingImport.sql");
        //        }

        internal class DiagnosisScripts
        {
            public string SearchDiagnoses { get; private set; }
            public string GetDiagnoses { get; private set; }
            public string CreateDiagnosis { get; private set; }
            public string GetDiagnosisChanges { get; private set; }
            public string UpdateDiagnosis { get; private set; }
            public string CreateDiagnosisChange { get; private set; }
            public string RemoveDiagnosis { get; private set; }
            public string RestoreDiagnosis { get; private set; }
            public string ResolveDiagnosisSnapshot { get; private set; }
            public string GetDiagnosisSnapshots { get; private set; }
            public DiagnosisScripts(string providerFolder)
            {
                SearchDiagnoses = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientDiagnosis.SearchPatientDiagnoses.sql");
                GetDiagnoses = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientDiagnosis.GetPatientDiagnoses.sql");
                CreateDiagnosis = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientDiagnosis.CreatePatientDiagnosis.sql");
                GetDiagnosisChanges = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientDiagnosis.GetPatientDiagnosisChanges.sql");
                UpdateDiagnosis = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientDiagnosis.UpdatePatientDiagnosis.sql");
                CreateDiagnosisChange = "placeholder";//  EmbeddedResource.GetQueryScript($"{providerFolder}.PatientDiagnosis.CreateDiagnosisChange.sql");
                RemoveDiagnosis = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientDiagnosis.RemovePatientDiagnosis.sql");
                RestoreDiagnosis = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientDiagnosis.RestorePatientDiagnosis.sql");
                ResolveDiagnosisSnapshot = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientDiagnosis.ResolvePatientDiagnosisSnapshot.sql");
                GetDiagnosisSnapshots = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientDiagnosis.GetPatientDiagnosisSnapshots.sql");
            }
        }

        internal class PatientAllergyScripts
        {
            public string SearchPatientAllergies { get; private set; }
            public string GetPatientAllergies { get; private set; }
            public string CreatePatientAllergy { get; private set; }
            public string UpdatePatientAllergy { get; private set; }
            public string CreatePatientAllergyChange { get; private set; }
            public string GetPatientAllergyChanges { get; private set; }
            public string RemovePatientAllergy { get; private set; }
            public string RestorePatientAllergy { get; private set; }
            public string RetrievePatientAllergyManifestationTypes { get; private set; }
            public string CreatePatientAllergyManifestationTypes { get; private set; }
            public string RemovePatientAllergyManifestationTypes { get; private set; }
            public string ResolvePatientAllergySnapshots { get; private set; }
            public string GetPatientAllergySnapshots { get; private set; }
            public PatientAllergyScripts(string providerFolder)
            {
                SearchPatientAllergies = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAllergy.SearchPatientAllergies.sql");
                GetPatientAllergies = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAllergy.GetPatientAllergies.sql");
                CreatePatientAllergy = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAllergy.CreatePatientAllergy.sql");
                UpdatePatientAllergy = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAllergy.UpdatePatientAllergy.sql");
                CreatePatientAllergyChange = "placeholder";//  EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAllergy.CreatePatientAllergyChange.sql");
                GetPatientAllergyChanges = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAllergy.GetPatientAllergyChanges.sql");
                RemovePatientAllergy = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAllergy.RemovePatientAllergy.sql");
                RestorePatientAllergy = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAllergy.RestorePatientAllergy.sql");
                RetrievePatientAllergyManifestationTypes = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAllergy.RetrievePatientAllergyManifestationTypes.sql");
                CreatePatientAllergyManifestationTypes = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAllergy.CreatePatientAllergyManifestationTypes.sql");
                RemovePatientAllergyManifestationTypes = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAllergy.RemovePatientAllergyManifestationTypes.sql");
                ResolvePatientAllergySnapshots = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAllergy.ResolvePatientAllergySnapshot.sql");
                GetPatientAllergySnapshots = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAllergy.GetPatientAllergySnapshots.sql");
            }
        }

        internal class PatientMedicationScripts
        {
            public string CreatePatientMedication { get; private set; }
            public string SearchPatientMedications { get; private set; }
            public string SearchPatientMedicationProfiles { get; private set; }
            public string GetPatientMedications  { get; private set; }
            public string GetPatientMedicationProfiles { get; private set; }
            public string UpdatePatientMedication { get; private set; }
            public string RemovePatientMedication { get; private set; }
            public string RestorePatientMedication { get; private set; }
            public string CreatePatientMedicationChange { get; private set; }
            public string GetPatientMedicationChanges { get; private set; }
            public string GetPatientMedicationKeysForSync { get; private set; }
            public string ResolvePatientMedicationProfileSnapshots { get; private set; }
            public string GetPatientMedicationProfileSnapshots { get; private set; }

            public PatientMedicationScripts(string providerFolder)
            {
                CreatePatientMedication = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientMedicationProfile.CreatePatientMedication.sql");
                SearchPatientMedications = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientMedicationProfile.SearchPatientMedications.sql");
                SearchPatientMedicationProfiles = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientMedicationProfile.SearchPatientMedicationProfiles.sql");
                GetPatientMedications = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientMedicationProfile.GetPatientMedications.sql");
                GetPatientMedicationProfiles = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientMedicationProfile.GetPatientMedicationProfiles.sql");
                UpdatePatientMedication = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientMedicationProfile.UpdatePatientMedication.sql");
                RemovePatientMedication = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientMedicationProfile.RemovePatientMedication.sql");
                RestorePatientMedication = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientMedicationProfile.RestorePatientMedication.sql");
                CreatePatientMedicationChange = "placeholder";//  EmbeddedResource.GetQueryScript($"{providerFolder}.PatientMedication.CreatePatientMedicationChange.sql");
                GetPatientMedicationChanges = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientMedicationProfile.GetPatientMedicationChanges.sql");
                GetPatientMedicationKeysForSync = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientMedicationProfile.GetPatientMedicationKeysForSync.sql");
                ResolvePatientMedicationProfileSnapshots = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientMedicationProfile.ResolvePatientMedicationProfileSnapshots.sql");
                GetPatientMedicationProfileSnapshots = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientMedicationProfile.GetPatientMedicationProfileSnapshots.sql");
            }
        }

        //        internal class Prescriber
        //        {
        //            public  readonly string GetPrescribers = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.GetPrescribers.sql");
        //            public  readonly string CreatePrescriber = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.CreatePrescriber.sql");
        //            public  readonly string UpdatePrescriber = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.UpdatePrescriber.sql");
        //            public  readonly string RemovePrescriber = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.RemovePrescriber.sql");
        //            public  readonly string RestorePrescriber = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.RestorePrescriber.sql");
        //            public  readonly string GetPrescriberKeysForSync = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.GetPrescriberKeysForSync.sql");
        //            public  readonly string CreatePrescriberLicense = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.CreatePrescriberLicense.sql");
        //            public  readonly string FetchPrescriberLicenseKeys = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.FetchPrescriberLicenseKeys.sql");
        //            public  readonly string UpdatePrescriberLicense = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.UpdatePrescriberLicense.sql");
        //            public  readonly string RemovePrescriberLicense = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.RemovePrescriberLicense.sql");
        //            public  readonly string RestorePrescriberLicense = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.RestorePrescriberLicense.sql");
        //            public  readonly string GetPrescriberLicenses = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.GetPrescriberLicenses.sql");
        //            public  readonly string GetPrescriberLicenseChanges = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.GetPrescriberLicenseChanges.sql");
        //            public  readonly string CreatePrescriberLicenseChange = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.CreatePrescriberLicenseChange.sql");
        //            public  readonly string CreatePrescriberAncillaryProvider = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.CreatePrescriberAncillaryProvider.sql");
        //            public  readonly string RemoveAllPrescriberAncillaryProviders = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.RemoveAllPrescriberAncillaryProviders.sql");
        //            public  readonly string CreatePrescriberClinicalContact = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.CreatePrescriberClinicalContact.sql");
        //            public  readonly string RemoveAllPrescriberClinicalContacts = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.RemoveAllPrescriberClinicalContacts.sql");
        //            public  readonly string CreatePrescriberStatus = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.CreatePrescriberStatus.sql");
        //            public  readonly string SearchPrescriberLicenses = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.SearchPrescriberLicenses.sql");
        //            public  readonly string TryGetPrescriberKeys = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.TryGetPrescriberKeys.sql");
        //            public  readonly string CreatePrescriberChange = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.CreatePrescriberChange.sql");
        //            public  readonly string GetPrescriberChanges = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.GetPrescriberChanges.sql");
        //            public  readonly string SearchPrescriber = EmbeddedResource.GetQueryScript($"{providerFolder}.Prescriber.SearchPrescriber.sql");
        //        }
        //
        //        internal class Practice
        //        {
        //            public  readonly string CreatePractice = EmbeddedResource.GetQueryScript($"{providerFolder}.Practice.CreatePractice.sql");
        //            public  readonly string CreatePrescriberPractice = EmbeddedResource.GetQueryScript($"{providerFolder}.Practice.CreatePrescriberPractice.sql");
        //            public  readonly string CreatePracticeChange = EmbeddedResource.GetQueryScript($"{providerFolder}.Practice.CreatePracticeChange.sql");
        //            public  readonly string CreatePrescriberPracticeChange = EmbeddedResource.GetQueryScript($"{providerFolder}.Practice.CreatePrescriberPracticeChange.sql");
        //            public  readonly string FetchPrescriberKeysByPractice = EmbeddedResource.GetQueryScript($"{providerFolder}.Practice.FetchPrescriberKeysByPractice.sql");
        //            public  readonly string GetPractices = EmbeddedResource.GetQueryScript($"{providerFolder}.Practice.GetPractices.sql");
        //            public  readonly string GetPracticeChangesAndPrescriberPracticeChanges = EmbeddedResource.GetQueryScript($"{providerFolder}.Practice.GetPracticeChangesAndPrescriberPracticeChanges.sql");
        //            public  readonly string GetPrescriberPractices = EmbeddedResource.GetQueryScript($"{providerFolder}.Practice.GetPrescriberPractices.sql");
        //            public  readonly string GetPrescriberPracticesByPrescribers = EmbeddedResource.GetQueryScript($"{providerFolder}.Practice.GetPrescriberPracticesByPrescribers.sql");
        //            public  readonly string UpdatePractice = EmbeddedResource.GetQueryScript($"{providerFolder}.Practice.UpdatePractice.sql");
        //            public  readonly string UpdatePrescriberPractice = EmbeddedResource.GetQueryScript($"{providerFolder}.Practice.UpdatePrescriberPractice.sql");
        //            public  readonly string RemovePractice = EmbeddedResource.GetQueryScript($"{providerFolder}.Practice.RemovePractice.sql");
        //            public  readonly string RemovePrescriberPractice = EmbeddedResource.GetQueryScript($"{providerFolder}.Practice.RemovePrescriberPractice.sql");
        //            public  readonly string RemovePrescriberPracticeByPractice = EmbeddedResource.GetQueryScript($"{providerFolder}.Practice.RemovePrescriberPracticeByPractice.sql");
        //            public  readonly string RestorePractice = EmbeddedResource.GetQueryScript($"{providerFolder}.Practice.RestorePractice.sql");
        //            public  readonly string RestorePrescriberPractice = EmbeddedResource.GetQueryScript($"{providerFolder}.Practice.RestorePrescriberPractice.sql");
        //        }
        //
        //        internal class AncillaryProvider
        //        {
        //            public  readonly string GetAncillaryProviders = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.GetAncillaryProviders.sql");
        //            public  readonly string CreateAncillaryProvider = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.CreateAncillaryProvider.sql");
        //            public  readonly string CreateAncillaryProviderStatus = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.CreateAncillaryProviderStatus.sql");
        //            public  readonly string GetAncillaryProviderKeysForSync = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.GetAncillaryProviderKeysForSync.sql");
        //            public  readonly string UpdateAncillaryProvider = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.UpdateAncillaryProvider.sql");
        //            public  readonly string RemoveAncillaryProvider = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.RemoveAncillaryProvider.sql");
        //            public  readonly string RestoreAncillaryProvider = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.RestoreAncillaryProvider.sql");
        //            public  readonly string CreateAncillaryProviderLicense = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.CreateAncillaryProviderLicense.sql");
        //            public  readonly string FetchAncillaryProviderLicenseKeys = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.FetchAncillaryProviderLicenseKeys.sql");
        //            public  readonly string UpdateAncillaryProviderLicense = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.UpdateAncillaryProviderLicense.sql");
        //            public  readonly string RemoveAncillaryProviderLicense = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.RemoveAncillaryProviderLicense.sql");
        //            public  readonly string RestoreAncillaryProviderLicense = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.RestoreAncillaryProviderLicense.sql");
        //            public  readonly string GetAncillaryProviderLicenses = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.GetAncillaryProviderLicenses.sql");
        //            public  readonly string SearchAncillaryProviderLicenses = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.SearchAncillaryProviderLicenses.sql");
        //            public  readonly string GetAncillaryProviderLicenseChanges = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.GetAncillaryProviderLicenseChanges.sql");
        //            public  readonly string CreateAncillaryProviderLicenseChange = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.CreateAncillaryProviderLicenseChange.sql");
        //            public  readonly string CreateAncillaryProviderClinicalContact = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.CreateAncillaryProviderClinicalContact.sql");
        //            public  readonly string RemoveAllAncillaryProviderClinicalContacts = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.RemoveAllAncillaryProviderClinicalContacts.sql");
        //            public  readonly string CreateAncillaryProviderLocation = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.CreateAncillaryProviderLocation.sql");
        //            public  readonly string FetchAncillaryProviderLocationKeys = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.FetchAncillaryProviderLocationKeys.sql");
        //            public  readonly string GetAncillaryProviderLocations = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.GetAncillaryProviderLocations.sql");
        //            public  readonly string UpdateAncillaryProviderLocation = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.UpdateAncillaryProviderLocation.sql");
        //            public  readonly string RemoveAncillaryProviderLocation = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.RemoveAncillaryProviderLocation.sql");
        //            public  readonly string RestoreAncillaryProviderLocation = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.RestoreAncillaryProviderLocation.sql");
        //            public  readonly string CreateAncillaryProviderLocationChange = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.CreateAncillaryProviderLocationChange.sql");
        //            public  readonly string GetAncillaryProviderLocationChanges = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.GetAncillaryProviderLocationChanges.sql");
        //            public  readonly string TryGetAncillaryProviderKeys = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.TryGetAncillaryProviderKeys.sql");
        //            public  readonly string CreateAncillaryProviderChange = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.CreateAncillaryProviderChange.sql");
        //            public  readonly string GetAncillaryProviderChanges = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.GetAncillaryProviderChanges.sql");
        //            public  readonly string SearchAncillaryProvider = EmbeddedResource.GetQueryScript($"{providerFolder}.AncillaryProvider.SearchAncillaryProvider.sql");
        //        }
        //
        //        internal class ClinicalContact
        //        {
        //            public  readonly string GetClinicalContacts = EmbeddedResource.GetQueryScript($"{providerFolder}.ClinicalContact.GetClinicalContacts.sql");
        //            public  readonly string CreateClinicalContact = EmbeddedResource.GetQueryScript($"{providerFolder}.ClinicalContact.CreateClinicalContact.sql");
        //            public  readonly string GetClinicalContactKeysForSync = EmbeddedResource.GetQueryScript($"{providerFolder}.ClinicalContact.GetClinicalContactKeysForSync.sql");
        //            public  readonly string UpdateClinicalContact = EmbeddedResource.GetQueryScript($"{providerFolder}.ClinicalContact.UpdateClinicalContact.sql");
        //            public  readonly string RemoveClinicalContact = EmbeddedResource.GetQueryScript($"{providerFolder}.ClinicalContact.RemoveClinicalContact.sql");
        //            public  readonly string RestoreClinicalContact = EmbeddedResource.GetQueryScript($"{providerFolder}.ClinicalContact.RestoreClinicalContact.sql");
        //            public  readonly string RemoveClinicalContactAncillaryProvider = EmbeddedResource.GetQueryScript($"{providerFolder}.ClinicalContact.RemoveClinicalContactAncillaryProvider.sql");
        //            public  readonly string RestoreClinicalContactAncillaryProvider = EmbeddedResource.GetQueryScript($"{providerFolder}.ClinicalContact.RestoreClinicalContactAncillaryProvider.sql");
        //            public  readonly string RemovePrescriberClinicalContact = EmbeddedResource.GetQueryScript($"{providerFolder}.ClinicalContact.RemovePrescriberClinicalContact.sql");
        //            public  readonly string RestorePrescriberClinicalContact = EmbeddedResource.GetQueryScript($"{providerFolder}.ClinicalContact.RestorePrescriberClinicalContact.sql");
        //            public  readonly string TryGetClinicalContactKeys = EmbeddedResource.GetQueryScript($"{providerFolder}.ClinicalContact.TryGetClinicalContactKeys.sql");
        //        }
        //
        internal class PatientAssessmentScripts
        {
            public string SearchPatientAssessments { get; private set; }
            public string GetPatientAssessments { get; private set; }
            public string CreatePatientAssessment { get; private set; }
            public string UpdatePatientAssessment { get; private set; }
            public string RemovePatientAssessment { get; private set; }
            public string RestorePatientAssessment { get; private set; }

            public string LinkDiagnosisSnapshots { get; private set; }
            public string LinkAllergySnapshots { get; private set; }
            public string LinkMedicationProfileSnapshots { get; private set; }
            public string LinkInfusionTimerEventSnapshots { get; private set; }
            public string LinkInfusionTimerEventChange { get; private set; }
            public string RetrieveInfusionTimerEventChanges { get; private set; }
            public string LinkPatientVitalsMeasurementChanges { get; private set; }
            public string RetrievePatientVitalsMeasurementChanges { get; private set; }

            public string SearchPatientAssessmentAllergySnapshot { get; private set; }
            public string SearchPatientAssessmentMedicationProfileSnapshot { get; private set; }
            public string SearchPatientAssessmentDiagnosisSnapshot { get; private set; }
            public string SearchPatientAssessmentInfusionTimerEventSnapshot { get; private set; }
            public string SearchPatientAssessmentVitalsMeasurementSnapshot { get; private set; }
            public string SearchPatientAssessmentDemographicsSnapshot { get; private set; }

            public string CreatePatientAssessmentChange { get; private set; }
            public string SearchPatientAssessmentChanges { get; private set; }
            public string GetPatientAssessmentChanges { get; private set; }

            public PatientAssessmentScripts(string providerFolder)
            {
                SearchPatientAssessments = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.SearchPatientAssessments.sql");
                GetPatientAssessments = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.GetPatientAssessments.sql");
                CreatePatientAssessment = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.CreatePatientAssessment.sql");
                UpdatePatientAssessment = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.UpdatePatientAssessment.sql");
                RemovePatientAssessment = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.RemovePatientAssessment.sql");
                RestorePatientAssessment = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.RestorePatientAssessment.sql");

                LinkDiagnosisSnapshots = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.LinkDiagnosisSnapshots.sql");
                LinkAllergySnapshots = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.LinkAllergySnapshots.sql");
                LinkMedicationProfileSnapshots = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.LinkMedicationProfileSnapshots.sql");
                LinkInfusionTimerEventSnapshots = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.LinkInfusionTimerEventSnapshots.sql");
                LinkInfusionTimerEventChange = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.LinkInfusionTimerEventChanges.sql");
                RetrieveInfusionTimerEventChanges = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.RetrieveInfusionTimerEventChanges.sql");
                LinkPatientVitalsMeasurementChanges = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.LinkPatientVitalsMeasurementChanges.sql");
                RetrievePatientVitalsMeasurementChanges = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.RetrievePatientVitalsMeasurementChanges.sql");

                SearchPatientAssessmentAllergySnapshot = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.SearchPatientAssessmentAllergySnapshot.sql");
                SearchPatientAssessmentDiagnosisSnapshot = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.SearchPatientAssessmentDiagnosisSnapshot.sql");
                SearchPatientAssessmentMedicationProfileSnapshot = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.SearchPatientAssessmentMedicationProfileSnapshot.sql");
                SearchPatientAssessmentInfusionTimerEventSnapshot = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.SearchPatientAssessmentInfusionTimerEventSnapshot.sql");
                SearchPatientAssessmentVitalsMeasurementSnapshot = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.SearchPatientAssessmentVitalsMeasurementSnapshot.sql");
                SearchPatientAssessmentDemographicsSnapshot = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.SearchPatientAssessmentDemographicsSnapshot.sql");

                CreatePatientAssessmentChange = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.CreatePatientAssessmentChange.sql");
                SearchPatientAssessmentChanges = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.SearchPatientAssessmentChanges.sql");
                GetPatientAssessmentChanges = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.GetPatientAssessmentChanges.sql");

            }
        }

        internal class PatientVitalsMeasurementScripts
        {
            public string SearchPatientVitalsMeasurement { get; private set; }
            public string GetPatientVitalsMeasurements { get; private set; }
            public string CreatePatientVitalsMeasurement { get; private set; }
            public string UpdatePatientVitalsMeasurement { get; private set; }
            public string RemovePatientVitalsMeasurement { get; private set; }
            public string RestorePatientVitalsMeasurement { get; private set; }
            public string ResolvePatientVitalsMeasurementSnapshot { get; private set; }
            public string GetPatientVitalsMeasurementSnapshots { get; private set; }
            public string CreatePatientVitalsMeasurementChange { get; private set; }
            public PatientVitalsMeasurementScripts(string providerFolder)
            {
                SearchPatientVitalsMeasurement = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientVitalsMeasurement.SearchPatientVitalsMeasurements.sql");
                GetPatientVitalsMeasurements = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientVitalsMeasurement.GetPatientVitalsMeasurements.sql");
                CreatePatientVitalsMeasurement = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientVitalsMeasurement.CreatePatientVitalsMeasurement.sql");
                UpdatePatientVitalsMeasurement = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientVitalsMeasurement.UpdatePatientVitalsMeasurement.sql");
                RemovePatientVitalsMeasurement = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientVitalsMeasurement.RemovePatientVitalsMeasurement.sql");
                RestorePatientVitalsMeasurement = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientVitalsMeasurement.RestorePatientVitalsMeasurement.sql");
                ResolvePatientVitalsMeasurementSnapshot = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientVitalsMeasurement.ResolvePatientVitalsMeasurementSnapshot.sql");
                GetPatientVitalsMeasurementSnapshots = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientVitalsMeasurement.GetPatientVitalsMeasurementSnapshots.sql");
                CreatePatientVitalsMeasurementChange = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientVitalsMeasurement.CreatePatientVitalsMeasurementChange.sql");
            }
        }

        internal class PatientInfusionTimerScripts
        {
            public string GetPatientInfusionTimers { get; private set; }
            public string RetrievePatientInfusionTimer { get; private set; }
            public string CreatePatientInfusionTimer { get; private set; }
            public string UpdatePatientInfusionTimer { get; private set; }
            public PatientInfusionTimerScripts(string providerFolder)
            {
                GetPatientInfusionTimers = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientInfusionTimer.GetPatientInfusionTimers.sql");
                RetrievePatientInfusionTimer = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientInfusionTimer.RetrievePatientInfusionTimer.sql");
                CreatePatientInfusionTimer = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientInfusionTimer.CreatePatientInfusionTimer.sql");
                UpdatePatientInfusionTimer = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientInfusionTimer.UpdatePatientInfusionTimer.sql");
            }
        }

        internal class PatientInfusionTimerEventScripts
        {
            public string SearchPatientInfusionTimerEvents { get; private set; }
            public string GetPatientInfusionTimerEvents { get; private set; }
            public string CreatePatientInfusionTimerEvent { get; private set; }
            public string UpdatePatientInfusionTimerEvent { get; private set; }
            public string RemovePatientInfusionTimerEvent { get; private set; }
            public string ResolvePatientInfusionTimerEventSnapshots { get; private set; }
            public string GetPatientInfusionTimerEventSnapshots { get; private set; }
            public string CreateInfusionTimerEventChange { get; private set; }

            public PatientInfusionTimerEventScripts(string providerFolder)
            {
                SearchPatientInfusionTimerEvents = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientInfusionTimerEvent.SearchPatientInfusionTimerEvents.sql");
                GetPatientInfusionTimerEvents = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientInfusionTimerEvent.GetPatientInfusionTimerEvents.sql");
                CreatePatientInfusionTimerEvent = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientInfusionTimerEvent.CreatePatientInfusionTimerEvent.sql");
                UpdatePatientInfusionTimerEvent = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientInfusionTimerEvent.UpdatePatientInfusionTimerEvent.sql");
                RemovePatientInfusionTimerEvent = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientInfusionTimerEvent.RemovePatientInfusionTimerEvent.sql");
                ResolvePatientInfusionTimerEventSnapshots = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientInfusionTimerEvent.ResolvePatientInfusionTimerEventSnapshot.sql");
                GetPatientInfusionTimerEventSnapshots = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientInfusionTimerEvent.GetPatientInfusionTimerEventSnapshots.sql");
                CreateInfusionTimerEventChange = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientInfusionTimerEvent.CreateInfusionTimerEventChange.sql");
            }
        }

        internal class PatientOrderScripts
        {
            public string GetPatientOrders { get; private set; }
            public string SearchPatientOrders { get; private set; }

            public PatientOrderScripts(string providerFolder)
            {
                GetPatientOrders = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrders.GetPatientOrders.sql");
                SearchPatientOrders = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrders.SearchPatientOrders.sql");
            }
        //            public  readonly string CreatePatientOrders = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrders.CreatePatientOrder.sql");
        //            public  readonly string UpdatePatientOrders = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrders.UpdatePatientOrder.sql");
        //            public  readonly string RemovePatientOrders = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrders.RemovePatientOrder.sql");
        //            public  readonly string RestorePatientOrders = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrders.RestorePatientOrder.sql");
        //            public  readonly string UpsertPatientOrderDiagnosis = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrders.UpsertPatientOrderDiagnosis.sql");
        //            public  readonly string CreatePatientOrderChange = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrders.CreatePatientOrderChange.sql");
        //            public  readonly string GetPatientOrderChanges = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrders.GetPatientOrderChanges.sql");
        //            public  readonly string SearchPatientOrderChanges = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrders.SearchPatientOrderChanges.sql");
        //            public  readonly string GetPatientOrderCPAP = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrders.GetPatientOrderCPAP.sql");
        //            public  readonly string UpsertPatientOrderCPAP = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrders.UpsertPatientOrderCPAP.sql");
        //            public  readonly string GetPatientOrderBiPAP = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrders.GetPatientOrderBiPAP.sql");
        //            public  readonly string UpsertPatientOrderBiPAP = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrders.UpsertPatientOrderBiPAP.sql");
    }

        //        internal  class PatientOrderItem
        //        {
        //            public  readonly string SearchPatientOrderItems = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrderItems.SearchPatientOrderItems.sql");
        //            public  readonly string GetPatientOrderItems = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrderItems.GetPatientOrderItems.sql");
        //            public  readonly string CreatePatientOrderItems = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrderItems.CreatePatientOrderItem.sql");
        //            public  readonly string UpdatePatientOrderItems = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrderItems.UpdatePatientOrderItem.sql");
        //            public  readonly string RemovePatientOrderItems = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrderItems.RemovePatientOrderItem.sql");
        //            public  readonly string RestorePatientOrderItems = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrderItems.RestorePatientOrderItem.sql");
        //            public  readonly string UpsertPatientOrderItemDiagnosis = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrderItems.UpsertPatientOrderItemDiagnosis.sql");
        //            public  readonly string UpsertPatientOrderItemModifier = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrderItems.UpsertPatientOrderItemModifier.sql");
        //            public  readonly string CreatePatientOrderItemChange = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrderItems.CreatePatientOrderItemChange.sql");
        //            public  readonly string GetPatientOrderItemChanges = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrderItems.GetPatientOrderItemChanges.sql");
        //            public  readonly string SearchPatientOrderItemChanges = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientOrderItems.SearchPatientOrderItemChanges.sql");
        //        }

        internal class PatientAssessmentAllergyScripts
        {
            public string UpsertPatientAssessmentAllergy { get; private set; }
            public string RetrievePatientAssessmentAllergies { get; private set; }
            public string RetrievePatientAssessmentAllergy { get; private set; }
            public string CreatePatientAssessmentAllergyChange { get; private set; }
            public string RetrievePatientAssessmentAllergyChanges { get; private set; }
            public PatientAssessmentAllergyScripts(string providerFolder)
            {
                UpsertPatientAssessmentAllergy = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessmentAllergies.UpsertPatientAssessmentAllergy.sql");
                RetrievePatientAssessmentAllergies = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessmentAllergies.RetrievePatientAssessmentAllergies.sql");
                RetrievePatientAssessmentAllergy = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessmentAllergies.RetrievePatientAssessmentAllergy.sql");
                CreatePatientAssessmentAllergyChange = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessmentAllergies.CreatePatientAssessmentAllergyChange.sql");
                RetrievePatientAssessmentAllergyChanges = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessmentAllergies.RetrievePatientAssessmentAllergyChanges.sql");
            }
        }

        internal class PatientAssessmentMedicationProfileScripts
        {
            public string UpsertPatientAssessmentMedicationProfile { get; private set; }
            public string RetrievePatientAssessmentMedicationProfiles { get; private set; }
            public string RetrievePatientAssessmentMedicationProfile { get; private set; }
            public string CreatePatientAssessmentMedicationProfileChange { get; private set; }
            public string RetrievePatientAssessmentMedicationProfileChanges { get; private set; }

            public PatientAssessmentMedicationProfileScripts(string providerFolder)
            {
                UpsertPatientAssessmentMedicationProfile = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessmentMedicationProfiles.UpsertPatientAssessmentMedicationProfile.sql");
                RetrievePatientAssessmentMedicationProfiles = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessmentMedicationProfiles.RetrievePatientAssessmentMedicationProfiles.sql");
                RetrievePatientAssessmentMedicationProfile = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessmentMedicationProfiles.RetrievePatientAssessmentMedicationProfile.sql");
                CreatePatientAssessmentMedicationProfileChange = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessmentMedicationProfiles.CreatePatientAssessmentMedicationProfileChange.sql");
                RetrievePatientAssessmentMedicationProfileChanges = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessmentMedicationProfiles.RetrievePatientAssessmentMedicationProfileChanges.sql");
            }
        }

        internal class PatientAssessmentDiagnosisScripts
        {
            public string UpsertPatientAssessmentDiagnosis { get; private set; }
            public string RetrievePatientAssessmentDiagnoses { get; private set; }
            public string RetrievePatientAssessmentDiagnosis { get; private set; }
            public string CreatePatientAssessmentDiagnosisChange { get; private set; }
            public string RetrievePatientAssessmentDiagnosisChanges { get; private set; }
            public PatientAssessmentDiagnosisScripts(string providerFolder)
            {
                UpsertPatientAssessmentDiagnosis = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessmentDiagnoses.UpsertPatientAssessmentDiagnosis.sql");
                RetrievePatientAssessmentDiagnoses = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessmentDiagnoses.RetrievePatientAssessmentDiagnoses.sql");
                RetrievePatientAssessmentDiagnosis = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessmentDiagnoses.RetrievePatientAssessmentDiagnosis.sql");
                CreatePatientAssessmentDiagnosisChange = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessmentDiagnoses.CreatePatientAssessmentDiagnosisChange.sql");
                RetrievePatientAssessmentDiagnosisChanges = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessmentDiagnoses.RetrievePatientAssessmentDiagnosisChanges.sql");
            }
        }

        internal class PatientAssessmentDemographicsScripts
        {
            public string GetPatientDemographicsSnapshots { get; private set; } 
            public string CreatePatientDemographicsSnapshots { get; private set; }
            public string GetPatientDemographicsContactSnapshots { get; private set; }
            public string CreatePatientDemographicsContactSnapshots { get; private set; }
            public PatientAssessmentDemographicsScripts(string providerFolder)
            {
                GetPatientDemographicsSnapshots = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.GetPatientDemographicsSnapshots.sql");
                CreatePatientDemographicsSnapshots = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.CreatePatientDemographicsSnapshots.sql");
                GetPatientDemographicsContactSnapshots = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.GetPatientDemographicsContactSnapshots.sql");
                CreatePatientDemographicsContactSnapshots = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAssessment.CreatePatientDemographicsContactSnapshots.sql");
            }
        }

        //        internal  class PatientStatistic
        //        {
        //            public  readonly string SearchPatientStatistics = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientStatistic.SearchPatientStatistics.sql");
        //            public  readonly string GetPatientStatistics = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientStatistic.GetPatientStatistics.sql");
        //            public  readonly string CreatePatientStatistic = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientStatistic.CreatePatientStatistic.sql");
        //        }
        //
        //        internal  class PatientCarePlan
        //        {
        //            public  readonly string GetPatientCarePlans = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientCarePlan.GetPatientCarePlans.sql");
        //            public  readonly string GetPatientCarePlan = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientCarePlan.GetPatientCarePlan.sql");
        //            public  readonly string GetAllPatientCarePlans = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientCarePlan.GetAllPatientCarePlans.sql");
        //            public  readonly string RemovePatientCarePlan = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientCarePlan.RemovePatientCarePlan.sql");
        //            public  readonly string UpsertPatientCarePlan = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientCarePlan.UpsertPatientCarePlan.sql");
        //        }
        //
        //        internal  class PatientCarePlanReview
        //        {
        //            public  readonly string CreatePatientCarePlanReview = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientCarePlan.CreatePatientCarePlanReview.sql");
        //            public  readonly string GetPatientCarePlanReviewDetailsByPatient = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientCarePlan.GetPatientCarePlanReviewDetailsByPatient.sql");
        //            public  readonly string GetPatientCarePlanReviewDetailsByPatientCarePlan = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientCarePlan.GetPatientCarePlanReviewDetailsByPatientCarePlan.sql");
        //            public  readonly string UpsertPatientCarePlanReview = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientCarePlan.UpsertPatientCarePlanReview.sql");
        //            public  readonly string RemovePatientCarePlanReviews = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientCarePlan.RemovePatientCarePlanReviews.sql");
        //
        //        }
        //
        //        internal  class PatientAlert
        //        {
        //            public  readonly string CreatePatientAlert = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAlert.CreatePatientAlert.sql");
        //            public  readonly string GetPatientAlerts = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAlert.GetPatientAlerts.sql");
        //            public  readonly string UpdatePatientAlert = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAlert.UpdatePatientAlert.sql");
        //            public  readonly string RemovePatientAlert = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAlert.RemovePatientAlert.sql");
        //            public  readonly string RestorePatientAlert = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAlert.RestorePatientAlert.sql");
        //            public  readonly string SearchPatientAlert = EmbeddedResource.GetQueryScript($"{providerFolder}.PatientAlert.SearchPatientAlert.sql");
        //        }
    }
}
