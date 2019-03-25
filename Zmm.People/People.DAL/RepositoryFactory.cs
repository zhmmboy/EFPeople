using People.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.DAL
{
    public static class RepositoryFactory
    {
        public static IUserRepository UserReposistory { get { return new UserRepository(); } }
    }
}
