
namespace WCTS.PatientService.Repositories.Impl
{
    internal class RepositoryBase : BaseRepository
    {
        // Use the class name as the instance name, so we don't have to rename the code in the repos
        public QueryScripts QueryScripts { get; private set; }



        /// <summary>
        /// 2023-06-27 :
        /// Here at the PatientService we use the CallFactory in all of our repos.
        /// We need a constructor that creates a real call factory.
        /// Other examples had the FakeCallFactory in here becouse they dont use CallFactory (ex: WorldpayService).
        /// </summary>
        protected RepositoryBase(IQueryCallFactory queryCallFactory, IDatabase database)
            : base(queryCallFactory)
        {
            Initialize(database);
        }

        private void Initialize(IDatabase database)
        {
            // the db knows its provider type
            var dataProviderType = database.ConnectionFactory().DataProvider;

            // Use the class name as in the instance name to avoid re-naming the calls in the Repositories
            QueryScripts = new QueryScripts(dataProviderType);
        }

    }
}
