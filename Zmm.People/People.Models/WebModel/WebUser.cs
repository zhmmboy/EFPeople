using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace People.Models.WebModel
{
    public class WebUser
    {
        public System.Guid uId { get; set; }
        public string uName { get; set; }
        public string uPwd { get; set; }
        public HttpPostedFileBase uPhoto { get; set; }
        public Nullable<int> uAge { get; set; }
        public Nullable<bool> uSex { get; set; }
        public string uMobile { get; set; }
        public string uPhone { get; set; }
        public string uProvince { get; set; }
        public string uCity { get; set; }
        public string uZipCode { get; set; }
        public string uAddr { get; set; }
        public Nullable<System.DateTime> uLoginTime { get; set; }

    }
}
