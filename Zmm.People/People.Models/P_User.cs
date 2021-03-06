//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace People.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;
    using ValidateHelper;
    /// <summary>
    /// 
    /// Created by:zmm 2019/03/22
    /// 
    /// </summary>
    public partial class P_User
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Guid uId { get; set; }

        //[Required(ErrorMessage = "用户名必填。")]
        //[StringLength(20, MinimumLength = 6, ErrorMessage = "必须为 {2} 到 {1} 个字符。")]
        //[Display(Name = "用户名")]
        //[Remote("ExistsUsername", "Home", AdditionalFields = "uProvince")]
        public string uName { get; set; }
        //[Required(ErrorMessage = "登录密码必填。")]
        //[StringLength(15, MinimumLength = 6, ErrorMessage = "必须为 {1} 到 {0} 个字符。")]
        //[Display(Name = "登录密码")]
        //[DataType(DataType.Password)]
        public string uPwd { get; set; }
        [Display(Name = "用户头像")]
        public string uPhoto { get; set; }
        [Display(Name = "年龄")]
        public Nullable<int> uAge { get; set; }
        [Display(Name = "性别")]
        [Domain(new string[] { "M", "F", "T", "W" }, ErrorMessageResourceName = "Domain", ErrorMessageResourceType = typeof(Resources))]
        [Required]
        public Nullable<bool> uSex { get; set; }
        [Display(Name = "移动电话")]
        //[RegularExpression(@"^[1]+[3,5]+\d{9}", ErrorMessage = "移动电话号码错误.")]
        //[Required(ErrorMessage = "{0}不能为空.")]
        public string uMobile { get; set; }
        [Display(Name = "固定电话")]
        //[Required, DataType(DataType.PhoneNumber)]
        public string uPhone { get; set; }
        [Display(Name = "所在省份")]
        public string uProvince { get; set; }
        [Display(Name = "所在城市")]
        public string uCity { get; set; }
        [Display(Name = "邮编")]
        //[Required(ErrorMessageResourceName ="Required",ErrorMessageResourceType =typeof(Resources))]
        public string uZipCode { get; set; }
        [Display(Name = "地址")]
        public string uAddr { get; set; }
        [Display(Name = "最后登录地址")]
        public Nullable<System.DateTime> uLoginTime { get; set; }
    }
}
