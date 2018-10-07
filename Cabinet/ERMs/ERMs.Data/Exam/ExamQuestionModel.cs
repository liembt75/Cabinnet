using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class ExamQuestionModel : Exam_Question
    {
        public bool? isCorrect { get; set; }
        public string Answer { get; set; }
        public string DapAn { get; set; }

        public string RowNumber { get; set; }
    }
}
