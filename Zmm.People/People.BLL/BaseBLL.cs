using People.IBLL;
using People.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.BLL
{
    public abstract class BaseBLL<T> : IBaseBLL<T> where T : class
    {
        protected IBaseRepository<T> CurrentRepositoty { get; set; }

        public BaseBLL(IBaseRepository<T> baseRepository)
        {
            CurrentRepositoty = baseRepository;
        }

        public T Add(T t)
        {

            return CurrentRepositoty.Add(t);
        }

        public bool Update(T t)
        {
            return CurrentRepositoty.Update(t);
        }

        public bool Delete(T t)
        {
            return CurrentRepositoty.Delete(t);
        }
    }
}
