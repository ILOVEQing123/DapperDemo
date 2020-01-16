using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DapperDemo.Models
{
    public class sys_product
    {
        [DisplayName("产品主键")]
        public string productid { get; set; }
        [DisplayName("产品名称")]
        public string productname { get; set; }
        [DisplayName("产品描述")]
        public string productDesc { get; set; }
        [DisplayName("用户主键")]
        public string user_id { get; set; }
        //public sys_user_sqlserver userown { get; set; }
        [DisplayName("创建时间")]
        public DateTime CreateTime { get; set; }
    }
}