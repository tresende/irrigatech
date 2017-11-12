using System;
using DataAccess;

namespace Services
{
    public abstract class Service : IDisposable
    {
        protected MainContext context;

        public Service(MainContext context)
        {
            this.context = context;
        }

        public Service()
        {
            this.context = new MainContext();
        }

        public virtual void Dispose()
        {
            this.context = null;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
