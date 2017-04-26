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
    public class TB_MATRIX_DAL
    {
        
        /// <summary>
        /// 返回矩阵列表
        /// </summary>
        /// <returns></returns>
        public List<TB_MATRIX> GetList()
        {
            string sql = "select * from TB_MATRIX";
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text);
            List<TB_MATRIX> list = null;
            if (da.Rows.Count > 0)
            {
                list = new List<TB_MATRIX>();
                TB_MATRIX tb_matrix = null;
                foreach (DataRow row in da.Rows)
                {
                    tb_matrix = new TB_MATRIX();
                    LoadEntity(row, tb_matrix);
                    list.Add(tb_matrix);
                }
            }
            return list;
        }


        /// <summary>
        /// 添加矩阵信息
        /// </summary>
        /// <param name="tb_matrix"></param>
        /// <returns></returns>
        public int AddTbMatrix(TB_MATRIX tb_matrix)
        {
            string sql = "insert into TB_MATRIX (subject_id, graduation_require_num, graduation_require_num_detail, model, model_detail, support_power) values (@subject_id, @graduation_require_num, @graduation_require_num_detail, @model, @model_detail, @support_powerp)";
            SqlParameter[] pars = {
                new SqlParameter("@subject_id", SqlDbType.NVarChar, 4),
                new SqlParameter("@graduation_require_num", SqlDbType.NVarChar, 4),
                new SqlParameter("@graduation_require_num_detail", SqlDbType.NVarChar, 8),
                new SqlParameter("@model", SqlDbType.NVarChar, 10),
                new SqlParameter("@model_detail", SqlDbType.NVarChar, 10),
                new SqlParameter("@support_power", SqlDbType.NVarChar, 8),
            };

            pars[0].Value = tb_matrix.subject_id;
            pars[1].Value = tb_matrix.graduation_require_num;
            pars[2].Value = tb_matrix.graduation_require_num_detail;
            pars[3].Value = tb_matrix.model;
            pars[4].Value = tb_matrix.model_detail;
            pars[5].Value = tb_matrix.support_power;

            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }

        /// <summary>
        /// 根据编号删除矩阵记录
        /// </summary>
        /// <param name="subject_id"></param>
        /// <returns></returns>
        public int DeleteTbScoreModel(int subject_id)
        {
            string sql = "delete from TB_MATRIX where subject_id=@subject_id";
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, new SqlParameter("@subject_id", subject_id));
        }


        /// <summary>
        /// 根据科目ID查找矩阵信息
        /// </summary>
        /// <param name="subject_id"></param>
        /// <returns></returns>
        public TB_MATRIX GetTbScoreModel(int subject_id)
        {
            string sql = "select * from TB_MATRIX where subject_id = @subject_id";
            TB_MATRIX tb_matrix = null;
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, new System.Data.SqlClient.SqlParameter("@subject_id", subject_id));
            if (da.Rows.Count > 0)
            {
                tb_matrix = new TB_MATRIX();
                LoadEntity(da.Rows[0], tb_matrix);
            }
            return tb_matrix;
        }



        /// <summary>
        /// 更新矩阵数据
        /// </summary>
        /// <param name="tb_matrix"></param>
        /// <returns></returns>
        public int EditTbMatrixModel(TB_MATRIX tb_matrix)
        {
            string sql = "update TB_MATRIX set graduation_require_num=@graduation_require_num,graduation_require_num_detail=@graduation_require_num_detail,model=@model,model_detail=@model_detail,support_power=@support_power where subject_id=@subject_id";
            SqlParameter[] pars = {
                new SqlParameter("@graduation_require_num", SqlDbType.NVarChar, 4),
                new SqlParameter("@graduation_require_num_detail", SqlDbType.NVarChar, 8),
                new SqlParameter("@model", SqlDbType.NVarChar, 10),
                new SqlParameter("@model_detail", SqlDbType.NVarChar, 10),
                new SqlParameter("@support_power", SqlDbType.NVarChar, 8),
                new SqlParameter("@subject_id", SqlDbType.NVarChar, 4),
                                 };

            pars[0].Value = tb_matrix.graduation_require_num;
            pars[1].Value = tb_matrix.graduation_require_num_detail;
            pars[2].Value = tb_matrix.model;
            pars[3].Value = tb_matrix.model_detail;
            pars[4].Value = tb_matrix.support_power;
            pars[5].Value = tb_matrix.subject_id;


            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }


        /// <summary>
        /// 获取总的记录数
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            string sql = "select count(*) from TB_MATRIX";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(sql, CommandType.Text));
        }


        /// <summary>
        /// 获取指定范围的数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<TB_MATRIX> GetPageList(int start, int end)
        {
            string sql = "select * from(select *,row_number() over(order by subject_id) as num from TB_MATRIX)as t where num>=@start and num<=@end";
            SqlParameter[] pars ={
            new SqlParameter("@start",start),
               new SqlParameter("@end",end)
           };
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, pars);
            List<TB_MATRIX> list = null;
            if (da.Rows.Count > 0)
            {
                list = new List<TB_MATRIX>();
                TB_MATRIX tb_matrix = null;
                foreach (DataRow row in da.Rows)
                {
                    tb_matrix = new TB_MATRIX();
                    LoadEntity(row, tb_matrix);
                    list.Add(tb_matrix);

                }
            }
            return list;
        }




        /// <summary>
        /// 根据行号给属性赋值
        /// </summary>
        /// <param name="row"></param>
        /// <param name="tb_matrix"></param>
        private void LoadEntity(DataRow row, TB_MATRIX tb_matrix)
        {
            tb_matrix.subject_id = row["subject_id"] != DBNull.Value ? Convert.ToInt32(row["subject_id"]) : Int32.MinValue;
            tb_matrix.graduation_require_num = row["graduation_require_num"] != DBNull.Value ? Convert.ToInt32(row["graduation_require_num"]) : Int32.MinValue;
            tb_matrix.graduation_require_num_detail = row["graduation_require_num_detail"] != DBNull.Value ? float.Parse(row["graduation_require_num_detail"].ToString()) : float.MinValue;
            tb_matrix.model = row["model"] != DBNull.Value ? row["model"].ToString() : string.Empty;
            tb_matrix.model_detail = row["model_detail"] != DBNull.Value ? row["model_detail"].ToString() : string.Empty;
            tb_matrix.support_power = row["support_power"] != DBNull.Value ? float.Parse(row["support_power"].ToString()) : float.MinValue;

        }
    }
}
