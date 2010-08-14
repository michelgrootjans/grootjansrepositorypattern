using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace RepositoryExperiments.Domain.DataAccess
{
    public class SQLiteInMemorySessionFactory : ISessionProvider
    {
        private readonly ISessionFactory sessionFactory;
        private readonly Configuration configuration;

        public SQLiteInMemorySessionFactory(Configuration configuration)
        {
            this.configuration = configuration;
            sessionFactory = configuration.BuildSessionFactory();
        }

        public ISession CreateNewSession()
        {
            var session = sessionFactory.OpenSession();
            var connection = session.Connection;
            new SchemaExport(configuration).Execute(false, true, false, connection, null);
            return session;
        }
    }
}