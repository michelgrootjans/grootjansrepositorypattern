using NHibernate;

namespace RepositoryExperiments.Domain.DataAccess
{
    public interface ISessionProvider
    {
        ISession CreateNewSession();
    }
}