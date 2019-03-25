using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.IBLL
{
    public interface IBaseBLL<T> where T : class
    {

        T Add(T t);

        bool Update(T t);

        bool Delete(T t);

    }
}
