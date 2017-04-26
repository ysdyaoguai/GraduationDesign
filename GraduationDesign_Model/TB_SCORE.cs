using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationDesign_Model
{
    public class TB_SCORE
    {
        //学生ID
        public int student_id { get; set; }
        //科目ID
        public int subject_id { get; set; }
        //平时成绩
        public int score_daily { get; set; }
        //考试成绩
        public int score_exam { get; set; }
        //考勤成绩
        public int score_class { get; set; }
        //测验总评
        public int score_test_all { get; set; }
        //上级实验
        public int score_exp_all { get; set; }
        //综合实验
        public int score_last_exp { get; set; }
    }
}
