using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraduationDesign_Model;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace GraduationDesign_WebApp
{
    /// <summary>
    /// DeleteTbUser 的摘要说明
    /// </summary>
    public class DeleteTbUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id = Convert.ToInt32(context.Request["id"]);


            GraduationDesign_BLL.TB_USER_SERVICE TB_USER_SERVICE = new GraduationDesign_BLL.TB_USER_SERVICE();
            if (TB_USER_SERVICE.DeleteTbUserModel(id))
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