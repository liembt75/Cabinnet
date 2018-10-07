using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    public class ExamDal
    {
        public List<ExamTesterModel> GetExamTester(DateTime? fromdate, DateTime? todate)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                List<ExamTesterModel> items = new List<ExamTesterModel>();
                var query = context.USP_GetExamTester(fromdate, todate);
                foreach (var item in query)
                {
                    items.Add(new ExamTesterModel().ToModel(item));
                }
                return items;
                //return context.USP_GetExamTester(fromdate, todate).ToList();                
            }
        }

        public List<ExamTesterModel> GetExamTester(DateTime? fromdate, DateTime? todate, List<int> categories)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                List<ExamTesterModel> items = new List<ExamTesterModel>();
                //var query;
                List<USP_GetExamTester2_Result> lstExamTester = new List<USP_GetExamTester2_Result>();
                foreach (var category in categories)
                {
                    lstExamTester.AddRange(context.USP_GetExamTester2(fromdate, todate, category.ToString()));
                }
                foreach (var item in lstExamTester)
                {
                    items.Add(new ExamTesterModel().ToModel(item));
                }
                return items;
                //var query = context.USP_GetExamTester(fromdate, todate);
                //foreach (var item in query)
                //{
                //    items.Add(new ExamTesterModel().ToModel(item));
                //}
                //return items;
                //return context.USP_GetExamTester(fromdate, todate).ToList();                
            }
        }

        public List<Exam_QuestionType> GetQuestionType(bool? active)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Exam_QuestionType.Where(q => active == null || q.Active == active).ToList();
            }
        }

        

        public List<ExamBankingTestingModel> GetExamBankingTesting(List<int> categories, DateTime? fromdate, DateTime? todate)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                List<ExamBankingTestingModel> items = new List<ExamBankingTestingModel>();
                var list = context.Exam_Banking_Testing.Where(i => i.StartTime == null || (i.StartTime >= fromdate && i.StartTime <= todate)).OrderBy(i => i.StartTime).ToList();                
                foreach (var item in list)
                {
                    if( categories.Contains(item.Category.HasValue?item.Category.Value:0))
                        items.Add(new ExamBankingTestingModel().ToModel(item));
                }
                return items;
            }
        }

        public List<ExamBankingQuestionModel> GetBankingQuestion(int questionType, string question)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                List<ExamBankingQuestionModel> items = new List<ExamBankingQuestionModel>();
                var query = context.Exam_Banking_Question.Where(q => (questionType == -1 || q.QuestionType == questionType) && q.Question.Contains(question)).OrderByDescending(q => q.Modified).ThenByDescending(q => q.Created);
                //var query = context.API_CR_USP_GetFlight_ByKeyword(fromdate, todate, keyword, crewID, isGetAll, pageNumber, pageSize);            
                //var query = context.CR_FlightInfo.Where(o => o.Date >= fromdate && o.Date <= todate && (o.IsDeleted == null || (o.IsDeleted != null && o.IsDeleted != true)));
                foreach (var item in query)
                {
                    items.Add(new ExamBankingQuestionModel().ToModel(item));
                }
                return items;
            }
        }

        public object GetBankingQuestion(int questionType, string question, List<Exam_QuestionType> lstQuestionType)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                List<ExamBankingQuestionModel> items = new List<ExamBankingQuestionModel>();
                var query = context.Exam_Banking_Question.Where(q => (questionType == -1 || q.QuestionType == questionType) && q.Question.Contains(question)).OrderByDescending(q => q.Modified).ThenByDescending(q => q.Created);
                //var query = context.API_CR_USP_GetFlight_ByKeyword(fromdate, todate, keyword, crewID, isGetAll, pageNumber, pageSize);            
                //var query = context.CR_FlightInfo.Where(o => o.Date >= fromdate && o.Date <= todate && (o.IsDeleted == null || (o.IsDeleted != null && o.IsDeleted != true)));
                foreach (var item in query)
                {
                    var temp = lstQuestionType.Where(i => i.ID == item.QuestionType).FirstOrDefault();
                    if (temp != null)
                        items.Add(new ExamBankingQuestionModel().ToModel(item));
                }
                return items;
            }
        }

        public Exam_QuestionType UpdateQuestionType(Exam_QuestionType item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                if (item.ID == 0)
                {
                    item.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Created = DateTime.Now;                    
                    context.Exam_QuestionType.Add(item);
                }
                else
                {
                    Exam_QuestionType model = context.Exam_QuestionType.Where(o => o.ID == item.ID).FirstOrDefault();
                    if (model != null)
                    {
                        model.Title = item.Title;
                        model.Description = item.Description;
                        model.Active = item.Active;
                        model.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                        model.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                        model.Modified = DateTime.Now;
                    }
                }

                context.SaveChanges();
                return item;
            }
        }

        

        public void DelelteFinishDate(int iD)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                Exam_Tester ex = context.Exam_Tester.Where(q => q.ID == iD).FirstOrDefault();
                if (ex != null)
                    ex.FinishDate = null;
                context.SaveChanges();
            }
        }

        public void DeleteExam(int iD)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                Exam_Tester ex = context.Exam_Tester.Where(q => q.ID == iD).FirstOrDefault();
                context.Exam_Tester.Remove(ex);                
                context.SaveChanges();
            }
        }

        public Exam_Banking_Question UpdateExamBankingQuestion(Exam_Banking_Question item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                if (item.ID == 0)
                {
                    item.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Created = DateTime.Now;                    
                    context.Exam_Banking_Question.Add(item);
                }
                else
                {
                    Exam_Banking_Question model = context.Exam_Banking_Question.Where(o => o.ID == item.ID).FirstOrDefault();
                    if (model != null)
                    {
                        model.QuestionType = item.QuestionType;
                        model.Question = item.Question;
                        model.CrewType = item.CrewType;
                        model.Aircraft = item.Aircraft;
                        model.Note = item.Note;                        
                        model.Active = item.Active;
                        model.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                        model.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                        model.Modified = DateTime.Now;
                    }
                }

                context.SaveChanges();
                return item;
            }
        }

        

        public void UpdateExamineeBanking(List<ExamineeModel> lstExaminee, List<ExamineeModel> lstDelExaminee)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                foreach (ExamineeModel ex in lstDelExaminee)
                {
                    Examinee_Banking eb = context.Examinee_Banking.Where(e => e.CID == ex.CrewID).FirstOrDefault();
                    if (eb != null)
                    {
                        eb.BankTest_ID = -1;
                    }
                }
                foreach (ExamineeModel ex in lstExaminee)
                {
                    Examinee_Banking eb = context.Examinee_Banking.Where(e => e.CID == ex.CrewID).FirstOrDefault();
                    if (eb != null)
                    {
                        eb.BankTest_ID = ex.BankTestID;
                    }
                    else
                    {
                        eb = new Examinee_Banking();
                        eb.CID = ex.CrewID;
                        eb.BankTest_ID = ex.BankTestID;
                        context.Examinee_Banking.Add(eb);
                    }
                }                
                context.SaveChanges();
            }
        }

        public Exam_Banking_Testing GetExamBankingTestingByID(int iD)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {                
                return context.Exam_Banking_Testing.Where(q => q.ID == iD).FirstOrDefault();                
            }
        }

        public Exam_Banking_Testing UpdateExamBankingTesting(Exam_Banking_Testing item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                //Generate code, unique in 3 days
                Random rand = new Random();
                string code = "";
                while (true)
                {
                    code = rand.Next(1000, 9999).ToString();
                    if (!item.StartTime.HasValue) break; // ko can code

                    var items = context.Exam_Banking_Testing.AsEnumerable().Where(o => o.Code == code && item.StartTime > DateTime.Today.AddDays(-30)).ToList();
                    if (items == null|| items.Count == 0) break;
                }

                item.Code = code;

                if (item.ID == 0)
                {
                    item.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Created = DateTime.Now;
                    context.Exam_Banking_Testing.Add(item);
                }
                else
                {
                    Exam_Banking_Testing model = context.Exam_Banking_Testing.Where(o => o.ID == item.ID).FirstOrDefault();
                    if (model != null)
                    {
                        model.Category = item.Category;
                        model.Code = item.Code;
                        model.Title = item.Title;
                        model.Description = item.Description;
                        model.StartTime = item.StartTime;
                        model.Duration = item.Duration;
                        //model.Amount = item.Amount;
                        model.ScoreExpec = item.ScoreExpec;                        
                        model.Note = item.Note;
                        model.Active = item.Active;
                        model.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                        model.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                        model.Modified = DateTime.Now;
                    }
                }

                context.SaveChanges();
                return item;
            }
        }

        public Exam_Banking_Testing_Section UpdateExamBankingTestingSection(Exam_Banking_Testing_Section item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                if (item.ID == 0)
                {
                    item.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Created = DateTime.Now;
                    context.Exam_Banking_Testing_Section.Add(item);
                }
                else
                {
                    Exam_Banking_Testing_Section model = context.Exam_Banking_Testing_Section.Where(o => o.ID == item.ID).FirstOrDefault();
                    if (model != null)
                    {                        
                        model.QuestionBankType = item.QuestionBankType;
                        model.Amount = item.Amount;
                        model.Note = item.Note;
                        model.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                        model.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                        model.Modified = DateTime.Now;
                    }
                }

                context.SaveChanges();
                return item;
            }
        }

        public List<Exam_Banking_Testing_Section> GetExamBankingTestingSection(int iD)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Exam_Banking_Testing_Section.Where(q => q.BankTest_ID == iD).ToList();
            }
        }

        public List<Exam_Banking_Answer> GetExamBankingAnswer(int QuestionID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.Exam_Banking_Answer.Where(q => q.QuestionID == QuestionID).ToList();
            }
        }

        public Exam_Banking_Answer UpdateExamBankingAnswer(Exam_Banking_Answer item)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                if (item.ID == 0)
                {
                    item.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                    item.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                    item.Created = DateTime.Now;
                    context.Exam_Banking_Answer.Add(item);
                }
                else
                {
                    Exam_Banking_Answer model = context.Exam_Banking_Answer.Where(o => o.ID == item.ID).FirstOrDefault();
                    if (model != null)
                    {
                        model.QuestionID = item.QuestionID;
                        model.Answer = item.Answer;
                        model.isCorrect = item.isCorrect;                        
                        model.Note = item.Note;
                        model.Active = item.Active;
                        model.Modifier = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                        model.Modifierid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                        model.Modified = DateTime.Now;
                    }
                }

                context.SaveChanges();
                return item;
            }
        }

        public List<Sys_Account> GetSysAccount(List<string> lstMSNV, List<string> lstTen)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                var query = context.Sys_Account.Where(q => q.IsDeleted != null || q.IsDeleted != true);
                if (lstMSNV.Count > 0)
                {
                    query = query.Where(q => lstMSNV.Any(f => q.CrewID.Contains(f)));
                }
                if (lstTen.Count > 0)
                {
                    query = query.Where(q => lstTen.Any(f => q.FirstNameVn.Contains(f)));
                }
                return query.ToList();
            }
        }

        public List<ExamineeModel> GetExaminee(List<string> lstMSNV, List<string> lstTen)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                var query = context.Sys_Account.Where(q => q.IsDeleted != null || q.IsDeleted != true);
                if (lstMSNV.Count > 0)
                {
                    query = query.Where(q => lstMSNV.Any(f => q.CrewID.Contains(f)));
                }
                if (lstTen.Count == 1)
                {
                    query = query.Where(q => lstTen.Any(f => q.FirstNameVn.Contains(f)));
                }
                if (lstTen.Count > 1)
                {
                    query = query.Where(q => lstTen.Any(f => q.FirstNameVn == f));
                }
                return query.Select(q => new ExamineeModel { CrewID = q.CrewID, FirstNameVn = q.FirstNameVn, LastNameVn = q.LastNameVn}).ToList();
            }
        }

        public List<ExamineeModel> GetAddedExaminee(int iBankTestID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                var query = from e in context.Examinee_Banking
                            where e.BankTest_ID == iBankTestID
                            join a in context.Sys_Account on e.CID equals a.CrewID into g
                            from result in g.DefaultIfEmpty()
                            select new ExamineeModel { CrewID = e.CID, FirstNameVn = result.FirstNameVn, LastNameVn = result.LastNameVn, BankTestID = e.BankTest_ID };                
                return query.ToList();
            }
        }

        public List<ExamQuestionModel> GetExamQuestionByExamTesterID(int examTesterID)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                return context.USP_GetExamByExamTesterID(examTesterID).Select(t => new ExamQuestionModel { RowNumber = t.RowNumber.ToString(), ID = t.ID, Question = t.Question, isCorrect = t.isCorrect, Answer = t.Answer, DapAn = t.DapAn }).ToList();
                //var query = from e in context.Exam_Question
                //            where e.ExamTester_ID == examTesterID
                //            join a in context.Exam_Answer.Where(c => c.Chosen == true) on e.ID equals a.ExamQues_ID into g                            
                //            from result in g.DefaultIfEmpty()
                //            orderby e.ID
                //            select new ExamQuestionModel { ID = e.ID, Question = e.Question, isCorrect = result.isCorrect, Answer = result.Answer };
                //return query.ToList();
            }
        }

        public void SaveQuestion(List<ExamBankingQuestionModel> lstquestion)
        {
            using (ERMSEntities context = new ERMSEntities(ERMs.Sys.ConfigurationSetting.Database.ConnectionStringforERMSModel))
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var question in lstquestion)
                        {
                            Exam_Banking_Question questionAdd = question.ToReverseModel();
                            questionAdd.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                            questionAdd.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                            questionAdd.Created = DateTime.Now;
                            context.Exam_Banking_Question.Add(questionAdd);
                            context.SaveChanges();
                            foreach (var answer in question.ExamBankingAnswer)
                            {
                                answer.QuestionID = questionAdd.ID;
                                answer.Creator = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
                                answer.Creatorid = ERMs.Sys.ConfigurationSetting.UserInfo.Code;
                                answer.Created = DateTime.Now;
                                context.Exam_Banking_Answer.Add(answer);
                            }
                        }
                        context.SaveChanges();
                        //dbContextTransaction.Rollback();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }

                }
            }
        }
    }
}
