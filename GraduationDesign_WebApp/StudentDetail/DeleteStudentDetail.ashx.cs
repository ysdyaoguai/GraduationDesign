using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduationDesign_WebApp.StudentDetail
{
    /// <summary>
    /// DeleteStudentDetail 的摘要说明
    /// </summary>
    public class DeleteStudentDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id = Convert.ToInt32(context.Request["id"]);


            GraduationDesign_BLL.TB_STUDENT_DETAIL_SERVICE TB_STUDENT_DETAIL_SERVICE = new GraduationDesign_BLL.TB_STUDENT_DETAIL_SERVICE();
            if (TB_STUDENT_DETAIL_SERVICE.DeleteTbStudentDetailModel(id))
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