using GraduationDesign_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationDesign_BLL
{
    public class TB_STUDENT_DETAIL_SERVICE
    {


        GraduationDesign_DAL.TB_STUDENT_DETAIL_DAL TB_STUDENT_DETAIL_DAL = new GraduationDesign_DAL.TB_STUDENT_DETAIL_DAL();

        /// <summary>
        /// 返回学生列表
        /// </summary>
        /// <returns></returns>
        public List<TB_STUDENT_DETAIL> GetList()
        {
            return TB_STUDENT_DETAIL_DAL.GetList();
        }

        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="tb_student_detail"></param>
        /// <returns></returns>
        public bool Add_TB_STUDENT_DETAIL(TB_STUDENT_DETAIL tb_student_detail)
        {
            return TB_STUDENT_DETAIL_DAL.AddTbStudentDetail(tb_student_detail) > 0;
        }


    }
}
