using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraduationDesign_Model;
using System.Web.Script.Serialization;

namespace GraduationDesign_WebApp.StudentDetail
{
    /// <summary>
    /// ShowStudentDetail 的摘要说明
    /// </summary>
    public class ShowStudentDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            int id = Convert.ToInt32(context.Request["id"]);

            GraduationDesign_BLL.TB_STUDENT_DETAIL_SERVICE TB_STUDENT_DETAIL_SERVICE = new GraduationDesign_BLL.TB_STUDENT_DETAIL_SERVICE();
            TB_STUDENT_DETAIL tb_student_detail = TB_STUDENT_DETAIL_SERVICE.GetTbStudentDetailModel(id);
            JavaScriptSerializer js = new JavaScriptSerializer();

            context.Response.Write(js.Serialize(tb_student_detail));
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