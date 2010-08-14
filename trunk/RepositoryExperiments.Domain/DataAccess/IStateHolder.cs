namespace RepositoryExperiments.Domain.DataAccess
{
    public interface IStateHolder
    {
        object this[string key] { get; set; }
    }
}