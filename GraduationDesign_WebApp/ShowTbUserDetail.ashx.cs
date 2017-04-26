using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraduationDesign_Model;
using System.Web.Script.Serialization;

namespace GraduationDesign_WebApp
{
    /// <summary>
    /// ShowTbUserDetail 的摘要说明
    /// </summary>
    public class ShowTbUserDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            int id = Convert.ToInt32(context.Request["id"]);

            GraduationDesign_BLL.TB_USER_SERVICE TB_USER_SERVICE = new GraduationDesign_BLL.TB_USER_SERVICE();
            TB_USER tb_user = TB_USER_SERVICE.GetTbUserModel(id);
            JavaScriptSerializer js = new JavaScriptSerializer();

            context.Response.Write(js.Serialize(tb_user));

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