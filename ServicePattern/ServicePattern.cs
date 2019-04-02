using DataMap.Infrastructure;
using ServicePattern;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServicePattern
{
    public class ServicePattern<T> : IServicePattern<T> where T : class
    {
        #region Private Fields
        IUnitOfWork utwk;
        #endregion Private Fields
        #region Constructor
        public ServicePattern(IUnitOfWork utwk)
        {
            this.utwk = utwk;
        }

        #endregion Constructor
        public virtual void Add(T entity)
        {
            ////_repository.Add(entity);
            utwk.getRepository<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            //_repository.Update(entity);
            utwk.getRepository<T>().Update(entity);
        }

        public virtual void Delete(T entity)
        {
            //   _repository.Delete(entity);
            utwk.getRepository<T>().Delete(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            // _repository.Delete(where);
            utwk.getRepository<T>().Delete(where);
        }

        public virtual T GetById(long id)
        {
            //  return _repository.GetById(id);
            return utwk.getRepository<T>().GetById(id);
        }

        public virtual T GetById(string id)
        {
            //return _repository.GetById(id);
            return utwk.getRepository<T>().GetById(id);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> filter = null, Expression<Func<T, bool>> orderBy = null)
        {
            //  return _repository.GetAll();
            return utwk.getRepository<T>().GetMany(filter, orderBy);
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            //return _repository.Get(where);
            return utwk.getRepository<T>().Get(where);
        }


        public virtual IEnumerable<T> GetAll()
        {
            return utwk.getRepository<T>().GetAll();
        }



        public void Commit()
        {
            try
            {
                utwk.Commit();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

  

        public void Dispose()
        {
            utwk.Dispose();
        }

      
    }
}
