using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace People.IDAL
{
    /// <summary>
    /// 数据库访问层接口,定义公用的操作数据库的方法
    /// </summary>
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// 新增一条记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        T Add(T t);

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Update(T t);

        /// <summary>
        /// 删除一条记录（按实体对象）
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Delete(T t);

        /// <summary>
        /// 删除一条记录（按主键）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// 查询符合条件的记录数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 查询记录是否存
        /// </summary>
        /// <param name="anyLambda"></param>
        /// <returns></returns>
        bool Exists(Expression<Func<T, bool>> anyLambda);

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        T GetSingle(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 获取一个数据集合
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <param name="isAsc"></param>
        /// <param name="orderLambda"></param>
        /// <returns></returns>
        IQueryable<T> GetList<S>(Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderLambda);

        /// <summary>
        /// 分页获取数据集合
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <param name="isAsc"></param>
        /// <param name="orderLambda"></param>
        /// <returns></returns>
        IQueryable<T> GetPage<S>(int PageIndex, int pageSize,out int totalRecord, Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderLambda);
    }
}
