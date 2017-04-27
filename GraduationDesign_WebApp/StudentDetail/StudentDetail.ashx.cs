using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraduationDesign_Model;
using System.Web.Script.Serialization;

namespace GraduationDesign_WebApp.StudentDetail
{
    /// <summary>
    /// StudentDetail1 的摘要说明
    /// </summary>
    public class StudentDetail1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";




            GraduationDesign_BLL.TB_STUDENT_DETAIL_SERVICE TB_STUDENT_DETAIL_SERVICE = new GraduationDesign_BLL.TB_STUDENT_DETAIL_SERVICE();

            //当前页码
            int pageIndex;

            if (!int.TryParse(context.Request["pageIndex"], out pageIndex))
            {
                pageIndex = 1;
            }

            //每页显示5条信息
            int pageSize = 5;
            //页数
            int pageCount = TB_STUDENT_DETAIL_SERVICE.GetPageCount(pageSize);
            //判断当前页码的取值范围
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;





            //List<TB_USER> list = TB_USER_SERVICE.GetList();
            //获取分页数据
            List<TB_STUDENT_DETAIL> list = TB_STUDENT_DETAIL_SERVICE.GetPageList(pageIndex, pageSize);


            //获取分页的页码条
            string strPageBar = GraduationDesign_Common.PageBar.GetPageBar(pageIndex, pageCount);



            //此类可以将数据序列化成json格式
            JavaScriptSerializer js = new JavaScriptSerializer();
            //context.Response.Write(js.Serialize(list));


            context.Response.Write(js.Serialize(new { studentList = list, myPageBar = strPageBar }));


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