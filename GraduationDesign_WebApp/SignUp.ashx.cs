using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduationDesign_WebApp
{
    /// <summary>
    /// SignUp1 的摘要说明
    /// </summary>
    public class SignUp1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string name = context.Request["name"];

            GraduationDesign_BLL.TB_USER_SERVICE TB_USER_SERVICE = new GraduationDesign_BLL.TB_USER_SERVICE();
            if (TB_USER_SERVICE.GetTbUserModel(name) != null)
            {
                context.Response.Write("此用户名已存在！");
            }
            else
            {
                context.Response.Write("此用户名可用！");
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