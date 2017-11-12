using System.Collections.Generic;
using DataAccess;

namespace Services
{
    /// <summary>
    /// Classe para o programador não precisar a todo momento criar nos serviços método como all, get, save etc..
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Service<T> : Service where T : class
    {
        public Service(MainContext context)
            : base(context)
        {
        }

        public Service()
            : base()
        {
        }

        /// <summary>
        /// Retorna todos os regristros
        /// </summary>
        /// <returns>Um item da entidade</returns>
        public IEnumerable<T> All()
        {
            return this.context.Set<T>();
        }

        /// <summary>
        /// Salva um item
        /// </summary>
        /// <param name="item">Item da entidade</param>
        public void Save(T item)
        {
            this.context.Set<T>().Add(item);
            base.Save();
        }

        /// <summary>
        /// Salva vários items
        /// </summary>
        /// <param name="items">Coleção de itens da entidade</param>
        public void Save(IEnumerable<T> items)
        {
            this.context.Set<T>().AddRange(items);
            base.Save();
        }

        public void Update(T item)
        {
            this.context.Set<T>().Attach(item);
            this.context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            base.Save();
        }

        /// <summary>
        /// Deleta um item da entidade
        /// </summary>
        /// <param name="item">Item da entidade</param>
        public void Delete(object id)
        {
            var item = this.Get(id);
            this.context.Set<T>().Remove(item);
            base.Save();
        }

        /// <summary>
        /// Retorna um item pela chave
        /// </summary>
        /// <param name="id">Chave</param>
        /// <returns>Item da entidae</returns>
        public T Get(object id)
        {
            return base.context.Set<T>().Find(id);
        }

        #region Primary Types Validations

        public static bool IsValid(string item)
        {
            return !string.IsNullOrEmpty(item);
        }

        #endregion
    }
}
