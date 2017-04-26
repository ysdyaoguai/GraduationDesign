using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduationDesign_Model;

namespace GraduationDesign_BLL
{
    public class TB_SCORE_SERVICE
    {

        GraduationDesign_DAL.TB_SCORE_DAL TB_SCORE_DAL = new GraduationDesign_DAL.TB_SCORE_DAL();

        /// <summary>
        /// 返回分数列表
        /// </summary>
        /// <returns></returns>
        public List<TB_SCORE> GetList()
        {
            return TB_SCORE_DAL.GetList();
        }

        /// <summary>
        /// 添加分数
        /// </summary>
        /// <param name="tb_score"></param>
        /// <returns></returns>
        public bool Add_TB_SCORE(TB_SCORE tb_score)
        {
            return TB_SCORE_DAL.AddTbScore(tb_score) > 0;
        }
    }
}
