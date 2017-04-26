using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraduationDesign_Model;

namespace GraduationDesign_WebApp
{
    /// <summary>
    /// EditTbUser 的摘要说明
    /// </summary>
    public class EditTbUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            TB_USER tb_user = new TB_USER();
            tb_user.UserID = Convert.ToInt32(context.Request["editUserId"]);
            tb_user.UserRegTime = Convert.ToDateTime(context.Request["editUserRegTime"]);
            tb_user.UserName = context.Request["editUserName"];
            tb_user.UserPwd = context.Request["editUserPwd"];
            tb_user.UserType = context.Request["editUserType"];

            GraduationDesign_BLL.TB_USER_SERVICE TB_USER_SERVICE = new GraduationDesign_BLL.TB_USER_SERVICE();
            if (TB_USER_SERVICE.EditTbUserModel(tb_user))
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