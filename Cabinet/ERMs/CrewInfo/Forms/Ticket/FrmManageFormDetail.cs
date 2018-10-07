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
using ERMs.Data;
using Erms.Utils;
using System.Collections;
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;

namespace CrewInfo.Forms.Ticket
{
    public partial class FrmManageFormDetail : ERMs.SharedBase.XtraFormMDIBase
    {
        TicketDal db = new TicketDal();
        public FrmManageFormDetail()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            List<string> lstTicketType = new List<string>();
            foreach(var ticket in ERMs.Data.TicketModel.DicTicketType)
            {
                lstTicketType.Add(ticket.Key);
            }
            lstTicketType.Insert(0, null);
            comboBoxBase.SelectedIndex = 0;
            lookUpEditTicketType.Properties.DataSource = lstTicketType;            
            //UpdateGrid();
            cbxEmployeeType.Properties.Items.AddRange(EmployeeModel.DicEmployeeType.Select(e => e.Key).ToList());            
        }

        private void UpdateGrid()
        {
            string ticketType = lookUpEditTicketType.EditValue == null ? null : lookUpEditTicketType.EditValue.ToString();
            string ticketBase = comboBoxBase.EditValue == null ? null : comboBoxBase.EditValue.ToString();
            int? employeeType = null;
            if (cbxEmployeeType.SelectedItem != null && cbxEmployeeType.SelectedItem.ToString() != "")
                employeeType = (int)EmployeeModel.DicEmployeeType[cbxEmployeeType.SelectedItem.ToString()];
            int? iYearFrom = null;
            int? iYearTo = null;
            try
            {
                iYearFrom = int.Parse(yearFrom.Text);                
            } catch { }
            try
            {
                iYearTo = int.Parse(yearTo.Text);
            }
            catch { }            
            gridControl1.DataSource = db.GetTicketFormDetail(ticketType, ticketBase, employeeType, iYearFrom, iYearTo);
        }

        private void lookUpEditTicketType_EditValueChanged(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void yearTo_EditValueChanged(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void yearFrom_EditValueChanged(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void comboBoxBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void printReport_Click(object sender, EventArgs e)
        {
            try
            {
                //StringBuilder error = new StringBuilder();
                //if (lookUpEditTicketType.EditValue == null)
                //{
                //    error.Append("- Vui lòng chọn loại vé cần xuất!\r\n");
                //    //MessageBox.Show("Vui lòng chọn loại vé cần xuất!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    //return;
                //}
                //if (cbxEmployeeType.SelectedItem == null || string.IsNullOrEmpty(cbxEmployeeType.SelectedItem.ToString()))
                //{
                //    error.Append("- Bạn chưa chọn loại nhân viên!\r\n");
                //    //MessageBox.Show("Bạn chưa chọn loại nhân viên!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    //return;
                //}
                //if (comboBoxBase.EditValue == null)
                //{
                //    error.Append("- Bạn chưa chọn nơi xuất vé!\r\n");
                //    //MessageBox.Show("Bạn chưa chọn nơi xuất vé!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    //return;
                //}
                //if (gridView1.GetSelectedRows().Length <= 0)
                //{
                //    error.Append("- Bạn chưa chọn mục nào để in ra!\r\n");
                //    //MessageBox.Show("Bạn chưa chọn mục nào để in ra!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    //return;
                //}
                //if (error.Length > 0)
                //{
                //    MessageBox.Show(error.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}


                SplashScreenManager.ShowForm(this, typeof(WaitFormDefault), true, true, false);
                List<ReportModel> lstReport = new List<ReportModel>();

                List<USP_GetFromDetail1_Result> lstTicketTVTrongCheDo = db.GetTicketFormDetail("ID90", "SGN", (int)EmployeeModel.EmployeeType.TiepVien, null, null);
                lstTicketTVTrongCheDo.AddRange(db.GetTicketFormDetail("ID75", "SGN", (int)EmployeeModel.EmployeeType.TiepVien, null, 10));
                lstReport.AddRange(FormReportModel.GetListReport(lstTicketTVTrongCheDo, ReportModel.ReportType.TCTV));
                //ReportModel reportModelTVTrongCheDo = SaveAndPrintReport(lstTicketTVTrongCheDo, ReportModel.ReportType.TCTV);

                List<USP_GetFromDetail1_Result> lstTicketTVNgoaiCheDo = db.GetTicketFormDetail("ID75", "SGN", (int)EmployeeModel.EmployeeType.TiepVien, 10, null);
                lstTicketTVNgoaiCheDo.AddRange(db.GetTicketFormDetail("ID50", "SGN", (int)EmployeeModel.EmployeeType.TiepVien, null, null));
                lstReport.AddRange(FormReportModel.GetListReport(lstTicketTVNgoaiCheDo, ReportModel.ReportType.KTCTV));
                //ReportModel reportModelTVNgoaiCheDo = SaveAndPrintReport(lstTicketTVNgoaiCheDo, ReportModel.ReportType.KTCTV);

                List<USP_GetFromDetail1_Result> lstTicketMDTrongCheDo = db.GetTicketFormDetail("ID90", "SGN", (int)EmployeeModel.EmployeeType.MatDat, null, null);
                lstTicketMDTrongCheDo.AddRange(db.GetTicketFormDetail("ID75", "SGN", (int)EmployeeModel.EmployeeType.MatDat, null, 10));
                lstReport.AddRange(FormReportModel.GetListReport(lstTicketMDTrongCheDo, ReportModel.ReportType.TCMD));
                //ReportModel reportModelMDTrongCheDo = SaveAndPrintReport(lstTicketMDTrongCheDo, ReportModel.ReportType.TCMD);

                List<USP_GetFromDetail1_Result> lstTickettMDNgoaiCheDo = db.GetTicketFormDetail("ID75", "SGN", (int)EmployeeModel.EmployeeType.MatDat, 10, null);
                lstTickettMDNgoaiCheDo.AddRange(db.GetTicketFormDetail("ID50", "SGN", (int)EmployeeModel.EmployeeType.MatDat, null, null));
                lstReport.AddRange(FormReportModel.GetListReport(lstTickettMDNgoaiCheDo, ReportModel.ReportType.KTCMD));
                //ReportModel reportModelMDNgoaiCheDo = SaveAndPrintReport(lstTickettMDNgoaiCheDo, ReportModel.ReportType.KTCMD);

                List<USP_GetFromDetail1_Result> lstTickettHuu = db.GetTicketFormDetail("ID90", "SGN", (int)EmployeeModel.EmployeeType.Huu, null, null);
                lstTickettHuu.AddRange(db.GetTicketFormDetail("ID75", "SGN", (int)EmployeeModel.EmployeeType.Huu, null, null));
                lstReport.AddRange(FormReportModel.GetListReport(lstTickettHuu, ReportModel.ReportType.HUU));
                //ReportModel reportModelHuu = SaveAndPrintReport(lstTickettHuu, ReportModel.ReportType.HUU);

                foreach (ReportModel report in lstReport)
                {
                    report.Save();
                }
                for (int i = 0; i < lstReport.Count; i++)
                {
                    ReportModel report = lstReport[i];
                    switch (report.LoaiReport)
                    {
                        case ReportModel.ReportType.TCTV:
                            InReport(report, i + "ReportTCTV");
                            break;
                        case ReportModel.ReportType.KTCTV:
                            InReport(report, i + "ReportNgoaiTCTV");
                            break;
                        case ReportModel.ReportType.TCMD:
                            InReport(report, i + "ReportTCMD");
                            break;
                        case ReportModel.ReportType.KTCMD:
                            InReport(report, i + "ReportNgoaiTCMD");
                            break;
                        case ReportModel.ReportType.HUU:
                            InReport(report, i + "ReportHuu");
                            break;

                    }
                }

                lstReport = new List<ReportModel>();
                lstTicketTVTrongCheDo = db.GetTicketFormDetail("ID90", "HAN", (int)EmployeeModel.EmployeeType.TiepVien, null, null);
                lstTicketTVTrongCheDo.AddRange(db.GetTicketFormDetail("ID75", "HAN", (int)EmployeeModel.EmployeeType.TiepVien, null, 10));
                lstReport.AddRange(FormReportModel.GetListReport(lstTicketTVTrongCheDo, ReportModel.ReportType.TCTV));
                //ReportModel reportModelTVTrongCheDo = SaveAndPrintReport(lstTicketTVTrongCheDo, ReportModel.ReportType.TCTV);

                lstTicketTVNgoaiCheDo = db.GetTicketFormDetail("ID75", "HAN", (int)EmployeeModel.EmployeeType.TiepVien, 10, null);
                lstTicketTVNgoaiCheDo.AddRange(db.GetTicketFormDetail("ID50", "HAN", (int)EmployeeModel.EmployeeType.TiepVien, null, null));
                lstReport.AddRange(FormReportModel.GetListReport(lstTicketTVNgoaiCheDo, ReportModel.ReportType.KTCTV));
                //ReportModel reportModelTVNgoaiCheDo = SaveAndPrintReport(lstTicketTVNgoaiCheDo, ReportModel.ReportType.KTCTV);

                lstTicketMDTrongCheDo = db.GetTicketFormDetail("ID90", "HAN", (int)EmployeeModel.EmployeeType.MatDat, null, null);
                lstTicketMDTrongCheDo.AddRange(db.GetTicketFormDetail("ID75", "HAN", (int)EmployeeModel.EmployeeType.MatDat, null, 10));
                lstReport.AddRange(FormReportModel.GetListReport(lstTicketMDTrongCheDo, ReportModel.ReportType.TCMD));
                //ReportModel reportModelMDTrongCheDo = SaveAndPrintReport(lstTicketMDTrongCheDo, ReportModel.ReportType.TCMD);

                lstTickettMDNgoaiCheDo = db.GetTicketFormDetail("ID75", "HAN", (int)EmployeeModel.EmployeeType.MatDat, 10, null);
                lstTickettMDNgoaiCheDo.AddRange(db.GetTicketFormDetail("ID50", "HAN", (int)EmployeeModel.EmployeeType.MatDat, null, null));
                lstReport.AddRange(FormReportModel.GetListReport(lstTickettMDNgoaiCheDo, ReportModel.ReportType.KTCMD));
                //ReportModel reportModelMDNgoaiCheDo = SaveAndPrintReport(lstTickettMDNgoaiCheDo, ReportModel.ReportType.KTCMD);

                lstTickettHuu = db.GetTicketFormDetail("ID90", "HAN", (int)EmployeeModel.EmployeeType.Huu, null, null);
                lstTickettHuu.AddRange(db.GetTicketFormDetail("ID75", "HAN", (int)EmployeeModel.EmployeeType.Huu, null, null));
                lstReport.AddRange(FormReportModel.GetListReport(lstTickettHuu, ReportModel.ReportType.HUU));

                foreach (ReportModel report in lstReport)
                {
                    report.Save();
                }
                for (int i = 0; i < lstReport.Count; i++)
                {
                    ReportModel report = lstReport[i];
                    switch (report.LoaiReport)
                    {
                        case ReportModel.ReportType.TCTV:
                            InReport(report, i + "ReportTCTVHAN");
                            break;
                        case ReportModel.ReportType.KTCTV:
                            InReport(report, i + "ReportNgoaiTCTVHAN");
                            break;
                        case ReportModel.ReportType.TCMD:
                            InReport(report, i + "ReportTCMDHAN");
                            break;
                        case ReportModel.ReportType.KTCMD:
                            InReport(report, i + "ReportNgoaiTCMDHAN");
                            break;
                        case ReportModel.ReportType.HUU:
                            InReport(report, i + "ReportHuuHAN");
                            break;

                    }
                }

                SplashScreenManager.CloseForm(false);
                System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "ReportVe" + "\\" + DateTime.Now.ToString("ddMMyy"));

                //List<USP_GetFromDetail_Result> lstTickettMDNgoaiCheDo = db.GetTicketFormDetail("ID75", "SGN", (int)EmployeeModel.EmployeeType.MatDat, 10, null);
                //lstTickettMDNgoaiCheDo.AddRange(db.GetTicketFormDetail("ID50", "SGN", (int)EmployeeModel.EmployeeType.MatDat, null, null));
                //ReportModel reportModelMDNgoaiCheDo = SaveAndPrintReport(lstTickettMDNgoaiCheDo, ReportModel.ReportType.KTCMD);

                //List<USP_GetFromDetail_Result> lstTickettHuu = db.GetTicketFormDetail("ID90", "SGN", (int)EmployeeModel.EmployeeType.Huu, null, null);
                //lstTickettHuu.AddRange(db.GetTicketFormDetail("ID75", "SGN", (int)EmployeeModel.EmployeeType.Huu, null, null));
                //ReportModel reportModelHuu = SaveAndPrintReport(lstTickettHuu, ReportModel.ReportType.HUU);

                //InReport(reportModelTVTrongCheDo, "ReportTCTV");
                //InReport(reportModelTVNgoaiCheDo, "ReportNgoaiTCTV");
                //InReport(reportModelMDTrongCheDo, "ReportTCMD");
                //InReport(reportModelMDNgoaiCheDo, "ReportNgoaiTCMD");
                //InReport(reportModelHuu, "ReportHuu");
                //SplashScreenManager.CloseForm(false);
                //System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "ReportVe" + "\\" + DateTime.Now.ToString("ddMMyy")); 



                //UpdateGrid();

                //List<USP_GetFromDetail_Result> lstTicketTVNgoaiCheDo = db.GetTicketFormDetail("ID75", "SGN", (int)EmployeeModel.EmployeeType.TiepVien, 10, null);
                //lstTicketTVNgoaiCheDo.AddRange(db.GetTicketFormDetail("ID50", "SGN", (int)EmployeeModel.EmployeeType.TiepVien, null, null));

                //List<USP_GetFromDetail_Result> lstTicketMDTrongCheDo = db.GetTicketFormDetail("ID90", "SGN", (int)EmployeeModel.EmployeeType.MatDat, null, null);
                //lstTicketMDTrongCheDo.AddRange(db.GetTicketFormDetail("ID75", "SGN", (int)EmployeeModel.EmployeeType.MatDat, null, 10));

                //List<USP_GetFromDetail_Result> lstTickettMDNgoaiCheDo = db.GetTicketFormDetail("ID75", "SGN", (int)EmployeeModel.EmployeeType.MatDat, 10, null);
                //lstTickettMDNgoaiCheDo.AddRange(db.GetTicketFormDetail("ID50", "SGN", (int)EmployeeModel.EmployeeType.MatDat, null, null));

                //List<USP_GetFromDetail_Result> lstTickettHuu = db.GetTicketFormDetail("ID90", "SGN", (int)EmployeeModel.EmployeeType.Huu, null, null);
                //lstTickettHuu.AddRange(db.GetTicketFormDetail("ID75", "SGN", (int)EmployeeModel.EmployeeType.MatDat, null, null));




                //Nhap thong tin loai report
                //ReportModel reportModel = new ReportModel();            
                //reportModel.Type = lookUpEditTicketType.EditValue.ToString();
                //reportModel.EmployeeType = EmployeeModel.DicEmployeeType[cbxEmployeeType.SelectedItem.ToString()];
                //reportModel.TicketType = TicketModel.DicTicketType[lookUpEditTicketType.EditValue.ToString()];                     
                //try
                //{
                //    reportModel.ThamNienFrom = int.Parse(yearFrom.Text);
                //}
                //catch { }            

                ////Nhap detail report
                //foreach (int rowIndex in gridView1.GetSelectedRows())
                //{                                
                //    reportModel.lstFormDetail.Add((USP_GetFromDetail_Result)gridView1.GetRow(rowIndex));
                //}
                ////Lay dong dau tien lam thong tin report
                //if (reportModel.lstFormDetail.Count > 0)
                //{
                //    USP_GetFromDetail_Result temp = reportModel.lstFormDetail[0];
                //    reportModel.FormCode = string.Format("{0}: {1} {2}", temp.Type, temp.FullNameOffer, temp.Route);
                //    if (reportModel.FormCode.Length > 50)
                //    {
                //        reportModel.FormCode = reportModel.FormCode.Substring(0, 49);
                //    }
                //}

                ////reportModel.SaveAndPrint();

                //ReportModel reportModel = new ReportModel();
                //reportModel.LoaiReport = ReportModel.ReportType.TCTV;
                //reportModel.ID = 1;

                //DataSet ds = new DataSet();
                //DataTable dtFlightFinalReport = new DataTable("fr");
                //ListUtils.LoadRows(dtFlightFinalReport, new List<ReportModel>() { reportModel });
                //ds.Tables.Add(dtFlightFinalReport);

                //FormReportModel frm = new FormReportModel();
                //frm.FormID = 1;
                //frm.FullNameOffer = "Tran Hoai Phong";
                //frm.YearOffer = "2011";
                //frm.Number = 1;
                //frm.ID = 1;

                //FormReportModel frm2 = new FormReportModel();
                //frm2.FormID = 2;
                //frm2.FullNameOffer = "Vo Hoai Phong";
                //frm2.YearOffer = "2011";
                //frm2.Number = 2;
                //frm2.ID = 1;
                //List<FormReportModel> lstFrm = new List<FormReportModel>() { frm, frm2 };

                //DataTable dtFlightCrew = new DataTable("df");
                ////ListUtils.LoadRows(dtFlightCrew, reportModel.lstFormReportModel);
                //ListUtils.LoadRows(dtFlightCrew, lstFrm);
                //ds.Tables.Add(dtFlightCrew);

                //FormDetailModel frmDetail = new FormDetailModel();
                //frmDetail.FormID = 1;
                //frmDetail.FullName = "Tran Hoai Phong";
                ////frm.YearOffer = "2011";
                ////frm.ID = 1;

                //FormDetailModel frmDetail2 = new FormDetailModel();
                //frmDetail2.FormID = 1;
                //frmDetail2.FullName = "Thanh";

                //FormDetailModel frmDetail3 = new FormDetailModel();
                //frmDetail3.FormID = 2;
                //frmDetail3.FullName = "Vo Thuan Phong";
                //List<FormDetailModel> lstFrmDetail = new List<FormDetailModel>() { frmDetail, frmDetail2, frmDetail3 };

                //DataTable dtFlightCrew2 = new DataTable("gf");
                ////ListUtils.LoadRows(dtFlightCrew, reportModel.lstFormReportModel);
                //ListUtils.LoadRows(dtFlightCrew2, lstFrmDetail);
                //ds.Tables.Add(dtFlightCrew2);

                //List<DictionaryEntry> list = new List<DictionaryEntry>
                //        {
                //            new DictionaryEntry("fr", String.Empty),
                //            new DictionaryEntry("df", "ID = %fr.ID%"),
                //            new DictionaryEntry("gf", "FormID = %df.FormID%"),
                //        };

                //System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "ReportVe");
                //string path = string.Format("{0}\\{1}\\{2}_{3}.doc", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ReportVe", "Report", DateTime.Now.ToString("ddMMyyhhmmss"));
                //DocUtility.MergeFile(ds, list, "ReportTicket.doc", path);
                //System.Diagnostics.Process.Start(path);

                //DocUtility.MergeFile(ds, list, "ReportTicket.doc", "VeGiam.doc");
                //System.Diagnostics.Process.Start("VeGiam.doc");
                //UpdateGrid();
                //FrmSoCongVan frm = new FrmSoCongVan();
                //if (frm.ShowDialog() == DialogResult.OK)
                //{

                //}      
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 

        private void InReport(ReportModel reportModelTVTrongCheDo, string tenReport)
        {
            if (reportModelTVTrongCheDo.lstFormReportModel.Count <= 0)
                return;
            DataSet ds = new DataSet();
            DataTable dtFlightFinalReport = new DataTable("fr");
            ListUtils.LoadRows(dtFlightFinalReport, new List<ReportModel>() { reportModelTVTrongCheDo });
            ds.Tables.Add(dtFlightFinalReport);


            DataTable dtFlightCrew = new DataTable("df");
            ListUtils.LoadRows(dtFlightCrew, reportModelTVTrongCheDo.lstFormReportModel);
            ds.Tables.Add(dtFlightCrew);

            List<DictionaryEntry> list = new List<DictionaryEntry>
                    {
                        new DictionaryEntry("fr", String.Empty),
                        new DictionaryEntry("df", "ID = %fr.ID%")
                    };

            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "ReportVe" + "\\" + DateTime.Now.ToString("ddMMyy"));
            string path = string.Format("{0}\\{1}\\{2}\\{3}_{4}.doc", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ReportVe", DateTime.Now.ToString("ddMMyy"), tenReport, DateTime.Now.ToString("ddMMyyhhmmss"));
            DocUtility.MergeFile(ds, list, System.IO.Directory.GetCurrentDirectory() + "\\ReportTicket.doc", path);            
        }

        private ReportModel SaveAndPrintReport(List<USP_GetFromDetail1_Result> lstTicketTVTrongCheDo, ReportModel.ReportType reportType)
        {
            ReportModel reportModelTVTrongCheDo = new ReportModel();
            reportModelTVTrongCheDo.LoaiReport = reportType;
            reportModelTVTrongCheDo.lstFormDetail = lstTicketTVTrongCheDo;
            //Lay dong dau tien lam thong tin report
            if (reportModelTVTrongCheDo.lstFormDetail.Count > 0)
            {
                USP_GetFromDetail1_Result temp = reportModelTVTrongCheDo.lstFormDetail[0];
                reportModelTVTrongCheDo.FormCode = string.Format("{0}: {1} {2}", temp.Type, temp.FullNameOffer, temp.Route);
                if (reportModelTVTrongCheDo.FormCode.Length > 50)
                {
                    reportModelTVTrongCheDo.FormCode = reportModelTVTrongCheDo.FormCode.Substring(0, 49);
                }
                reportModelTVTrongCheDo.SaveAndPrint();
            }            
            return reportModelTVTrongCheDo;
        }

        private void cbxEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void FrmManageFormDetail_Activated(object sender, EventArgs e)
        {
            UpdateGrid();
        }
    }
}