using People.IDAL;
using People.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace People.DAL
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        //定义一个全局上下文对象
        protected PeopleDBContext dbContext = new PeopleDBContext();


        public T Add(T t)
        {
            dbContext.Entry<T>(t).State = System.Data.Entity.EntityState.Added;
            dbContext.SaveChanges();

            return t;
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().Count(predicate);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T t)
        {
            dbContext.Set<T>().Attach(t);
            dbContext.Entry<T>(t).State = System.Data.Entity.EntityState.Deleted;

            return dbContext.SaveChanges() > 0;
        }

        public bool Exists(Expression<Func<T, bool>> anyLambda)
        {
            return dbContext.Set<T>().Any(anyLambda);
        }

        public IQueryable<T> GetList<S>(Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T,S>> orderLambda)
        {
            var lst = dbContext.Set<T>().Where(whereLambda);
            if (isAsc)
                lst = lst.OrderBy<T, S>(orderLambda);
            else
                lst = lst.OrderByDescending<T, S>(orderLambda);

            return lst;
        }

        public IQueryable<T> GetPage<S>(int PageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderLambda)
        {
            var lst = dbContext.Set<T>().Where(whereLambda);
            //获取总记录数
            totalRecord = lst.Count();

            if (isAsc)
                lst = lst.OrderBy<T, S>(orderLambda).Skip<T>((PageIndex - 1) * pageSize).Take<T>(pageSize);
            else
                lst = lst.OrderByDescending<T, S>(orderLambda).Skip<T>((PageIndex - 1) * pageSize).Take<T>(pageSize);

            return lst;
        }

        public T GetSingle(Expression<Func<T, bool>> whereLambda)
        {
            return dbContext.Set<T>().Where(whereLambda).FirstOrDefault();
        }

        public bool Update(T t)
        {
            dbContext.Set<T>().Attach(t);
            dbContext.Entry<T>(t).State = System.Data.Entity.EntityState.Modified;
            return dbContext.SaveChanges() > 0;
        }
    }
}
