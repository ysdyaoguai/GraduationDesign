using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GraduationDesign_Model;
using System.Threading;

namespace GraduationDesign_WebApp
{
    public partial class UserWelcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tb_user"] != null)
            {
                Response.Write("欢迎" + ((TB_USER)Session["tb_user"]).UserName + "登陆！");
                
                Response.Write("页面将在3秒后自动跳转");

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}