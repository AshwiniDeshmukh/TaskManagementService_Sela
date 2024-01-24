using PAC.Services.Framework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using WCTS.PatientService.Repositories.Impl.Entities;
using WCTS.Services.Framework.Data.RepositoryUtility;

namespace WCTS.PatientService.Repositories.Impl.Delegates.Patient
{
    internal class SearchUserTasksDelegate : QueryCallDelegate<IEnumerable<PatientSummaryEntity>>
    {
        private readonly IEnumerable<Guid> _patientKeys;

        public SearchUserTasksDelegate(QueryScripts queryScripts, IEnumerable<Guid> patientKeys)
            : base(queryScripts.Patient.GetPatients)
        {
            _patientKeys = patientKeys;
        }

        public override object GetParameters(IQueryRequestContext context)
        {
            return new
            {
                PatientKeys = _patientKeys.ToList(),
                PatientKeysAsCsv = CsvUtility.Make_CSVString(_patientKeys)
            };
        }
    }
}
