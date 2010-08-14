using System.Collections.Generic;

namespace RepositoryExperiments.Domain.DataAccess
{
    public class StaticStateHolder : IStateHolder
    {
        private readonly IDictionary<string, object> dictionary = new Dictionary<string, object>();

        public object this[string key]
        {
            get { return dictionary.ContainsKey(key) ? dictionary[key] : null; }
            set { dictionary[key] = value; }
        }
    }
}