using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraduationDesign_Model;

namespace GraduationDesign_WebApp
{
    /// <summary>
    /// AddTbUser 的摘要说明
    /// </summary>
    public class AddTbUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            TB_USER tb_user = new TB_USER();
            GraduationDesign_DAL.TB_USER_DAL TB_USER_DAL = new GraduationDesign_DAL.TB_USER_DAL();
            tb_user.UserName = context.Request["userName"];
            tb_user.UserPwd = context.Request["userPwd"];
            tb_user.UserType = context.Request["userType"];
            tb_user.UserRegTime = DateTime.Now;
            tb_user.UserID = TB_USER_DAL.GetList().Count + 1;

            GraduationDesign_BLL.TB_USER_SERVICE TB_USER_SERVICE = new GraduationDesign_BLL.TB_USER_SERVICE();
            if (TB_USER_SERVICE.Add_TB_USER(tb_user))
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