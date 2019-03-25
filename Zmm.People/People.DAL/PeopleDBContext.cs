using People.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.DAL
{
    /// <summary>
    /// 创建上下文对象
    /// </summary>
    public class PeopleDBContext:DbContext
    {
        public DbSet<P_User> Users { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PeopleDBContext():base("DefaultConnection")
        {

        }
    }
}
