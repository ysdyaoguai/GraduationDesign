using GraduationDesign_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationDesign_BLL
{
    public class TB_SUBJECT_SERVICE
    {
        GraduationDesign_DAL.TB_SUBJECT_DAL TB_SUBJECT_DAL = new GraduationDesign_DAL.TB_SUBJECT_DAL();

        /// <summary>
        /// 返回科目列表
        /// </summary>
        /// <returns></returns>
        public List<TB_SUBJECT> GetList()
        {
            return TB_SUBJECT_DAL.GetList();
        }

        /// <summary>
        /// 添加科目
        /// </summary>
        /// <param name="tb_subject"></param>
        /// <returns></returns>
        public bool Add_TB_SUBJECT(TB_SUBJECT tb_subject)
        {
            return TB_SUBJECT_DAL.AddTbSubject(tb_subject) > 0;
        }
    }
}
