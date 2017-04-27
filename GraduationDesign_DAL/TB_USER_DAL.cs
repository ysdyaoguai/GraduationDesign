using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduationDesign_Model;
using System.Data;
using System.Data.SqlClient;

namespace GraduationDesign_DAL
{
    public class TB_USER_DAL
    {
        /// <summary>
        /// 返回用户列表
        /// </summary>
        /// <returns></returns>
        public List<TB_USER> GetList()
        {
            string sql = "select * from TB_USER";
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text);
            List<TB_USER> list = null;
            if (da.Rows.Count > 0)
            {
                list = new List<TB_USER>();
                TB_USER tb_user = null;
                foreach (DataRow row in da.Rows)
                {
                    tb_user = new TB_USER();
                    LoadEntity(row, tb_user);
                    list.Add(tb_user);
                }
            }
            return list;
        }


        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="tb_user"></param>
        /// <returns></returns>
        public int AddTbUser(TB_USER tb_user)
        {
            string sql = "insert into TB_USER (user_id, user_name, user_type, user_pwd, user_reg_time) values (@user_id, @user_name, @user_type, @user_pwd, @user_reg_time)";
            SqlParameter[] pars = {
                new SqlParameter("@user_id", SqlDbType.NVarChar, 4),
                new SqlParameter("@user_name", SqlDbType.NVarChar, 50),
                new SqlParameter("@user_type", SqlDbType.NVarChar, 50),
                new SqlParameter("@user_pwd", SqlDbType.NVarChar, 50),
                new SqlParameter("@user_reg_time", SqlDbType.NVarChar, 32),
            };

            pars[0].Value = tb_user.UserID;
            pars[1].Value = tb_user.UserName;
            pars[2].Value = tb_user.UserType;
            pars[3].Value = tb_user.UserPwd;
            pars[4].Value = tb_user.UserRegTime;

            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }

        /// <summary>
        /// 根据编号删除用户记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteTbUserModel(int user_id)
        {
            string sql = "delete from TB_USER where user_id=@user_id";
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, new SqlParameter("@user_id", user_id));
        }


        /// <summary>
        /// 根据用户ID查找用户信息
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public TB_USER GetTbUserModel(int user_id)
        {
            string sql = "select * from TB_USER where user_id = @user_id";
            TB_USER tb_user = null;
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, new System.Data.SqlClient.SqlParameter("@user_id", user_id));
            if (da.Rows.Count > 0)
            {
                tb_user = new TB_USER();
                LoadEntity(da.Rows[0], tb_user);
            }
            return tb_user;
        }


        /// <summary>
        /// 根据用户名查找用户信息
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        public TB_USER GetTbUserModel(string user_name)
        {
            string sql = "select * from TB_USER where user_name = @user_name";
            TB_USER tb_user = null;
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, new System.Data.SqlClient.SqlParameter("@user_name", user_name));
            if (da.Rows.Count > 0)
            {
                tb_user = new TB_USER();
                LoadEntity(da.Rows[0], tb_user);
            }
            return tb_user;
        }

        /// <summary>
        /// 更新用户数据
        /// </summary>
        /// <param name="tb_user"></param>
        /// <returns></returns>
        public int EditTbUserModel(TB_USER tb_user)
        {
            string sql = "update TB_USER set user_name=@user_name,user_type=@user_type,user_pwd=@user_pwd,user_reg_time=@user_reg_time where user_id=@user_id";
            SqlParameter[] pars = {
                new SqlParameter("@user_name", SqlDbType.NVarChar, 50),
                new SqlParameter("@user_type", SqlDbType.NVarChar, 50),
                new SqlParameter("@user_pwd", SqlDbType.NVarChar, 50),
                new SqlParameter("@user_reg_time", SqlDbType.NVarChar, 32),
                new SqlParameter("@user_id", SqlDbType.NVarChar, 4),
                                 };

            pars[0].Value = tb_user.UserName;
            pars[1].Value = tb_user.UserType;
            pars[2].Value = tb_user.UserPwd;
            pars[3].Value = tb_user.UserRegTime;
            pars[4].Value = tb_user.UserID;
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }


        /// <summary>
        /// 获取总的记录数
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            string sql = "select count(*) from TB_USER";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(sql, CommandType.Text));
        }


        /// <summary>
        /// 获取指定范围的数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<TB_USER> GetPageList(int start, int end)
        {
            string sql = "select * from(select *,row_number() over(order by user_id) as num from TB_USER)as t where num>=@start and num<=@end";
            SqlParameter[] pars ={
            new SqlParameter("@start",start),
               new SqlParameter("@end",end)
           };
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, pars);
            List<TB_USER> list = null;
            if (da.Rows.Count > 0)
            {
                list = new List<TB_USER>();
                TB_USER tb_user = null;
                foreach (DataRow row in da.Rows)
                {
                    tb_user = new TB_USER();
                    LoadEntity(row, tb_user);
                    list.Add(tb_user);

                }
            }
            return list;
        }




        /// <summary>
        /// 根据行号给属性赋值
        /// </summary>
        /// <param name="row"></param>
        /// <param name="tb_score"></param>
        private void LoadEntity(DataRow row, TB_USER tb_user)
        {
            tb_user.UserName = row["user_name"] != DBNull.Value ? row["user_name"].ToString() : string.Empty;
            tb_user.UserType = row["user_type"] != DBNull.Value ? row["user_type"].ToString() : string.Empty;
            tb_user.UserPwd = row["user_pwd"] != DBNull.Value ? row["user_pwd"].ToString() : string.Empty;
            tb_user.UserID = row["user_id"] != DBNull.Value ? Convert.ToInt32(row["user_id"]) : Int32.MinValue;
            tb_user.UserRegTime = row["user_reg_time"] != DBNull.Value ? Convert.ToDateTime(row["user_reg_time"]) : DateTime.MinValue;

        }
    }
}
