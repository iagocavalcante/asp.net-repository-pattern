using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public class Repositorio<T> : IReposotorio<T>, IDisposable where T : class
    {
        private UsuarioContexto Context;

        protected Repositorio()
        {
            Context = new UsuarioContexto();
        }

        public void Adicionar(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Atualizar(T entity)
        {
            Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Deletar(Func<T, bool> predicate)
        {
            Context.Set<T>()
                .Where(predicate).ToList()
                .ForEach(del => Context.Set<T>().Remove(del));
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetTodos()
        {
            return Context.Set<T>();
        }

        public T Primeiro(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public T Procurar(params object[] key)
        {
            return Context.Set<T>().Find(key);
        }
    }
}
