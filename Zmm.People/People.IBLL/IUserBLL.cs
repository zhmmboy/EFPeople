using People.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.IBLL
{
    public interface IUserBLL : IBaseBLL<P_User>
    {
        bool Exists(string userName);

        P_User GetSingle(string uId);

        P_User GetSingleByName(string userName);

        IQueryable<P_User> GetList(int pageIndex, int pageSize, out int totalRecord, int order);
    }
}
