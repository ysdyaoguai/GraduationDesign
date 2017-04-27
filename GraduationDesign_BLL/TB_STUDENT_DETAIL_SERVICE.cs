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
        /// 根据编号删除学生记录
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public bool DeleteTbStudentDetailModel(int id)
        {
            return TB_STUDENT_DETAIL_DAL.DeleteTbStudentDetailModel(id) > 0;
        }

        /// <summary>
        /// 根据编号查询学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TB_STUDENT_DETAIL GetTbStudentDetailModel(int id)
        {
            return TB_STUDENT_DETAIL_DAL.GetTbStudentDetailModel(id);
        }

        /// <summary>
        /// 根据名称查询学生信息
        /// </summary>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public TB_STUDENT_DETAIL GetTbStudentDetailModel(string studentName)
        {
            return TB_STUDENT_DETAIL_DAL.GetTbStudentDetailModel(studentName);
        }

        /// <summary>
        /// 更新学生的数据
        /// </summary>
        /// <param name="tb_user"></param>
        /// <returns></returns>
        public bool EditTbStudentDetailModel(TB_STUDENT_DETAIL tb_student)
        {
            return TB_STUDENT_DETAIL_DAL.EditTbStudentDetailModel(tb_student) > 0;
        }


        /// <summary>
        /// 求出总页面数量
        /// </summary>
        /// <param name="pageSize">每页显示的记录数</param>
        /// <returns></returns>
        public int GetPageCount(int pageSize)
        {
            //获取总记录的数量
            int recordCount = TB_STUDENT_DETAIL_DAL.GetRecordCount();
            //页数
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));

            return pageCount;
        }


        /// <summary>
        /// 获取指定范围的数据
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示的记录数</param>
        /// <returns></returns>
        public List<TB_STUDENT_DETAIL> GetPageList(int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;

            return TB_STUDENT_DETAIL_DAL.GetPageList(start, end);
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
