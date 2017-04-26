using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GraduationDesign_Model;
using GraduationDesign_BLL;
using System.Data;

namespace GraduationDesign_WebApp
{
    public partial class Login : System.Web.UI.Page
    {
        public string ErrorMsg { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.TbUserPwd.Text != "")
            {
                this.TbUserPwd.Attributes["value"] = this.TbUserPwd.Text;
            }

            //if (IsPostBack)
            //{
            //    CheckTbUser();
            //}
        }

        /// <summary>
        /// 校验用户的用户名和密码是否正确
        /// </summary>
        private void CheckTbUser()
        {
            //string UserName = Request.Form["TbUserName"];
            //string UserPwd = Request.Form["TbUserPwd"];
            //TB_USER_SERVICE TB_USER_SERVICE = new TB_USER_SERVICE();
            //string msg = string.Empty;
            //TB_USER tb_user = null;
            //if (TB_USER_SERVICE.CheckLoginUserInfo(UserName, UserPwd, out msg, out tb_user))
            //{
            //    //如果上面的条件成立，表示用户输入的是正确的用户名和密码
            //    Session["tb_user"] = tb_user;
            //    Response.Redirect("UserWelcome.aspx");
            //}
            //else
            //{
            //    ErrorMsg = msg;
            //}





        }

    }
}