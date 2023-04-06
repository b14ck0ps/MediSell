using System.Collections.Generic;

namespace DAL.Interface
{
    public interface IReopsitory<T, in TId, out TRet>
    {
        TRet Add(T entity);
        TRet Update(T entity);
        TRet Delete(T entity);
        T GetById(TId id);
        List<T> GetAll();
    }
}