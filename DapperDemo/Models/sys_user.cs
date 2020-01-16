using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DapperDemo.Models
{
    public class sys_user
    {
        [DisplayName("用户主键")]
        public Guid user_id { get; set; }
        [DisplayName("登录名称")]
        public string u_id { get; set; }
        [DisplayName("登录密码")]
        public string u_password { get; set; }
        [DisplayName("性别")]
        public string gender { get; set; }
        [DisplayName("姓名")]
        public string user_name { get; set; }
        [DisplayName("创建时间")]
        public string creation_time { get; set; }
        [DisplayName("状态")]
        public string status { get; set; }
    }
}