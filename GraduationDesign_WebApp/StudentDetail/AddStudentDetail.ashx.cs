using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraduationDesign_Model;

namespace GraduationDesign_WebApp.StudentDetail
{
    /// <summary>
    /// AddStudentDetail 的摘要说明
    /// </summary>
    public class AddStudentDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            TB_STUDENT_DETAIL tb_student_detail = new TB_STUDENT_DETAIL();
            GraduationDesign_DAL.TB_STUDENT_DETAIL_DAL TB_STUDENT_DETAIL_DAL = new GraduationDesign_DAL.TB_STUDENT_DETAIL_DAL();
            tb_student_detail.student_name = context.Request["studentName"];
            tb_student_detail.student_sex = context.Request["studentSex"];
            tb_student_detail.student_id = TB_STUDENT_DETAIL_DAL.GetList().Count + 1;

            GraduationDesign_BLL.TB_STUDENT_DETAIL_SERVICE TB_STUDENT_DETAIL_SERVICE = new GraduationDesign_BLL.TB_STUDENT_DETAIL_SERVICE();
            if (TB_STUDENT_DETAIL_SERVICE.Add_TB_STUDENT_DETAIL(tb_student_detail))
            {
                context.Response.Write("y");
            }
            else
            {
                context.Response.Write("n");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}