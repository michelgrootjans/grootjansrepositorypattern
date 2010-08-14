using System.Collections.Generic;
using NHibernate;

namespace RepositoryExperiments.Domain.DataAccess
{
    public interface IRepository
    {
        void Add<T>(T entity);
        void Remove<T>(T entity);
        IQueryResult<T> Query<T>(IQuery<T> query);
    }

    public interface IQuery<T>
    {
        IQueryResult<T> Execute(ISession session);
    }

    public interface IQueryResult<T>
    {
        T UniqueResult();
        IEnumerable<T> List();
    }
}