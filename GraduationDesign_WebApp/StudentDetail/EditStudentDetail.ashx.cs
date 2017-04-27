using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraduationDesign_Model;

namespace GraduationDesign_WebApp.StudentDetail
{
    /// <summary>
    /// EditStudentDetail 的摘要说明
    /// </summary>
    public class EditStudentDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            TB_STUDENT_DETAIL tb_student_detail = new TB_STUDENT_DETAIL();
            tb_student_detail.student_id = Convert.ToInt32(context.Request["editStudentDetailID"]);
            tb_student_detail.student_name = context.Request["editStudentDetailName"];
            tb_student_detail.student_sex = context.Request["editStudentDetailSex"];

            GraduationDesign_BLL.TB_STUDENT_DETAIL_SERVICE TB_STUDENT_DETAIL_SERVICE = new GraduationDesign_BLL.TB_STUDENT_DETAIL_SERVICE();
            if (TB_STUDENT_DETAIL_SERVICE.EditTbStudentDetailModel(tb_student_detail))
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