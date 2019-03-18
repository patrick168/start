using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DBManage.Models
{
    public class tMember
    {
        [DisplayName("ID")]
        [Required]
        [Key]
        public int fId { get; set; }

        [DisplayName("使用者帳號")]
        [Required]
        public string fUserId { get; set; }

        [DisplayName("登入密碼")]
        [Required]
        public string fPwd { get; set; }

        [DisplayName("姓名")]
        [Required]
        public string fName { get; set; }

        [DisplayName("E-mail")]
        [Required]
        public string fEmail { get; set; }

        [DisplayName("地址")]
        public string fAddress { get; set; }

        [DisplayName("電話")]
        public string fPhone { get; set; }

        //[DisplayName("備註")]
        //public string PS { get; set; }
    }
}