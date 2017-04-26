using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraduationDesign_WebApp
{
    /// <summary>
    /// Home1 的摘要说明
    /// </summary>
    public class Home1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
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