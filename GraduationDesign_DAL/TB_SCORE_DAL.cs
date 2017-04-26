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
    public class TB_SCORE_DAL
    {


        /// <summary>
        /// 返回分数列表
        /// </summary>
        /// <returns></returns>
        public List<TB_SCORE> GetList()
        {
            string sql = "select * from TB_SCORE";
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text);
            List<TB_SCORE> list = null;
            if (da.Rows.Count > 0)
            {
                list = new List<TB_SCORE>();
                TB_SCORE tb_score = null;
                foreach (DataRow row in da.Rows)
                {
                    tb_score = new TB_SCORE();
                    LoadEntity(row, tb_score);
                    list.Add(tb_score);
                }
            }
            return list;
        }


        /// <summary>
        /// 添加分数信息
        /// </summary>
        /// <param name="tb_score"></param>
        /// <returns></returns>
        public int AddTbScore(TB_SCORE tb_score)
        {
            string sql = "insert into TB_SCORE (student_id, subject_id, score_daily, score_exam, score_class, score_test_all, score_exp_all, score_last_exp) values (@student_id, @subject_id, @score_daily, @score_exam, @score_class, @score_test_all, @score_exp_all, @score_last_exp)";
            SqlParameter[] pars = {
                new SqlParameter("@student_id", SqlDbType.NVarChar, 4),
                new SqlParameter("@subject_id", SqlDbType.NVarChar, 4),
                new SqlParameter("@score_daily", SqlDbType.NVarChar, 4),
                new SqlParameter("@score_exam", SqlDbType.NVarChar, 4),
                new SqlParameter("@score_class", SqlDbType.NVarChar, 4),
                new SqlParameter("@score_test_all", SqlDbType.NVarChar, 4),
                new SqlParameter("@score_exp_all", SqlDbType.NVarChar, 4),
                new SqlParameter("@score_last_exp", SqlDbType.NVarChar, 4),
            };

            pars[0].Value = tb_score.student_id;
            pars[1].Value = tb_score.subject_id;
            pars[2].Value = tb_score.score_daily;
            pars[3].Value = tb_score.score_exam;
            pars[4].Value = tb_score.score_class;
            pars[5].Value = tb_score.score_test_all;
            pars[6].Value = tb_score.score_exp_all;
            pars[7].Value = tb_score.score_last_exp;

            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }

        /// <summary>
        /// 根据编号删除分数记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteTbScoreModel(int student_id)
        {
            string sql = "delete from TB_SCORE where student_id=@student_id";
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, new SqlParameter("@student_id", student_id));
        }


        /// <summary>
        /// 根据学生ID查找分数信息
        /// </summary>
        /// <param name="student_id"></param>
        /// <returns></returns>
        public TB_SCORE GetTbScoreModel(int student_id)
        {
            string sql = "select * from TB_SCORE where student_id = @student_id";
            TB_SCORE tb_score = null;
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, new System.Data.SqlClient.SqlParameter("@student_id", student_id));
            if (da.Rows.Count > 0)
            {
                tb_score = new TB_SCORE();
                LoadEntity(da.Rows[0], tb_score);
            }
            return tb_score;
        }



        /// <summary>
        /// 更新分数数据
        /// </summary>
        /// <param name="tb_user"></param>
        /// <returns></returns>
        public int EditTbScoreModel(TB_SCORE tb_score)
        {
            string sql = "update TB_SCORE set subject_id=@subject_id,score_daily=@score_daily,score_exam=@score_exam,score_class=@score_class,score_test_all=@score_test_all,score_exp_all=@score_exp_all,score_last_exp=@score_last_exp where student_id=@student_id";
            SqlParameter[] pars = {
                new SqlParameter("@subject_id", SqlDbType.NVarChar, 4),
                new SqlParameter("@score_daily", SqlDbType.NVarChar, 4),
                new SqlParameter("@score_exam", SqlDbType.NVarChar, 4),
                new SqlParameter("@score_class", SqlDbType.NVarChar, 4),
                new SqlParameter("@score_test_all", SqlDbType.NVarChar, 4),
                new SqlParameter("@score_exp_all", SqlDbType.NVarChar, 4),
                new SqlParameter("@score_last_exp", SqlDbType.NVarChar, 4),
                new SqlParameter("@student_id", SqlDbType.NVarChar, 4),
                                 };

            pars[0].Value = tb_score.subject_id;
            pars[1].Value = tb_score.score_daily;
            pars[2].Value = tb_score.score_exam;
            pars[3].Value = tb_score.score_class;
            pars[4].Value = tb_score.score_test_all;
            pars[5].Value = tb_score.score_exp_all;
            pars[6].Value = tb_score.score_last_exp;
            pars[7].Value = tb_score.student_id;


            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }


        /// <summary>
        /// 获取总的记录数
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            string sql = "select count(*) from TB_SCORE";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(sql, CommandType.Text));
        }


        /// <summary>
        /// 获取指定范围的数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<TB_SCORE> GetPageList(int start, int end)
        {
            string sql = "select * from(select *,row_number() over(order by student_id) as num from TB_SCORE)as t where num>=@start and num<=@end";
            SqlParameter[] pars ={
            new SqlParameter("@start",start),
               new SqlParameter("@end",end)
           };
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, pars);
            List<TB_SCORE> list = null;
            if (da.Rows.Count > 0)
            {
                list = new List<TB_SCORE>();
                TB_SCORE tb_score = null;
                foreach (DataRow row in da.Rows)
                {
                    tb_score = new TB_SCORE();
                    LoadEntity(row, tb_score);
                    list.Add(tb_score);

                }
            }
            return list;
        }




        /// <summary>
        /// 根据行号给属性赋值
        /// </summary>
        /// <param name="row"></param>
        /// <param name="tb_score"></param>
        private void LoadEntity(DataRow row, TB_SCORE tb_score)
        {
            tb_score.score_class = row["score_class"] != DBNull.Value ? Convert.ToInt32(row["score_class"]) : Int32.MinValue;
            tb_score.score_daily = row["score_daily"] != DBNull.Value ? Convert.ToInt32(row["score_daily"]) : Int32.MinValue;
            tb_score.score_exam = row["score_exam"] != DBNull.Value ? Convert.ToInt32(row["score_exam"]) : Int32.MinValue;
            tb_score.score_exp_all = row["score_exp_all"] != DBNull.Value ? Convert.ToInt32(row["score_exp_all"]) : Int32.MinValue;
            tb_score.score_last_exp = row["score_last_exp"] != DBNull.Value ? Convert.ToInt32(row["score_last_exp"]) : Int32.MinValue;
            tb_score.score_test_all = row["score_test_all"] != DBNull.Value ? Convert.ToInt32(row["score_test_all"]) : Int32.MinValue;
            tb_score.student_id = row["student_id"] != DBNull.Value ? Convert.ToInt32(row["student_id"]) : Int32.MinValue;
            tb_score.subject_id = row["subject_id"] != DBNull.Value ? Convert.ToInt32(row["subject_id"]) : Int32.MinValue;

        }

    }
}
