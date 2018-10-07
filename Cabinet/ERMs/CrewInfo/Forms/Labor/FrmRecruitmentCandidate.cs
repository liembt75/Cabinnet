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
using DevExpress.Export;

namespace CrewInfo.Forms.Labor
{
    public partial class FrmRecruitmentCandidate : ERMs.SharedBase.XtraFormMDIBase
    {
        RecruitmentDal db = new RecruitmentDal();
        public FrmRecruitmentCandidate()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            gc.DataSource = db.GetRecruitmentCandidate();
            gv.BestFitColumns();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Microsoft Excel 2007 or later|*.xlsx";
            file.FileName = "Candidate.xlsx";
            file.Title = "Save an Excel";
            DialogResult result = file.ShowDialog();

            if (result == DialogResult.OK && file.FileName.Trim() != "")
            {
                ExportSettings.DefaultExportType = ExportType.DataAware;
                //gvExam.BestFitColumns();
                gv.ExportToXlsx(file.FileName);
                System.Diagnostics.Process.Start(file.FileName);
            }
        }
    }
}