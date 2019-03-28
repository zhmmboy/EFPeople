using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace People.WebUI.App_Code
{
    public class CommonClass
    {

    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field,AllowMultiple =false)]
    public class DomainAttribute : ValidationAttribute
    {
        public IEnumerable<string> Values { get; private set; }


        public DomainAttribute(string val)
        {
            this.Values = new string[] { val };
        }
        public DomainAttribute(string[] values)
        {
            this.Values = values;
        }

        public override bool IsValid(object value)
        {
            if (null == value)
            {
                return true;
            }

            return this.Values.Any(item => value.ToString() == item);
        }

        public override string FormatErrorMessage(string name)
        {
            string[] values = this.Values.Select(value => string.Format("'{0}'", value)).ToArray();
            return string.Format(base.ErrorMessageString, name, string.Join(",", values));
        }
    }

    public class RangeAttribute:ValidationAttribute
    {
        public IEnumerable<string> Values { get; private set; }
             
        public RangeAttribute(string val)
        {
            this.Values = new string[] { val };
        }

        public RangeAttribute(params string[] arrVal)
        {
            this.Values = arrVal;
        }

        public override bool IsValid(object value)
        {
            if (null == value)
            {
                return true;
            }

            return this.Values.Any(item => value.ToString() == item);
        }
    }

}