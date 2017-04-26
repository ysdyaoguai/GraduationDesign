using GraduationDesign_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationDesign_BLL
{
    public class TB_USER_SERVICE
    {
        GraduationDesign_DAL.TB_USER_DAL TB_USER_DAL = new GraduationDesign_DAL.TB_USER_DAL();

        /// <summary>
        /// 返回用户列表
        /// </summary>
        /// <returns></returns>
        public List<TB_USER> GetList()
        {
            return TB_USER_DAL.GetList();
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="tb_user"></param>
        /// <returns></returns>
        public bool Add_TB_USER(TB_USER tb_user)
        {
            return TB_USER_DAL.AddTbUser(tb_user) > 0;
        }

        /// <summary>
        /// 根据编号删除用户记录
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public bool DeleteTbUserModel(int id)
        {
            return TB_USER_DAL.DeleteTbUserModel(id) > 0;
        }

        /// <summary>
        /// 根据编号查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TB_USER GetTbUserModel(int id)
        {
            return TB_USER_DAL.GetTbUserModel(id);
        }

        /// <summary>
        /// 根据名称查询用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public TB_USER GetTbUserModel(string userName)
        {
            return TB_USER_DAL.GetTbUserModel(userName);
        }

        /// <summary>
        /// 更新用户的数据
        /// </summary>
        /// <param name="tb_user"></param>
        /// <returns></returns>
        public bool EditTbUserModel(TB_USER tb_user)
        {
            return TB_USER_DAL.EditTbUserModel(tb_user) > 0;
        }


        /// <summary>
        /// 求出总页面数量
        /// </summary>
        /// <param name="pageSize">每页显示的记录数</param>
        /// <returns></returns>
        public int GetPageCount(int pageSize)
        {
            //获取总记录的数量
            int recordCount = TB_USER_DAL.GetRecordCount();
            //页数
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));

            return pageCount;
        }


        /// <summary>
        /// 获取指定范围的数据
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示的记录数</param>
        /// <returns></returns>
        public List<TB_USER> GetPageList(int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;

            return TB_USER_DAL.GetPageList(start, end);
        }



        /// <summary>
        /// 判断用户的用户名、密码是否正确
        /// </summary>
        /// <param name="UserName">传来的用户名</param>
        /// <param name="UserPwd">传来的密码</param>
        /// <param name="msg">返回的信息</param>
        /// <param name="TB_USER">返回的登陆用户信息</param>
        /// <returns></returns>
        public bool CheckLoginUserInfo(string UserName, string UserPwd, out string msg, out TB_USER tb_user)
        {
            tb_user = TB_USER_DAL.GetTbUserModel(UserName);
            if (tb_user != null)
            {
                if (tb_user.UserPwd == UserPwd)
                {
                    msg = "登录成功！";
                    return true;
                }
                else
                {
                    msg = "用户名或密码错误";
                    return false;
                }
            }
            else
            {
                msg = "此用户不存在，请重新输入！";
                return false;
            }
        }
    }
}
