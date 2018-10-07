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
using CrewInfo.ADONet;
using CrewInfo.Reports;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Columns;

namespace CrewInfo.Forms.Meeting
{
    public partial class FrmMeetingCustomChart : ERMs.SharedBase.XtraFormMDIBase
    {
        public List<Meeting_Section> lstMeetingSection = new List<Meeting_Section>();
        public dsMetting ds = new dsMetting();
        public FrmMeetingCustomChart()
        {
            InitializeComponent();
        }

        private void FrmMeetingCustomChart_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = lstMeetingSection;            
            InitView();
            gridView1.BestFitColumns();
        }

        private void InitView()
        {
            gridView1.Columns.Clear();
            GridColumn col = null;            
            col = new GridColumn() { Caption = "Loại", FieldName = "Title", Visible = true }; col.OptionsColumn.ReadOnly = true; col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count; col.SummaryItem.DisplayFormat = "{0:n0}"; gridView1.Columns.Add(col);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            dsMetting dsCustom = (dsMetting)ds.Copy();
            rpCustomMeeting xrpt = new rpCustomMeeting();
            xrpt.DataSource = dsCustom;
            xrpt.Bands[BandKind.Detail].Controls.Clear();

            if (cbxOnechart.Checked)
            {
                XRChart xrChart1 = new DevExpress.XtraReports.UI.XRChart();

                xrChart1.Location = new System.Drawing.Point(0, 0);
                xrChart1.Name = "xrChart1";

                foreach (var rowIndex in gridView1.GetSelectedRows())
                {
                    Meeting_Section row = (Meeting_Section)gridView1.GetRow(rowIndex);

                    DevExpress.XtraCharts.Series series = new DevExpress.XtraCharts.Series(row.Title, DevExpress.XtraCharts.ViewType.Line);
                    series.ArgumentDataMember = "IMeeting.Date";
                    DevExpress.XtraCharts.DataFilter dataFilter = new DevExpress.XtraCharts.DataFilter();
                    dataFilter.Condition = DevExpress.XtraCharts.DataFilterCondition.Equal;
                    dataFilter.ColumnName = "MeetingSection";
                    dataFilter.DataType = 1.GetType();
                    dataFilter.Value = row.ID;
                    series.DataFilters.Add(dataFilter);
                    series.ValueDataMembers[0] = "IMeeting.Value";
                    xrChart1.Series.Add(series);
                }


                xrChart1.Size = new System.Drawing.Size(650, 360);
                xrChart1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
                xrChart1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside;

                // Place the chart onto a report footer
                xrpt.Bands[BandKind.Detail].Controls.Add(xrChart1);
            }
            else
            {
                int i = 0;
                foreach (var rowIndex in gridView1.GetSelectedRows())
                {
                    XRChart xrChart1 = new DevExpress.XtraReports.UI.XRChart();
                    xrChart1.Location = new System.Drawing.Point(0, i * 360);
                    //xrChart1.Name = "xrChart1";
                    Meeting_Section row = (Meeting_Section)gridView1.GetRow(rowIndex);

                    DevExpress.XtraCharts.Series series = new DevExpress.XtraCharts.Series(row.Title, DevExpress.XtraCharts.ViewType.Line);
                    series.ArgumentDataMember = "IMeeting.Date";
                    DevExpress.XtraCharts.DataFilter dataFilter = new DevExpress.XtraCharts.DataFilter();
                    dataFilter.Condition = DevExpress.XtraCharts.DataFilterCondition.Equal;
                    dataFilter.ColumnName = "MeetingSection";
                    dataFilter.DataType = 1.GetType();
                    dataFilter.Value = row.ID;
                    series.DataFilters.Add(dataFilter);
                    series.ValueDataMembers[0] = "IMeeting.Value";
                    xrChart1.Series.Add(series);



                    xrChart1.Size = new System.Drawing.Size(650, 360);
                    xrChart1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
                    xrChart1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside;

                    // Place the chart onto a report footer
                    xrpt.Bands[BandKind.Detail].Controls.Add(xrChart1);
                    i++;
                }
            }

            xrpt.CreateDocument();
            documentViewer2.DocumentSource = xrpt;
            documentViewer2.Refresh();
        }
    }
}