using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduationDesign_Model;

namespace GraduationDesign_BLL
{
    public class TB_SUPPORT_INFORMATION_SERVICE
    {
        GraduationDesign_DAL.TB_SUPPORT_INFORMATION_DAL TB_SUPPORT_INFORMATION_DAL = new GraduationDesign_DAL.TB_SUPPORT_INFORMATION_DAL();

        /// <summary>
        /// 返回支撑情况列表
        /// </summary>
        /// <returns></returns>
        public List<TB_SUPPORT_INFORMATION> GetList()
        {
            return TB_SUPPORT_INFORMATION_DAL.GetList();
        }

        /// <summary>
        /// 添加科目
        /// </summary>
        /// <param name="tb_support_information"></param>
        /// <returns></returns>
        public bool Add_TB_SUBJECT(TB_SUPPORT_INFORMATION tb_support_information)
        {
            return TB_SUPPORT_INFORMATION_DAL.AddTbSupportInformation(tb_support_information) > 0;
        }
    }
}
