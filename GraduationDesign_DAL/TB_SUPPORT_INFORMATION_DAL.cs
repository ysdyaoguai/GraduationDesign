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
    public class TB_SUPPORT_INFORMATION_DAL
    {


        /// <summary>
        /// 返回支撑情况列表
        /// </summary>
        /// <returns></returns>
        public List<TB_SUPPORT_INFORMATION> GetList()
        {
            string sql = "select * from TB_SUPPORT_INFORMATION";
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text);
            List<TB_SUPPORT_INFORMATION> list = null;
            if (da.Rows.Count > 0)
            {
                list = new List<TB_SUPPORT_INFORMATION>();
                TB_SUPPORT_INFORMATION tb_support_information = null;
                foreach (DataRow row in da.Rows)
                {
                    tb_support_information = new TB_SUPPORT_INFORMATION();
                    LoadEntity(row, tb_support_information);
                    list.Add(tb_support_information);
                }
            }
            return list;
        }


        /// <summary>
        /// 添加支撑情况信息
        /// </summary>
        /// <param name="tb_support_information"></param>
        /// <returns></returns>
        public int AddTbSupportInformation(TB_SUPPORT_INFORMATION tb_support_information)
        {
            string sql = "insert into TB_SUPPORT_INFORMATION (id, subject_id, support_point, support_power_inside, edu_activity) values (@id, @subject_id, @support_point, @support_power_inside, @edu_activity)";
            SqlParameter[] pars = {
                new SqlParameter("@id", SqlDbType.NVarChar, 4),
                new SqlParameter("@subject_id", SqlDbType.NVarChar, 4),
                new SqlParameter("@support_point", SqlDbType.NVarChar, 8),
                new SqlParameter("@support_power_inside", SqlDbType.NVarChar, 8),
                new SqlParameter("@edu_activity", SqlDbType.NVarChar, 10),
            };

            pars[0].Value = tb_support_information.id;
            pars[1].Value = tb_support_information.subject_id;
            pars[2].Value = tb_support_information.support_point;
            pars[3].Value = tb_support_information.support_power_inside;
            pars[4].Value = tb_support_information.edu_activity;

            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }

        /// <summary>
        /// 根据编号删除支撑情况记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteTbSupportInformation(int id)
        {
            string sql = "delete from TB_SUPPORT_INFORMATION where id=@id";
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, new SqlParameter("@id", id));
        }


        /// <summary>
        /// 根据ID查找支撑情况信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TB_SUPPORT_INFORMATION GetTbSupportInformationModel(int id)
        {
            string sql = "select * from TB_SUPPORT_INFORMATION where id = @id";
            TB_SUPPORT_INFORMATION tb_support_information = null;
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, new System.Data.SqlClient.SqlParameter("@id", id));
            if (da.Rows.Count > 0)
            {
                tb_support_information = new TB_SUPPORT_INFORMATION();
                LoadEntity(da.Rows[0], tb_support_information);
            }
            return tb_support_information;
        }



        /// <summary>
        /// 更新支撑情况数据
        /// </summary>
        /// <param name="tb_support_information"></param>
        /// <returns></returns>
        public int EditTbSupportInformationModel(TB_SUPPORT_INFORMATION tb_support_information)
        {
            string sql = "update TB_SUPPORT_INFORMATION set subject_id=@subject_id,support_point=@support_point,support_power_inside=@support_power_inside,edu_activity=@edu_activity where id=@id";
            SqlParameter[] pars = {
                new SqlParameter("@subject_id", SqlDbType.NVarChar, 4),
                new SqlParameter("@support_point", SqlDbType.NVarChar, 8),
                new SqlParameter("@support_power_inside", SqlDbType.NVarChar, 8),
                new SqlParameter("@edu_activity", SqlDbType.NVarChar, 10),
                new SqlParameter("@id", SqlDbType.NVarChar, 4),
                                 };

            pars[0].Value = tb_support_information.subject_id;
            pars[1].Value = tb_support_information.support_point;
            pars[2].Value = tb_support_information.support_power_inside;
            pars[3].Value = tb_support_information.edu_activity;
            pars[4].Value = tb_support_information.id;


            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }


        /// <summary>
        /// 获取总的记录数
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            string sql = "select count(*) from TB_SUPPORT_INFORMATION";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(sql, CommandType.Text));
        }


        /// <summary>
        /// 获取指定范围的数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<TB_SUPPORT_INFORMATION> GetPageList(int start, int end)
        {
            string sql = "select * from(select *,row_number() over(order by id) as num from TB_SUPPORT_INFORMATION)as t where num>=@start and num<=@end";
            SqlParameter[] pars ={
            new SqlParameter("@start",start),
               new SqlParameter("@end",end)
           };
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, pars);
            List<TB_SUPPORT_INFORMATION> list = null;
            if (da.Rows.Count > 0)
            {
                list = new List<TB_SUPPORT_INFORMATION>();
                TB_SUPPORT_INFORMATION tb_support_information = null;
                foreach (DataRow row in da.Rows)
                {
                    tb_support_information = new TB_SUPPORT_INFORMATION();
                    LoadEntity(row, tb_support_information);
                    list.Add(tb_support_information);

                }
            }
            return list;
        }




        /// <summary>
        /// 根据行号给属性赋值
        /// </summary>
        /// <param name="row"></param>
        /// <param name="tb_support_information"></param>
        private void LoadEntity(DataRow row, TB_SUPPORT_INFORMATION tb_support_information)
        {
            tb_support_information.id = row["id"] != DBNull.Value ? Convert.ToInt32(row["id"]) : Int32.MinValue;
            tb_support_information.subject_id = row["subject_id"] != DBNull.Value ? Convert.ToInt32(row["subject_id"]) : Int32.MinValue;
            tb_support_information.support_point = row["support_point"] != DBNull.Value ? float.Parse(row["graduation_require_num_detail"].ToString()) : float.MinValue;
            tb_support_information.support_power_inside = row["support_power_inside"] != DBNull.Value ? float.Parse(row["support_power_inside"].ToString()) : float.MinValue;
            tb_support_information.edu_activity = row["edu_activity"] != DBNull.Value ? row["edu_activity"].ToString() : string.Empty;
           
        }
    }
}
