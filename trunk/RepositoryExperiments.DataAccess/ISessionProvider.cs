using NHibernate;

namespace RepositoryExperiments.DataAccess
{
    public interface ISessionProvider
    {
        ISession CreateNewSession();
    }
}