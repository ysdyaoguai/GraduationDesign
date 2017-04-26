using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationDesign_Model
{
    public class TB_MATRIX
    {
        public int subject_id { get; set; }
        public int graduation_require_num { get; set; }
        public float graduation_require_num_detail { get; set; }
        public string model { get; set; }
        public string model_detail { get; set; }
        public float support_power { get; set; }
    }
}
