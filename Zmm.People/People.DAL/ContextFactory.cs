using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace People.DAL
{
    public class ContextFactory
    {

        public static PeopleDBContext GetDBContext()
        {
            PeopleDBContext db = CallContext.GetData("peopleDbContext") as PeopleDBContext;
            if (db == null)
            {
                db = new PeopleDBContext();
                CallContext.SetData("peopleDbContext", db);
            }

            return db;
        }
    }
}
