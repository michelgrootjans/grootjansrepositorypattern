using System;

namespace RepositoryExperiments.Domain.Entities
{
    public class Entity
    {
        private Guid id;
        public virtual Guid Id
        {
            get { return id; }
        }
    }
}