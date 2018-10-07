using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class ExamBankingQuestionModel : Exam_Banking_Question
    {
        public BindingList<Exam_Banking_Answer> ExamBankingAnswer { get; set; }

        public ExamBankingQuestionModel ToModel(Exam_Banking_Question item)
        {
            PropertyInfo[] sourceProperties = item.GetType().GetProperties();
            foreach (PropertyInfo sourcePi in sourceProperties)
            {
                PropertyInfo destinationPi = this.GetType().GetProperty(sourcePi.Name);
                destinationPi.SetValue(this, sourcePi.GetValue(item, null), null);
            }
            //this.ExamBankingAnswer = new ExamDal().GetExamBankingAnswer(item.ID);
            return this;
        }

        public Exam_Banking_Question ToReverseModel()
        {
            Exam_Banking_Question returnValue = new Exam_Banking_Question();
            PropertyInfo[] sourceProperties = returnValue.GetType().GetProperties();
            foreach (PropertyInfo sourcePi in sourceProperties)
            {
                PropertyInfo destinationPi = returnValue.GetType().GetProperty(sourcePi.Name);
                destinationPi.SetValue(returnValue, sourcePi.GetValue(this, null), null);
            }
            return returnValue;
        }
    }
}
