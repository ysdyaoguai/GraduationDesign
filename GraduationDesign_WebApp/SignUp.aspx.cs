using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GraduationDesign_Model;
using GraduationDesign_DAL;

namespace GraduationDesign_WebApp
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ToSignUp();
            }

        }


        private void ToSignUp()
        {
            GraduationDesign_DAL.TB_USER_DAL TB_USER_DAL = new GraduationDesign_DAL.TB_USER_DAL();

            TB_USER tb_user = new TB_USER();
            tb_user.UserID = TB_USER_DAL.GetList().Count + 1;
            tb_user.UserName = Context.Request.Form["UserName"];
            tb_user.UserType = Context.Request.Form["UserType"];
            tb_user.UserPwd = Context.Request.Form["UserPwd"];
            tb_user.UserRegTime = DateTime.Now;

            GraduationDesign_BLL.TB_USER_SERVICE tb_user_service = new GraduationDesign_BLL.TB_USER_SERVICE();
            if (tb_user_service.Add_TB_USER(tb_user))
            {
                Context.Response.Redirect("Login.aspx");
            }
            else
            {
                Context.Response.Redirect("Error.aspx");
            }
        }
    }
}