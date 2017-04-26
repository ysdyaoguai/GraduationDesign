using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationDesign_Common
{
    public class PageBar
    {

        /// <summary>
        /// 获取数字页码条
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageCount">总页数</param>
        /// <returns></returns>
        public static string GetPageBar(int pageIndex, int pageCount)
        {
            if (pageCount == 1)
            {
                return string.Empty;//如果只有1页不会出现数字页码条
            }
            int start = pageIndex - 5;//要求的是页面上显示10个数字页码.
            if (start < 1)
            {
                start = 1;
            }
            int end = start + 9;//终止位置
            if (end > pageCount)
            {
                end = pageCount;
                start = end - 9 > 0 ? end - 9 : 1;

            }
            StringBuilder sb = new StringBuilder();
            if (pageIndex > 1)
            {
                sb.Append(string.Format("<a href='?pageIndex={0}' class='myPageBar'>上一页</a>", pageIndex - 1));
            }
            for (int i = start; i <= end; i++)
            {
                if (i == pageIndex)
                {
                    sb.Append(i);
                }
                else
                {
                    sb.Append(string.Format("<a href='?pageIndex={0}' class='myPageBar'>{0}</a>", i));
                }
            }
            if (pageIndex < pageCount)
            {
                sb.Append(string.Format("<a href='?pageIndex={0}' class='myPageBar'>下一页</a>", pageIndex + 1));
            }

            return sb.ToString();

        }
    }
}
