using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NUnit.Framework;
using RepositoryExperiments.Domain.DataAccess;
using RepositoryExperiments.Domain.Entities;

namespace RepositoryExperiments.UnitTests
{
    [TestFixture]
    public abstract class InMemoryDataAccessTest
    {
        protected IRepository repository;
        private ISession session;

        static InMemoryDataAccessTest()
        {
            var configuration = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.InMemory)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Customer>())
                .BuildConfiguration();

            NHibernateHelper.Initialize(new SQLiteInMemorySessionFactory(configuration),
                                        new StaticStateHolder());
        }

        [SetUp]
        public void SetUp()
        {
            NHibernateHelper.BeginTransaction();

            session = NHibernateHelper.GetCurrentSession();
            repository = new NHibernateRepository();
            PrepareData();
            FlushAndClear();
        }

        protected abstract void PrepareData();

        protected void FlushAndClear()
        {
            session.Flush();
            session.Clear();
        }

        [TearDown]
        public void TearDown()
        {
            NHibernateHelper.RollbackTransaction();
        }
    }
}