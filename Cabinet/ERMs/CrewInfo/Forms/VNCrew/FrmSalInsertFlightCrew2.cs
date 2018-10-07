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
using ERMs.Data.Flight;
using ERMs.Data;
using DevExpress.XtraGrid;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmSalInsertFlightCrew2 : ERMs.SharedBase.XtraFormMDIBase
    {
        FlightDal db = new FlightDal();
        CR_FlightInfo mFlightInfo;
        List<ExamineeModel> mLstCrew;
        List<API_CR_USP_GetFlightCrewAdmin_Result> mLstAddedCrew = new List<API_CR_USP_GetFlightCrewAdmin_Result>();
        BindingSource bind = new BindingSource();
        public FrmSalInsertFlightCrew2(CR_FlightInfo flightInfo, List<ExamineeModel> lstCrew)
        {
            InitializeComponent();
            mFlightInfo = flightInfo;
            mLstCrew = lstCrew;
            
        }

        private void FrmSalInsertFlightCrew2_Load(object sender, EventArgs e)
        {
            lbCR_FlightInfo.Text = String.Format("FlightNo: {0}, Date: {1}, Routing: {2}", mFlightInfo.FlightNo, mFlightInfo.Date.ToString("dd/MM/yyyy"), mFlightInfo.Routing);
            mLstAddedCrew = db.GetFlightCrewByFlightIDAdmin(mFlightInfo.FlightID, true);
            
            StyleFormatCondition styleCategory = new StyleFormatCondition();
            //styleCategory.Column = col;
            styleCategory.Condition = FormatConditionEnum.Expression;
            styleCategory.Expression = "Not IsNullOrEmpty([Created])";
            styleCategory.Appearance.BackColor = Color.Gray;
            styleCategory.Appearance.BackColor2 = Color.LightGray;
            styleCategory.Appearance.Options.UseBackColor = true;
            styleCategory.ApplyToRow = true;
            gridView1.FormatConditions.Add(styleCategory);

            bind.DataSource = mLstAddedCrew;
            gridControl1.DataSource = bind;
            UpdateGridView();
        }

        private void UpdateGridView()
        {            
            gridControl2.DataSource = getExamineeFilter();            
        }

        public List<ExamineeModel> getExamineeFilter()
        {
            List<string> lstMSNV = new List<string>();
            lstMSNV = txtMSNV.Text.Split(new string[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> lstTen = new List<string>();
            lstTen = txtTen.Text.Split(new string[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var result = mLstCrew;
            if (lstMSNV.Count > 0)
            {
                result = result.Where(q => lstMSNV.Any(f => q.CrewID.Contains(f))).ToList();
            }
            if (lstTen.Count == 1)
            {
                result = result.Where(q => lstTen.Any(f => q.FirstNameVn.ToUpper().Contains(f.ToUpper()))).ToList();
            }
            if (lstTen.Count > 1)
            {
                result = result.Where(q => lstTen.Any(f => q.FirstNameVn.ToUpper() == f.ToUpper())).ToList();
            }
            return result;
        }

        private void txtMSNV_EditValueChanged(object sender, EventArgs e)
        {
            UpdateGridView();
        }

        private void txtTen_EditValueChanged(object sender, EventArgs e)
        {
            UpdateGridView();
        }

        private void btnFoward_Click(object sender, EventArgs e)
        {
            foreach (int rowHandle in gridView2.GetSelectedRows())
            {
                ExamineeModel examineeModel = (ExamineeModel)gridView2.GetRow(rowHandle);
                if (mLstAddedCrew.Where(i => i.CrewID == examineeModel.CrewID).FirstOrDefault() == null)
                {
                    API_CR_USP_GetFlightCrewAdmin_Result addedCrew = new API_CR_USP_GetFlightCrewAdmin_Result();
                    addedCrew.FlightID = mFlightInfo.FlightID;
                    addedCrew.CrewID = examineeModel.CrewID;
                    addedCrew.FO_FlightNo = mFlightInfo.FlightNo;
                    addedCrew.FirstNameVn = examineeModel.FirstNameVn;
                    addedCrew.LastNameVn = examineeModel.LastNameVn;
                    if (!string.IsNullOrEmpty(mFlightInfo.Routing) && mFlightInfo.Routing.IndexOf("-") > 0)
                    {
                        addedCrew.FO_From_Place = mFlightInfo.Routing.Substring(0, mFlightInfo.Routing.IndexOf("-"));
                        addedCrew.FO_End_Place = mFlightInfo.Routing.Substring(mFlightInfo.Routing.IndexOf("-"));
                    }
                    addedCrew.FO_Date = mFlightInfo.Date;                    
                    mLstAddedCrew.Add(addedCrew);
                }
            }
            gridControl1.RefreshDataSource();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            List<ExamineeModel> lstRemoveAccount = new List<ExamineeModel>();
            foreach (int rowHandle in gridView1.GetSelectedRows())
            {
                API_CR_USP_GetFlightCrewAdmin_Result addedCrew = (API_CR_USP_GetFlightCrewAdmin_Result)gridView1.GetRow(rowHandle);
                gridView1.UnselectRow(rowHandle);
                if (addedCrew != null && addedCrew.Created != null)
                    continue;
                else
                    mLstAddedCrew.Remove(addedCrew);
            }
            gridControl1.RefreshDataSource();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                int addedCount = mLstAddedCrew.Where(i => i.Created == null).Count();
                if (addedCount <= 0)
                {
                    MessageBox.Show("Không có tiếp viên nào được thêm vào chuyến bay!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    addedCount = mLstAddedCrew.Where(i => i.Created == null && string.IsNullOrEmpty(i.FO_Job)).Count();
                    if (addedCount > 0)
                    {
                        MessageBox.Show("Vui lòng nhập cột FOJob!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        List<CR_Flight_Crew> lstCrewAddToDB = new List<CR_Flight_Crew>();
                        CR_Flight_Crew flightCrew = null;
                        foreach (var addedCrew in mLstAddedCrew.Where(i => i.Created == null))
                        {
                            flightCrew = new CR_Flight_Crew();
                            flightCrew.FlightID = addedCrew.FlightID;
                            flightCrew.CrewID = addedCrew.CrewID;
                            flightCrew.FO_FlightNo = addedCrew.FO_FlightNo;
                            flightCrew.FO_From_Place = addedCrew.FO_From_Place;
                            flightCrew.FO_End_Place = addedCrew.FO_End_Place;
                            flightCrew.FO_Date = addedCrew.FO_Date;
                            lstCrewAddToDB.Add(flightCrew);
                        }
                        //db.AddFligthCrew(lstCrewAddToDB);
                        MessageBox.Show("Bạn đã thêm tiếp viên thành công!");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}