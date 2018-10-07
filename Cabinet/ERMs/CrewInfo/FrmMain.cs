using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERMs.SharedBase;
using CrewInfo.Forms;
using DevExpress.XtraSplashScreen;
using ERMs.Data;
using CrewInfo.Menu;
using CrewInfo.Forms.VNCrew;
using CrewInfo.Forms.Task;
using CrewInfo.Forms.HealthCare;
using System.Reflection;
using CrewInfo.Forms.Analysis;
using CrewInfo.Forms.Exam;
using CrewInfo.Forms.Ticket;
using CrewInfo.Forms.Labor;
using CrewInfo.Forms.Briefing;
using CrewInfo.Forms.CHK;
using CrewInfo.Forms.Survey;
using CrewInfo.Forms.Ojt;
using Squirrel;
using System.IO;
using DevExpress.XtraNavBar;
using CrewInfo.Forms.ExternalUnit;
using CrewInfo.Forms.Meeting;
using CrewInfo.Forms.NghiMat;

namespace CrewInfo
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        public string mUserName;
        SystemDAL dbSystem = new SystemDAL();
        public Sys_Account account = null;
        private UpdateManager updateManager;
        public FrmMain()
        {
            InitializeComponent();

#if (DEBUG)
#else
            updateApp(false);
#endif            
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            LayoutInitial();
            UserInfoModel.lstCRUD = dbSystem.GetAllCRUDByUserID(ERMs.Sys.ConfigurationSetting.UserInfo.Userid);
            //UserInfoModel.lstCRUD = UserInfoModel.GetCRUID();
            //Initial();
            //treeView1.Nodes.Clear();
            //VNCrewMenu.GenerateMenuApp(treeView1, ERMs.Sys.ConfigurationSetting.UserInfo.Userid);            
            VNCrewMenu.GenerateMenuApp(navBar, ERMs.Sys.ConfigurationSetting.UserInfo.Userid);
            navBar.LinkClicked += NavBar_LinkClicked;
            if (treeView1.Nodes.Count > 0)
            {
                treeView1.Nodes[0].EnsureVisible();
            }
            //account = dbSystem.GetUserByUserName(mUserName);
            //if (account != null)
            //{

            //}

#if (DEBUG)
           // var frm = new FrmDutyFree();
            var frm = new FrmFlightFONetline();
            frm.MdiParent = this;
            frm.Show();            
#endif
            SplashScreenManager.CloseForm(false);
        }

        private void NavBar_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ShowMdi(e.Link.ItemName);
        }

        #region Methods

        private void LayoutInitial()
        {
            this.WindowState = FormWindowState.Maximized;
            //this.treeView1.Dock = DockStyle.Fill;
            this.treeView1.Visible = false;
            //this.navBar.Dock = DockStyle.Fill;
            navBar.LargeImages = icNodeGroup;
            navBar.SmallImages = icNodeChild;
            this.panelControl2.Dock = DockStyle.Fill;
            xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover;

            //User info (Staus Bar)
            txtBarUser.Caption = string.Format("{0} ({1})", ERMs.Sys.ConfigurationSetting.UserInfo.UserName, ERMs.Sys.ConfigurationSetting.UserInfo.Code);
            txtBarFullName.Caption = ERMs.Sys.ConfigurationSetting.UserInfo.FullName;
            txtBarDepartment.Caption = ERMs.Sys.ConfigurationSetting.UserInfo.Department;
            txtBarLoggedin.Caption = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            txtBarServer.Caption = string.Format("{0}*** ({1}@{2})", ERMs.Sys.ConfigurationSetting.Database.Server.Substring(0, 7), ERMs.Sys.ConfigurationSetting.Database.Catalog.ToUpper(), ERMs.Sys.ConfigurationSetting.Database.User.ToUpper());


            txtBarWorkingday.Caption = string.Format("{0:dd/MM/yyyy}", DateTime.Today);
            //txtBarWorkingday.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;

            //Assembly
            Version version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            //txtBarVersion.Caption = string.Format("Version {0}.{1}", version.Major, version.Minor);
            txtBarVersion.Caption = string.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Build);

            try
            {
                string aTitle = ((AssemblyTitleAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute), false)).Title;
                string aDescription = ((AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyDescriptionAttribute), false)).Description;
                //string company = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCompanyAttribute), false)).Company;
                this.Text = string.Format("{0} ({1})", aTitle, aDescription);
                
            }
            catch { }

            
        }

        private void Initial()
        {
            treeView1.ExpandAll();

        }
#endregion

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //TreeNode selectedNode = treeView1.SelectedNode;            
            /////Lead node
            //if (selectedNode.Nodes.Count > 0) return;

            //ShowMdi(selectedNode);
        }

        private void ShowMdi(TreeNode node)
        {
            //string nodeName = node.Name.ToUpper();
            //switch (nodeName)
            //{
            //    case "D.C.T.05":
            //        {
            //            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //            FrmFlightInfoSpec frmFlightInfoSpec = new FrmFlightInfoSpec();
            //            frmFlightInfoSpec.MdiParent = this;
            //            frmFlightInfoSpec.Show();
            //            SplashScreenManager.CloseForm(false);
            //            break;
            //        }
            //    case "D.C.T.06":
            //        {
            //            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //            FrmDutyFree frmDutyFree = new FrmDutyFree();
            //            frmDutyFree.MdiParent = this;
            //            frmDutyFree.Show();
            //            SplashScreenManager.CloseForm(false);
            //            break;
            //        }
            //    case "D.S.R.01":
            //        {
            //            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //            FrmRole frmRole = new FrmRole();
            //            frmRole.MdiParent = this;
            //            frmRole.Show();
            //            SplashScreenManager.CloseForm(false);
            //            break;
            //        }
            //    case "D.C.T.04":
            //        {
            //            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //            FrmFlightSync frmFlightSync = new FrmFlightSync();
            //            frmFlightSync.MdiParent = this;
            //            frmFlightSync.Show();
            //            SplashScreenManager.CloseForm(false);
            //            break;
            //        }
            //    case "D.S.U.01":
            //        {
            //            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //            FrmUser frmUser = new FrmUser();
            //            frmUser.MdiParent = this;
            //            frmUser.Show();
            //            SplashScreenManager.CloseForm(false);
            //            break;
            //        }
            //    case "D.S.D.01":
            //        {
            //            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //            FrmDevice frmDevice = new FrmDevice();
            //            frmDevice.MdiParent = this;
            //            frmDevice.Show();
            //            SplashScreenManager.CloseForm(false);
            //            break;
            //        }
            //    case "D.S.A.01":
            //        {
            //            SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //            FrmActivity frmActivity = new FrmActivity();
            //            frmActivity.MdiParent = this;
            //            frmActivity.Show();
            //            SplashScreenManager.CloseForm(false);
            //            break;
            //        }

            //    case "D.C.T.01":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmFlightForSalary frmSalFlt = new FrmFlightForSalary();
            //        frmSalFlt.MdiParent = this;
            //        frmSalFlt.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;

            //    case "D.C.T.02":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmSalAdmin frmSalAdmin = new FrmSalAdmin();
            //        frmSalAdmin.MdiParent = this;
            //        frmSalAdmin.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;

            //    case "D.C.T.03":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmAirlineCrew frmAirlineCrew = new FrmAirlineCrew();
            //        frmAirlineCrew.MdiParent = this;
            //        frmAirlineCrew.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;

            //    case "D.C.R.01":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmFlightFinalReport2 frmFlightFinalReport = new FrmFlightFinalReport2();
            //        frmFlightFinalReport.MdiParent = this;
            //        frmFlightFinalReport.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;

            //    case "D.C.A.01":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmFlightAssessment frmFlightAssessment = new FrmFlightAssessment();
            //        frmFlightAssessment.MdiParent = this;
            //        frmFlightAssessment.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;

            //    case "D.T.T.01":
            //         FrmManagementTask frmDT01 = new FrmManagementTask();
            //        frmDT01.MdiParent = this;
            //        frmDT01.Show();
            //        break;

            //    case "D.C.S.01":
            //        var frm = new FrmSupport();
            //        frm.MdiParent = this;
            //        frm.Show();
            //        break;

            //    case "D.C.F.01":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        var frmForm = new FrmForm();
            //        frmForm.MdiParent = this;
            //        frmForm.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;

            //    case "D.C.F.02":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        var frmFormCateogry = new FrmFormCategory();
            //        frmFormCateogry.MdiParent = this;
            //        frmFormCateogry.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;

            //    case "D.H.C.01":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmManagementHealthCare frmHealthCare = new FrmManagementHealthCare();
            //        frmHealthCare.MdiParent = this;
            //        frmHealthCare.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;

            //    case "D.C.R.03":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmFlightFinalReportCategory frmFlightFinalReportCategory = new FrmFlightFinalReportCategory();
            //        frmFlightFinalReportCategory.MdiParent = this;
            //        frmFlightFinalReportCategory.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;
            //    case "D.E.M.01":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmExam frmExam = new FrmExam();
            //        frmExam.MdiParent = this;
            //        frmExam.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;
            //    case "D.E.M.02":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmQuestionType frmQuestionType = new FrmQuestionType();
            //        frmQuestionType.MdiParent = this;
            //        frmQuestionType.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;
            //    case "D.E.M.03":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmBankingQuestion frmBankingQuestion = new FrmBankingQuestion();
            //        frmBankingQuestion.MdiParent = this;
            //        frmBankingQuestion.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;
            //    case "D.E.M.04":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmExamBankingTesting frmExamBankingTesting = new FrmExamBankingTesting();
            //        frmExamBankingTesting.MdiParent = this;
            //        frmExamBankingTesting.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;
            //    case "D.SV.C.01":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmSurveyCategory frmCHKCategory = new FrmSurveyCategory();
            //        frmCHKCategory.MdiParent = this;
            //        frmCHKCategory.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;
            //    case "D.SV.BI.01":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmSurveyBankingItem frmSurveyBankingItem = new FrmSurveyBankingItem();
            //        frmSurveyBankingItem.MdiParent = this;
            //        frmSurveyBankingItem.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;
            //    case "D.SV.S.01":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmSurvey frmSurvey = new FrmSurvey();
            //        frmSurvey.MdiParent = this;
            //        frmSurvey.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;
            //    case "D.L.F.01":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        var frmManageTicket = new FrmManageTicket();
            //        frmManageTicket.MdiParent = this;
            //        frmManageTicket.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;

            //    case "D.L.FD.01":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmManageFormDetail frmManageFormDetail = new FrmManageFormDetail();
            //        frmManageFormDetail.MdiParent = this;
            //        frmManageFormDetail.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;

            //    case "D.L.R.01":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmManageReport frmManageReport = new FrmManageReport();
            //        frmManageReport.MdiParent = this;
            //        frmManageReport.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;

            //    case "D.L.B.01":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmTicketBooking frmTicketBooking = new FrmTicketBooking();
            //        frmTicketBooking.MdiParent = this;
            //        frmTicketBooking.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;

            //    case "D.L.A.01":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmTicketAirport frmTicketAirport = new FrmTicketAirport();
            //        frmTicketAirport.MdiParent = this;
            //        frmTicketAirport.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;
            //    case "D.L.H.01":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmFormDetailHistory frmFormDetailHistory = new FrmFormDetailHistory();
            //        frmFormDetailHistory.MdiParent = this;
            //        frmFormDetailHistory.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;
                    

            //    case "D.B.D.01":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmBriefingDiary FrmBriefingDiary = new FrmBriefingDiary();
            //        FrmBriefingDiary.MdiParent = this;
            //        FrmBriefingDiary.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;

            //    case "D.O.C.01":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmOjtCategory FrmOjtCategory = new FrmOjtCategory();
            //        FrmOjtCategory.MdiParent = this;
            //        FrmOjtCategory.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;

            //    case "D.O.O.01":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmOJT FrmOJT = new FrmOJT();
            //        FrmOJT.MdiParent = this;
            //        FrmOJT.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;

            //    case "D.C.M.01":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmEmMessage FrmEmMessage = new FrmEmMessage();
            //        FrmEmMessage.MdiParent = this;
            //        FrmEmMessage.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;

            //    case "D.EU.F.01":
            //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //        FrmFlight FrmFlight = new FrmFlight();
            //        FrmFlight.MdiParent = this;
            //        FrmFlight.Show();
            //        SplashScreenManager.CloseForm(false);
            //        break;

            //    //#region System (User Role)
            //    //case "NODROLE":
            //    //    {
            //    //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //    //        FrmRole frmRole = new FrmRole();
            //    //        frmRole.MdiParent = this;
            //    //        frmRole.Show();
            //    //        SplashScreenManager.CloseForm(false);
            //    //        break;
            //    //    }
            //    //case "NODUSER":
            //    //    {
            //    //        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //    //        FrmUser frmUser = new FrmUser();
            //    //        frmUser.MdiParent = this;
            //    //        frmUser.Show();
            //    //        SplashScreenManager.CloseForm(false);
            //    //        break;
            //    //    }
            //    //#endregion

            //    //#region Salary

            //    //case "NODSAL.FLIGHT":
            //    //    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //    //    FrmFlightForSalary frmSalFlt = new FrmFlightForSalary();
            //    //    frmSalFlt.MdiParent = this;
            //    //    frmSalFlt.Show();
            //    //    SplashScreenManager.CloseForm(false);
            //    //    break;

            //    //case "NODSAL.PURSER":
            //    //    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
            //    //    FrmFlightForSalary frmSalPur = new FrmFlightForSalary();
            //    //    frmSalPur.Text = "Pursers";
            //    //    frmSalPur.MdiParent = this;
            //    //    frmSalPur.Show();
            //    //    SplashScreenManager.CloseForm(false);
            //    //    break;


            //    //#endregion


            //    //case "NODFLIGHTINFO":

            //    //    FrmFlightInfo frm = new FrmFlightInfo();
            //    //    //frm.Text = string.Format("{1}/ time {0}", count++, selectedNode);
            //    //    frm.MdiParent = this;
            //    //    frm.Show();
            //    //    break;

            //    //case "NODETEST":
            //    //    ERMs.SharedBase.XtraFormMDIBase frm2 = new XtraForm2();
            //    //    //frm.Text = string.Format("{1}/ time {0}", count++, selectedNode);
            //    //    frm2.MdiParent = this;
            //    //    frm2.Show();
            //    //    break;
            //    //case "nodJobPending":
            //    //     break;
            //    //case "nodJobRepairs":
            //    //     break;
            //    //case "nodJobCompletes":
            //    //     break;
            //    //case "nodComputers":
            //    //     break;
            //    //case "nodComputerPending":
            //    //      break;
            //    //case "nodComputerCompletes":
            //    //      break;
            //    //case "nodRadioPhones":
            //    //     break;
            //    //case "nodRadioPending":
            //    //    break;
            //    //case "nodRadioCompletes":
            //    //     break;

            //    //case "nodCardtridges":
            //    //     break;
            //    //case "nodCardtridgesPending":
            //    //     break;
            //    //case "nodCardtridgeCompletes":
            //    //     break;

            //    //case "nodCordless":
            //    //     break;
            //    //case "nodCordlessPending":
            //    //     break;
            //    //case "nodCordlessCompletes":
            //    //     break;

            //    //case "nodJobRepairsAll":
            //    //    break;

            //    //case "nodJobPublish":
            //    //    break;

            //    //case "nodOthers":
            //    //      break;
            //    //case "nodTrashes":
            //    //     break;
            //    default:
            //        MessageBox.Show("Click!");
            //         break;
            //}
        }

        private void ShowMdi(string nodeItemCode)
        {            
            switch (nodeItemCode)
            {
                case "D.C.T.05":
                    {
                        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                        FrmFlightInfoSpec frmFlightInfoSpec = new FrmFlightInfoSpec();
                        frmFlightInfoSpec.MdiParent = this;
                        frmFlightInfoSpec.Show();
                        SplashScreenManager.CloseForm(false);
                        break;
                    }
                case "D.C.T.06":
                    {
                        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                        FrmDutyFree frmDutyFree = new FrmDutyFree();
                        frmDutyFree.MdiParent = this;
                        frmDutyFree.Show();
                        SplashScreenManager.CloseForm(false);
                        break;
                    }
                case "D.S.R.01":
                    {
                        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                        FrmRole frmRole = new FrmRole();
                        frmRole.MdiParent = this;
                        frmRole.Show();
                        SplashScreenManager.CloseForm(false);
                        break;
                    }
                case "D.C.T.04":
                    {
                        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                        FrmFlightSync frmFlightSync = new FrmFlightSync();
                        frmFlightSync.MdiParent = this;
                        frmFlightSync.Show();
                        SplashScreenManager.CloseForm(false);
                        break;
                    }
                case "D.S.U.01":
                    {
                        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                        FrmUser frmUser = new FrmUser();
                        frmUser.MdiParent = this;
                        frmUser.Show();
                        SplashScreenManager.CloseForm(false);
                        break;
                    }
                case "D.S.D.01":
                    {
                        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                        FrmDevice frmDevice = new FrmDevice();
                        frmDevice.MdiParent = this;
                        frmDevice.Show();
                        SplashScreenManager.CloseForm(false);
                        break;
                    }
                case "D.S.A.01":
                    {
                        SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                        FrmActivity frmActivity = new FrmActivity();
                        frmActivity.MdiParent = this;
                        frmActivity.Show();
                        SplashScreenManager.CloseForm(false);
                        break;
                    }

                case "D.C.T.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmFlightForSalary frmSalFlt = new FrmFlightForSalary();
                    frmSalFlt.MdiParent = this;
                    frmSalFlt.Show();
                    SplashScreenManager.CloseForm(false);
                    break;

                case "D.C.T.02":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmSalAdmin frmSalAdmin = new FrmSalAdmin();
                    frmSalAdmin.MdiParent = this;
                    frmSalAdmin.Show();
                    SplashScreenManager.CloseForm(false);
                    break;

                case "D.C.T.03":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmAirlineCrew frmAirlineCrew = new FrmAirlineCrew();
                    frmAirlineCrew.MdiParent = this;
                    frmAirlineCrew.Show();
                    SplashScreenManager.CloseForm(false);
                    break;

                case "D.C.R.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmFlightFinalReport2 frmFlightFinalReport = new FrmFlightFinalReport2();
                    frmFlightFinalReport.MdiParent = this;
                    frmFlightFinalReport.Show();
                    SplashScreenManager.CloseForm(false);
                    break;

                case "D.C.A.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmFlightAssessment frmFlightAssessment = new FrmFlightAssessment();
                    frmFlightAssessment.MdiParent = this;
                    frmFlightAssessment.Show();
                    SplashScreenManager.CloseForm(false);
                    break;

                case "D.T.T.01":
                    FrmManagementTask frmDT01 = new FrmManagementTask();
                    frmDT01.MdiParent = this;
                    frmDT01.Show();
                    break;

                case "D.C.S.01":
                    var frm = new FrmSupport();
                    frm.MdiParent = this;
                    frm.Show();
                    break;

                case "D.C.F.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    var frmForm = new FrmForm();
                    frmForm.MdiParent = this;
                    frmForm.Show();
                    SplashScreenManager.CloseForm(false);
                    break;

                case "D.C.F.02":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    var frmFormCateogry = new FrmFormCategory();
                    frmFormCateogry.MdiParent = this;
                    frmFormCateogry.Show();
                    SplashScreenManager.CloseForm(false);
                    break;

                case "D.H.C.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmManagementHealthCare frmHealthCare = new FrmManagementHealthCare();
                    frmHealthCare.MdiParent = this;
                    frmHealthCare.Show();
                    SplashScreenManager.CloseForm(false);
                    break;

                case "D.C.R.03":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmFlightFinalReportCategory frmFlightFinalReportCategory = new FrmFlightFinalReportCategory();
                    frmFlightFinalReportCategory.MdiParent = this;
                    frmFlightFinalReportCategory.Show();
                    SplashScreenManager.CloseForm(false);
                    break;
                case "D.E.M.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmExam frmExam = new FrmExam();
                    frmExam.MdiParent = this;
                    frmExam.Show();
                    SplashScreenManager.CloseForm(false);
                    break;
                case "D.E.M.02":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmQuestionType frmQuestionType = new FrmQuestionType();
                    frmQuestionType.MdiParent = this;
                    frmQuestionType.Show();
                    SplashScreenManager.CloseForm(false);
                    break;
                case "D.E.M.03":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmBankingQuestion frmBankingQuestion = new FrmBankingQuestion();
                    frmBankingQuestion.MdiParent = this;
                    frmBankingQuestion.Show();
                    SplashScreenManager.CloseForm(false);
                    break;
                case "D.E.M.04":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmExamBankingTesting frmExamBankingTesting = new FrmExamBankingTesting();
                    frmExamBankingTesting.MdiParent = this;
                    frmExamBankingTesting.Show();
                    SplashScreenManager.CloseForm(false);
                    break;
                case "D.SV.C.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmSurveyCategory frmCHKCategory = new FrmSurveyCategory();
                    frmCHKCategory.MdiParent = this;
                    frmCHKCategory.Show();
                    SplashScreenManager.CloseForm(false);
                    break;
                case "D.SV.BI.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmSurveyBankingItem frmSurveyBankingItem = new FrmSurveyBankingItem();
                    frmSurveyBankingItem.MdiParent = this;
                    frmSurveyBankingItem.Show();
                    SplashScreenManager.CloseForm(false);
                    break;
                case "D.SV.S.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmSurvey frmSurvey = new FrmSurvey();
                    frmSurvey.MdiParent = this;
                    frmSurvey.Show();
                    SplashScreenManager.CloseForm(false);
                    break;
                case "D.L.F.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    var frmManageTicket = new FrmManageTicket();
                    frmManageTicket.MdiParent = this;
                    frmManageTicket.Show();
                    SplashScreenManager.CloseForm(false);
                    break;

                case "D.L.FD.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmManageFormDetail frmManageFormDetail = new FrmManageFormDetail();
                    frmManageFormDetail.MdiParent = this;
                    frmManageFormDetail.Show();
                    SplashScreenManager.CloseForm(false);
                    break;

                case "D.L.R.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmManageReport frmManageReport = new FrmManageReport();
                    frmManageReport.MdiParent = this;
                    frmManageReport.Show();
                    SplashScreenManager.CloseForm(false);
                    break;

                case "D.L.B.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmTicketBooking frmTicketBooking = new FrmTicketBooking();
                    frmTicketBooking.MdiParent = this;
                    frmTicketBooking.Show();
                    SplashScreenManager.CloseForm(false);
                    break;

                case "D.L.A.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmTicketAirport frmTicketAirport = new FrmTicketAirport();
                    frmTicketAirport.MdiParent = this;
                    frmTicketAirport.Show();
                    SplashScreenManager.CloseForm(false);
                    break;
                case "D.L.H.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmFormDetailHistory frmFormDetailHistory = new FrmFormDetailHistory();
                    frmFormDetailHistory.MdiParent = this;
                    frmFormDetailHistory.Show();
                    SplashScreenManager.CloseForm(false);
                    break;


                case "D.B.D.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmBriefingDiary FrmBriefingDiary = new FrmBriefingDiary();
                    FrmBriefingDiary.MdiParent = this;
                    FrmBriefingDiary.Show();
                    SplashScreenManager.CloseForm(false);
                    break;

                case "D.O.C.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmOjtCategory FrmOjtCategory = new FrmOjtCategory();
                    FrmOjtCategory.MdiParent = this;
                    FrmOjtCategory.Show();
                    SplashScreenManager.CloseForm(false);
                    break;

                case "D.O.O.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmOJT FrmOJT = new FrmOJT();
                    FrmOJT.MdiParent = this;
                    FrmOJT.Show();
                    SplashScreenManager.CloseForm(false);
                    break;

                case "D.C.M.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmEmMessage FrmEmMessage = new FrmEmMessage();
                    FrmEmMessage.MdiParent = this;
                    FrmEmMessage.Show();
                    SplashScreenManager.CloseForm(false);
                    break;
                case "D.EU.F.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmFlight FrmFlight = new FrmFlight();
                    FrmFlight.MdiParent = this;
                    FrmFlight.Show();
                    SplashScreenManager.CloseForm(false);
                    break;
                case "D.N.T.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmTour FrmTour = new FrmTour();
                    FrmTour.MdiParent = this;
                    FrmTour.Show();
                    SplashScreenManager.CloseForm(false);
                    break;
                case "D.N.R.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmTourRegister FrmTourRegister = new FrmTourRegister();
                    FrmTourRegister.MdiParent = this;
                    FrmTourRegister.Show();
                    SplashScreenManager.CloseForm(false);
                    break;
                case "D.M.F.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmMeeting FrmMeeting = new FrmMeeting();
                    FrmMeeting.MdiParent = this;
                    FrmMeeting.Show();
                    SplashScreenManager.CloseForm(false);
                    break;
                case "D.M.D.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmMeetingData FrmMeetingData = new FrmMeetingData();
                    FrmMeetingData.MdiParent = this;
                    FrmMeetingData.Show();
                    SplashScreenManager.CloseForm(false);
                    break;
                case "D.C.N.01":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmNews FrmNews = new FrmNews();
                    FrmNews.MdiParent = this;
                    FrmNews.Show();
                    SplashScreenManager.CloseForm(false);
                    break;
                case "D.C.T.07":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmFlightNetLine FrmFlightNetLine = new FrmFlightNetLine();
                    FrmFlightNetLine.MdiParent = this;
                    FrmFlightNetLine.Show();
                    SplashScreenManager.CloseForm(false);
                    break;
                case "D.C.T.08":
                    SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                    FrmFlightFONetline frmFoOcc = new FrmFlightFONetline();
                    frmFoOcc.MdiParent = this;
                    frmFoOcc.Show();
                    SplashScreenManager.CloseForm(false);
                    break;
                default:
                    MessageBox.Show("Click!");
                    break;
            }
        }

        private void mnbSabreManagement_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //FrmSabreConfig frm = new FrmSabreConfig();

            //frm.ShowInTaskbar = false;
            //frm.ShowDialog();

        }

        private void btnHideNav_Click(object sender, EventArgs e)
        {
            //foreach (var item in this.MdiChildren)
            //{
            //    //FrmFlightInfo fr = (FrmFlightInfo)item.FindForm();
            //    //fr.HideNav();
            //    return;
            //}
             
        }

        private void btnShowNav_Click(object sender, EventArgs e)
        {
            foreach (var item in this.MdiChildren)
            {
                XtraFormMDIBase fr = (XtraFormMDIBase)item.FindForm();
                fr.ShowNav();
                return;
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmSignIn frm;
            frm = new FrmSignIn();
            if (frm.ShowDialog() != DialogResult.OK)
                Application.Exit();
            else
            {
                mUserName = frm.mUserName;
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //TreeNode selectedNode = treeView1.SelectedNode;
            TreeNode selectedNode = e.Node;
            ///Lead node
            if (selectedNode.Nodes.Count > 0) return;

            ShowMdi(selectedNode);
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
#if (DEBUG)
#else
            if (updateManager != null)
                updateManager.Dispose();
#endif
        }

        private void bbiUpdateApp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            updateApp(true);
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            updateApp(true);
        }

        private void updateApp(bool thongBao)
        {
            Version version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            FileInfo fi = new FileInfo(@"\\10.105.2.243\Publish\ERMs\RELEASES");
            if (fi.Exists)
            {
                Task.Run(async () =>
                {
                    try
                    {
                        using (updateManager = new UpdateManager(@"\\10.105.2.243\Publish\ERMs"))
                        {
                            try
                            {
                                var updateInfo = await updateManager.CheckForUpdate();
                                if (updateInfo.ReleasesToApply.Any())
                                {
                                    await updateManager.UpdateApp();
                                    if (thongBao)
                                    {
                                        MessageBox.Show($"Bản cập nhật mới đã được cài đặt thành công. Vui lòng tắt chương trình VNC và mở lại.");
                                    }
                                }
                                else
                                {
                                    if (thongBao)
                                    {
                                        MessageBox.Show("Không có bản cập nhật mới.");
                                    }                                    
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    { }
                });
            }
            else
            {
                Task.Run(async () =>
                {
                    try
                    {
                        using (updateManager = new UpdateManager(@"http://portal.doantiepvien.com.vn/erms"))
                        //using (updateManager = new UpdateManager(@"http://portal.doantiepvien.com.vn/cabincrew"))
                        {
                            var updateInfo = await updateManager.CheckForUpdate();
                            if (updateInfo.ReleasesToApply.Any())
                            {
                                await updateManager.UpdateApp();
                                if (thongBao)
                                {
                                    MessageBox.Show($"Bản cập nhật mới đã được cài đặt thành công. Vui lòng tắt chương trình VNC và mở lại.");
                                }
                            }
                            else
                            {
                                if (thongBao)
                                {
                                    MessageBox.Show("Không có bản cập nhật mới.");
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                });
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmServer frmServer = new FrmServer();
            frmServer.ShowDialog();
        }
    }

}