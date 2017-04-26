using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationDesign_Model
{
    public class TB_USER
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public string UserPwd { get; set; }
        public DateTime UserRegTime { get; set; }
    }
}
