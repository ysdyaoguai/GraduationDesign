using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraduationDesign_Model;
using System.Windows.Forms;

namespace GraduationDesign_WebApp
{
    /// <summary>
    /// Login1 的摘要说明
    /// </summary>
    public class Login1 : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string userName = context.Request["userName"];
            string userPwd = context.Request["userPwd"];

            GraduationDesign_BLL.TB_USER_SERVICE TB_USER_SERVICE = new GraduationDesign_BLL.TB_USER_SERVICE();

            string msg = String.Empty;
            TB_USER tb_user = null;
            


            if (TB_USER_SERVICE.CheckLoginUserInfo(userName, userPwd, out msg, out tb_user))
            {
                context.Session["tb_user"] = tb_user;
                context.Response.Write("yes:" + msg);

            }
            else
            {
                context.Response.Write("no:" + msg);
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