using People.DAL;
using People.IBLL;
using People.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.BLL
{
    public class UserBLL : BaseBLL<P_User>, IUserBLL
    {
        public UserBLL() : base(RepositoryFactory.UserReposistory)
        {

        }

        public bool Exists(string userName)
        {
            return CurrentRepositoty.Exists(u => u.uPhone == userName);
        }

        public IQueryable<P_User> GetList(int pageIndex, int pageSize, out int totalRecord, int order)
        {
            return CurrentRepositoty.GetPage(pageIndex, pageSize, out totalRecord, u => true, true, u => u.uId);
        }

        public P_User GetSingle(string uId)
        {
            Guid id = Guid.Parse(uId);
            return CurrentRepositoty.GetSingle(u => u.uId == id);
        }

        public P_User GetSingleByName(string userName)
        {
            return CurrentRepositoty.GetSingle(u => u.uName == userName);
        }
    }
}
