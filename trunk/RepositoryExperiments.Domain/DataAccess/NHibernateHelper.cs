using NHibernate;

namespace RepositoryExperiments.Domain.DataAccess
{
    public static class NHibernateHelper
    {
        private static ISessionProvider sessionProvider;
        private static IStateHolder stateHolder;
        private const string sessionKey = "nhibernate.current.session";

        public static void Initialize(ISessionProvider aSessionFactory, IStateHolder aStateHolder)
        {
            sessionProvider = aSessionFactory;
            stateHolder = aStateHolder;
        }

        public static ISession GetCurrentSession()
        {
            if (stateHolder[sessionKey] == null)
                stateHolder[sessionKey] = sessionProvider.CreateNewSession();
            return (ISession) stateHolder[sessionKey];
        }

        public static void BeginTransaction()
        {
            GetCurrentSession().BeginTransaction();
        }

        public static void CommitTransaction()
        {
            GetCurrentSession().Transaction.Commit();
            stateHolder[sessionKey] = null;
        }

        public static void RollbackTransaction()
        {
            GetCurrentSession().Transaction.Rollback();
            stateHolder[sessionKey] = null;
        }
    }
}