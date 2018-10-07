using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class ExamTesterModel : USP_GetExamTester2_Result
    {        
        public List<ExamQuestionModel> ExamQuestion { get; set; }

        public ExamTesterModel ToModel(USP_GetExamTester2_Result item)
        {
            PropertyInfo[] sourceProperties = item.GetType().GetProperties();
            foreach (PropertyInfo sourcePi in sourceProperties)
            {
                PropertyInfo destinationPi = this.GetType().GetProperty(sourcePi.Name);
                destinationPi.SetValue(this, sourcePi.GetValue(item, null), null);
            }            
            return this;
        }

        public ExamTesterModel ToModel(USP_GetExamTester_Result item)
        {
            PropertyInfo[] sourceProperties = item.GetType().GetProperties();
            foreach (PropertyInfo sourcePi in sourceProperties)
            {
                PropertyInfo destinationPi = this.GetType().GetProperty(sourcePi.Name);
                destinationPi.SetValue(this, sourcePi.GetValue(item, null), null);
            }
            return this;
        }
    }
}
