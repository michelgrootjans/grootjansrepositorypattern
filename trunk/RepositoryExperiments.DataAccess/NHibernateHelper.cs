using System.Collections.Generic;
using NHibernate;

namespace RepositoryExperiments.DataAccess
{
    public static class NHibernateHelper
    {
        private static ISessionProvider sessionProvider;
        private static IDictionary<string, object> stateHolder;
        private const string sessionKey = "nhibernate.current.session";

        public static void Initialize(ISessionProvider aSessionFactory, IDictionary<string, object> aStateHolder)
        {
            sessionProvider = aSessionFactory;
            stateHolder = aStateHolder;
        }

        public static ISession GetCurrentSession()
        {
            if (!stateHolder.ContainsKey(sessionKey))
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
        }

        public static void RollbackTransaction()
        {
            GetCurrentSession().Transaction.Rollback();
        }
    }
}