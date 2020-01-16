using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using DapperDemo.Models;

namespace DapperDemo.Controllers
{
    public class DefaultController : ApiController
    {
        private static string connstr_sqlserver = ConfigurationManager.ConnectionStrings["lc"].ToString();

        //查询
        [HttpGet]
        public IEnumerable<sys_user> select()
        {
            using (IDbConnection conn=new SqlConnection(connstr_sqlserver))
            {
                //查询语句
                string sql=@"select * from sys_user";
                var u = conn.Query<sys_user>(sql).ToList();
                return u;
            }
        }
        //新增
        [HttpPost]
        public int Insert([FromBody]sys_user s)
        {
            int retule = 0;
            using (IDbConnection conn=new SqlConnection(connstr_sqlserver))
            {
                string sql = @"insert into sys_user(user_id,u_id,u_password,gender,user_name,status)";
                sql += "values (newid(),@u_id,@u_password,@gender,@user_name,@status)";
                retule = conn.Execute(sql, s);
            }
            return retule;
        }
        //根据ID查询
        [HttpPost]
        public IEnumerable<sys_user> SelectByID(sys_user u)
        {
            using (IDbConnection conn=new SqlConnection(connstr_sqlserver))
            {
                string sql = "select * from sys_user where user_id=@user_id";
                //执行dapper中Query（）方法singleOrDefault（）查询数据
                var s = conn.Query<sys_user>(sql, new
                {
                    @user_id = u.user_id
                }).SingleOrDefault();
                List<sys_user> list = new List<sys_user>();
                list.Add(s);
                 return list;
            }
        }
        [HttpPost]
        //修改数据
        public int UpdateUser(sys_user user)
        {
            int reulst = 0;
            using (IDbConnection conn=new SqlConnection(connstr_sqlserver))
            {
                string sql = "update  sys_user  set u_id=@u_id,u_password=@u_password,gender=@gender,user_name=@user_name,status=@status where user_id=@user_id";
                reulst = conn.Execute(sql,user);
            }
            return reulst;
        }
        [HttpPost]
        //删除数据
        public int DelectUser(sys_user user)
        {
            int reulst = 0;
            using (IDbConnection conn=new SqlConnection(connstr_sqlserver))
            {
                string sql = @"Delete sys_user where user_id=@user_id";
                reulst = conn.Execute(sql,new { @user_id=user.user_id});
            }
            return reulst;
        }
    }
}
