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
using DevExpress.XtraGrid.Columns;
using ERMs.Data;
using DevExpress.XtraSplashScreen;
using ERMs.SharedBase;
using DevExpress.XtraGrid.Views.Grid;

namespace CrewInfo.Forms.VNCrew
{
    public partial class FrmNews : ERMs.SharedBase.XtraFormMDIBase
    {
        BindingSource bind = new BindingSource();
        List<CR_GetNews_Result> lstNew = new List<CR_GetNews_Result>();
        EMMessageDal db = new EMMessageDal();
        public FrmNews()
        {
            InitializeComponent();
        }

        private void FrmNews_Load(object sender, EventArgs e)
        {
            splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            splitContainerControl1.SplitterPosition = splitContainerControl1.Width * 1 / 3;
            bind.DataSource = lstNew;
            gc.DataSource = bind;
            InitView();
            RefreshData();
        }

        private void InitView()
        {
            gv.Columns.Clear();
            GridColumn col = null;

            col = new GridColumn() { Caption = "MSNV", FieldName = "CrewID", Visible = true }; col.Visible = true; col.OptionsColumn.ReadOnly = true; col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count; col.SummaryItem.DisplayFormat = "{0:n0}"; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Account", FieldName = "Account", Visible = true }; col.Visible = true; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Title", FieldName = "Title", Visible = true }; col.Visible = true; col.Width = 120; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col); 
            //col = new GridColumn() { Caption = "HoTen", FieldName = "HoTen", Visible = true }; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);
            col = new GridColumn() { Caption = "Created", FieldName = "Created", Visible = true }; col.Visible = true; col.DisplayFormat.FormatString = "dd/MM/yy"; col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; col.OptionsColumn.ReadOnly = true; gv.Columns.Add(col);                     
        }

        private void RefreshData()
        {
            DateTime fromdate, todate;
            fromdate = txtFromdate.DateTime = txtFromdate.EditValue == null ? new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1) : txtFromdate.DateTime;
            todate = txtTodate.DateTime = txtTodate.EditValue == null ? DateTime.Today : txtTodate.DateTime;
            fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0, 0);
            todate = new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59, 59);

            lstNew.Clear();
            lstNew.AddRange(db.GetNews(fromdate, todate, txtKeyword.Text));
            gc.RefreshDataSource();
            foreach (GridColumn column in gv.Columns)
            {
                if (column.FieldName != "Title")
                    column.BestFit();
            }           
            
        }

        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {            
            GridView view = sender as GridView;
            CR_GetNews_Result item = (CR_GetNews_Result)view.GetRow(e.FocusedRowHandle);            
            try
            {
                string htmlNew = db.GetHtmlNewByID(item.ID);
                recContent.HtmlText = htmlNew;
            }
            catch { }            
        }

        private void gv_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            GridView view = sender as GridView;
            CR_GetNews_Result item = (CR_GetNews_Result)view.GetRow(e.RowHandle);
            try
            {
                string htmlNew = db.GetHtmlNewByID(item.ID);
                recContent.HtmlText = htmlNew;
            }
            catch { }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshData();
            if (gv.FocusedRowHandle >= 0)
            {
                CR_GetNews_Result item = (CR_GetNews_Result)gv.GetRow(gv.FocusedRowHandle);
                try
                {
                    string htmlNew = db.GetHtmlNewByID(item.ID);
                    recContent.HtmlText = htmlNew;
                }
                catch { }
            }
        }

        private void txtKeyword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RefreshData();
                if (gv.FocusedRowHandle >= 0)
                {
                    CR_GetNews_Result item = (CR_GetNews_Result)gv.GetRow(gv.FocusedRowHandle);
                    try
                    {
                        string htmlNew = db.GetHtmlNewByID(item.ID);
                        recContent.HtmlText = htmlNew;
                    }
                    catch { }
                }
            }
        }
    }
}