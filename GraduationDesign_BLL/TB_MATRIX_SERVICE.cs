using GraduationDesign_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationDesign_BLL
{
    public class TB_MATRIX_SERVICE
    {
        GraduationDesign_DAL.TB_MATRIX_DAL TB_MATRIX_DAL = new GraduationDesign_DAL.TB_MATRIX_DAL();

        /// <summary>
        /// 返回分数列表
        /// </summary>
        /// <returns></returns>
        public List<TB_MATRIX> GetList()
        {
            return TB_MATRIX_DAL.GetList();
        }

        /// <summary>
        /// 添加分数
        /// </summary>
        /// <param name="tb_score"></param>
        /// <returns></returns>
        public bool Add_TB_MATRIX(TB_MATRIX tb_matrix)
        {
            return TB_MATRIX_DAL.AddTbMatrix(tb_matrix) > 0;
        }
    }
}
