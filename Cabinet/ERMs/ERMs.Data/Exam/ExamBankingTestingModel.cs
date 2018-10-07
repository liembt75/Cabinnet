using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class ExamBankingTestingModel : Exam_Banking_Testing
    {
        public struct CategoryPB
        {
            public int ID;
            public string Name;
            public string Code;
        }

        //public List<CategoryPB> _lstInitCategory = new List<CategoryPB>()
        //{
        //    new CategoryPB() { ID = 99, Code="D.E.M.C.99", Name="LĐPB" },
        //    new CategoryPB() { ID = 98, Code="D.E.M.C.98", Name="LĐPN" }
        //};

        //public List<CategoryPB> GetListCategoryByPermission()
        //{
        //    ExamDal db = new ExamDal();
        //    //return db.GetListCategoryByPermission();
        //    return null;
        //}

        public BindingList<Exam_Banking_Testing_Section> ExamBankingTestingSection { get; set; }

        public ExamBankingTestingModel ToModel(Exam_Banking_Testing item)
        {
            PropertyInfo[] sourceProperties = item.GetType().GetProperties();
            foreach (PropertyInfo sourcePi in sourceProperties)
            {
                PropertyInfo destinationPi = this.GetType().GetProperty(sourcePi.Name);
                destinationPi.SetValue(this, sourcePi.GetValue(item, null), null);
            }            
            return this;
        }

        public Exam_Banking_Testing ToReverseModel()
        {
            Exam_Banking_Testing returnValue = new Exam_Banking_Testing();
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
