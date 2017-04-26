using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using GraduationDesign_Model;

namespace GraduationDesign_DAL
{
    public class TB_STUDENT_DETAIL_DAL
    {


        /// <summary>
        /// 返回学生列表
        /// </summary>
        /// <returns></returns>
        public List<TB_STUDENT_DETAIL> GetList()
        {
            string sql = "select * from TB_STUDENT_DETAIL";
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text);
            List<TB_STUDENT_DETAIL> list = null;
            if (da.Rows.Count > 0)
            {
                list = new List<TB_STUDENT_DETAIL>();
                TB_STUDENT_DETAIL tb_student_detail = null;
                foreach (DataRow row in da.Rows)
                {
                    tb_student_detail = new TB_STUDENT_DETAIL();
                    LoadEntity(row, tb_student_detail);
                    list.Add(tb_student_detail);
                }
            }
            return list;
        }


        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <param name="tb_student_detail"></param>
        /// <returns></returns>
        public int AddTbStudentDetail(TB_STUDENT_DETAIL tb_student_detail)
        {
            string sql = "insert into TB_STUDENT_DETAIL (student_id, student_name, student_sex) values (@student_id, @student_name, @student_sex)";
            SqlParameter[] pars = {
                new SqlParameter("@student_id", SqlDbType.NVarChar, 4),
                new SqlParameter("@student_name", SqlDbType.NVarChar, 10),
                new SqlParameter("@student_sex", SqlDbType.NVarChar, 10),
            };

            pars[0].Value = tb_student_detail.student_id;
            pars[1].Value = tb_student_detail.student_name;
            pars[2].Value = tb_student_detail.student_sex;

            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }


        /// <summary>
        /// 根据编号删除学生记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteTbStudentDetailModel(int id)
        {
            string sql = "delete from TB_STUDENT_DETAIL where id=@id";
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, new SqlParameter("@id", id));
        }




        /// <summary>
        /// 更新学生数据
        /// </summary>
        /// <param name="tb_student_detail"></param>
        /// <returns></returns>
        public int EditTbStudentDetailModel(TB_STUDENT_DETAIL tb_student_detail)
        {
            string sql = "update TB_STUDENT_DETAIL_DAL set student_name=@student_name,student_sex=@student_sex where student_id=@student_id";
            SqlParameter[] pars = {
                new SqlParameter("@student_name", SqlDbType.NVarChar, 10),
                new SqlParameter("@student_sex", SqlDbType.NVarChar, 10),
                new SqlParameter("@student_id", SqlDbType.NVarChar, 4),
                                 };

            pars[0].Value = tb_student_detail.student_name;
            pars[1].Value = tb_student_detail.student_sex;
            pars[2].Value = tb_student_detail.student_id;
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }


        /// <summary>
        /// 获取总的记录数
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            string sql = "select count(*) from TB_STUDENT_DETAIL";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(sql, CommandType.Text));
        }


        /// <summary>
        /// 获取指定范围的数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<TB_STUDENT_DETAIL> GetPageList(int start, int end)
        {
            string sql = "select * from(select *,row_number() over(order by student_id) as num from TB_STUDENT_DETAIL)as t where num>=@start and num<=@end";
            SqlParameter[] pars ={
            new SqlParameter("@start",start),
               new SqlParameter("@end",end)
           };
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, pars);
            List<TB_STUDENT_DETAIL> list = null;
            if (da.Rows.Count > 0)
            {
                list = new List<TB_STUDENT_DETAIL>();
                TB_STUDENT_DETAIL tb_student_detail = null;
                foreach (DataRow row in da.Rows)
                {
                    tb_student_detail = new TB_STUDENT_DETAIL();
                    LoadEntity(row, tb_student_detail);
                    list.Add(tb_student_detail);

                }
            }
            return list;
        }





        /// <summary>
        /// 根据学生ID查找学生信息
        /// </summary>
        /// <param name="student_id"></param>
        /// <returns></returns>
        public TB_STUDENT_DETAIL GetTbStudentDetailModel(int student_id)
        {
            string sql = "select * from TB_STUDENT_DETAIL where student_id = @student_id";
            TB_STUDENT_DETAIL tb_student_detail = null;
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, new System.Data.SqlClient.SqlParameter("@student_id", student_id));
            if (da.Rows.Count > 0)
            {
                tb_student_detail = new TB_STUDENT_DETAIL();
                LoadEntity(da.Rows[0], tb_student_detail);
            }
            return tb_student_detail;
        }


        /// <summary>
        /// 根据学生名查找学生信息
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        public TB_STUDENT_DETAIL GetTbStudentDetailModel(string student_name)
        {
            string sql = "select * from TB_STUDENT_DETAIL where student_name = @student_name";
            TB_STUDENT_DETAIL tb_student_detail = null;
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, new System.Data.SqlClient.SqlParameter("@student_name", student_name));
            if (da.Rows.Count > 0)
            {
                tb_student_detail = new TB_STUDENT_DETAIL();
                LoadEntity(da.Rows[0], tb_student_detail);
            }
            return tb_student_detail;
        }



        /// <summary>
        /// 根据行号给属性赋值
        /// </summary>
        /// <param name="row"></param>
        /// <param name="tb_score"></param>
        private void LoadEntity(DataRow row, TB_STUDENT_DETAIL tb_student_detail)
        {
            tb_student_detail.student_name = row["student_name"] != DBNull.Value ? row["student_name"].ToString() : string.Empty;
            tb_student_detail.student_sex = row["student_sex"] != DBNull.Value ? row["student_sex"].ToString() : string.Empty;
            tb_student_detail.student_id = row["student_id"] != DBNull.Value ? Convert.ToInt32(row["student_id"]) : Int32.MinValue;

        }

    }
}
