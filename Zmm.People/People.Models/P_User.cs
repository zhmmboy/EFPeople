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
        public System.Guid uId { get; set; }

        [Required(ErrorMessage = "用户名必填。")]
        [StringLength(20,MinimumLength =6,ErrorMessage ="必须为 {1} 到 {0} 个字符。")]
        [Display(Name ="用户名")]
        public string uName { get; set; }

        [Required(ErrorMessage ="登录密码必填。")]
        [StringLength(15,MinimumLength =6,ErrorMessage ="必须为 {1} 到 {0} 个字符。")]
        [Display(Name ="登录密码")]
        [DataType(DataType.Password)]
        public string uPwd { get; set; }

        [Display(Name ="用户头像")]
        public string uPhoto { get; set; }
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
