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
    public class TB_SUBJECT_DAL
    {


        /// <summary>
        /// 返回科目列表
        /// </summary>
        /// <returns></returns>
        public List<TB_SUBJECT> GetList()
        {
            string sql = "select * from TB_SUBJECT";
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text);
            List<TB_SUBJECT> list = null;
            if (da.Rows.Count > 0)
            {
                list = new List<TB_SUBJECT>();
                TB_SUBJECT tb_subject = null;
                foreach (DataRow row in da.Rows)
                {
                    tb_subject = new TB_SUBJECT();
                    LoadEntity(row, tb_subject);
                    list.Add(tb_subject);
                }
            }
            return list;
        }


        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="tb_subject"></param>
        /// <returns></returns>
        public int AddTbSubject(TB_SUBJECT tb_subject)
        {
            string sql = "insert into TB_SUBJECT (subject_id, subject_name) values (@subject_id, @subject_name)";
            SqlParameter[] pars = {
                new SqlParameter("@subject_id", SqlDbType.NVarChar, 4),
                new SqlParameter("@subject_name", SqlDbType.NVarChar, 50),
            };

            pars[0].Value = tb_subject.subject_id;
            pars[1].Value = tb_subject.subject_name;

            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }

        /// <summary>
        /// 根据编号删除科目记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteTbSubjectModel(int subject_id)
        {
            string sql = "delete from TB_SUBJECT where subject_id=@subject_id";
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, new SqlParameter("@subject_id", subject_id));
        }


        /// <summary>
        /// 根据科目ID查找用户信息
        /// </summary>
        /// <param name="subject_id"></param>
        /// <returns></returns>
        public TB_SUBJECT GetTbSubjectModel(int subject_id)
        {
            string sql = "select * from TB_SUBJECT where subject_id = @subject_id";
            TB_SUBJECT tb_subject = null;
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, new System.Data.SqlClient.SqlParameter("@subject_id", subject_id));
            if (da.Rows.Count > 0)
            {
                tb_subject = new TB_SUBJECT();
                LoadEntity(da.Rows[0], tb_subject);
            }
            return tb_subject;
        }



        /// <summary>
        /// 根据科目名称查找用户信息
        /// </summary>
        /// <param name="subject_id"></param>
        /// <returns></returns>
        public TB_SUBJECT GetTbSubjectModel(string subject_name)
        {
            string sql = "select * from TB_SUBJECT where subject_name = @subject_name";
            TB_SUBJECT tb_subject = null;
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, new System.Data.SqlClient.SqlParameter("@subject_name", subject_name));
            if (da.Rows.Count > 0)
            {
                tb_subject = new TB_SUBJECT();
                LoadEntity(da.Rows[0], tb_subject);
            }
            return tb_subject;
        }

        /// <summary>
        /// 更新科目数据
        /// </summary>
        /// <param name="tb_subject"></param>
        /// <returns></returns>
        public int EditTbUserModel(TB_SUBJECT tb_subject)
        {
            string sql = "update TB_SUBJECT set subject_name=@subject_name where subject_id=@subject_id";
            SqlParameter[] pars = {
                new SqlParameter("@subject_name", SqlDbType.NVarChar, 50),
                new SqlParameter("@subject_id", SqlDbType.NVarChar, 4),
                                 };

            pars[0].Value = tb_subject.subject_name;
            pars[1].Value = tb_subject.subject_id;
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }


        /// <summary>
        /// 获取总的记录数
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            string sql = "select count(*) from TB_SUBJECT";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(sql, CommandType.Text));
        }


        /// <summary>
        /// 获取指定范围的数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<TB_SUBJECT> GetPageList(int start, int end)
        {
            string sql = "select * from(select *,row_number() over(order by subject_id) as num from TB_SUBJECT)as t where num>=@start and num<=@end";
            SqlParameter[] pars ={
            new SqlParameter("@start",start),
               new SqlParameter("@end",end)
           };
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, pars);
            List<TB_SUBJECT> list = null;
            if (da.Rows.Count > 0)
            {
                list = new List<TB_SUBJECT>();
                TB_SUBJECT tb_subject = null;
                foreach (DataRow row in da.Rows)
                {
                    tb_subject = new TB_SUBJECT();
                    LoadEntity(row, tb_subject);
                    list.Add(tb_subject);

                }
            }
            return list;
        }




        /// <summary>
        /// 根据行号给属性赋值
        /// </summary>
        /// <param name="row"></param>
        /// <param name="tb_subject"></param>
        private void LoadEntity(DataRow row, TB_SUBJECT tb_subject)
        {
            tb_subject.subject_name = row["subject_name"] != DBNull.Value ? row["subject_name"].ToString() : string.Empty;
            tb_subject.subject_id = row["subject_id"] != DBNull.Value ? Convert.ToInt32(row["subject_id"]) : Int32.MinValue;

        }

    }
}
