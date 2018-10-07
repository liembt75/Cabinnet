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
using DevExpress.XtraGrid.Views.Grid;

namespace CrewInfo.Forms.Ticket
{
    public partial class FrmTicketAirport : ERMs.SharedBase.XtraFormMDIBase
    {
        TicketDal db = new TicketDal();
        BindingSource bind = new BindingSource();
        public FrmTicketAirport()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            bind.DataSource = db.GetTicketAirport();
            gcAirport.DataSource = bind;
            gvAirport.BestFitColumns();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            gvAirport.OptionsBehavior.Editable = !gvAirport.OptionsBehavior.Editable;
        }

        private void gvAirport_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {            
        }

        private void gvAirport_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvAirport_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            Ticket_Airport item = (Ticket_Airport)e.Row;

            if (string.IsNullOrWhiteSpace(item.Code))
            {
                e.Valid = false;
                view.SetColumnError(clCode, "Code không được để trống.");
            }            
            else
            {
                List<Ticket_Airport> lstEx = bind.DataSource as List<Ticket_Airport>;
                if (lstEx.Where(x => x.Code == item.Code).Count() > 1)
                {
                    e.Valid = false;
                    view.SetColumnError(clCode, "Code không được giống nhau.");
                }
            }
            if (string.IsNullOrWhiteSpace(item.Name))
            {
                e.Valid = false;
                view.SetColumnError(clName, "Name không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(item.Country))
            {
                e.Valid = false;
                view.SetColumnError(clCountry, "Country không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(item.Route))
            {
                e.Valid = false;
                view.SetColumnError(clRoute, "Route không được để trống.");
            }
        }

        private void gvAirport_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DevExpress.XtraBars.Alerter.AlertControl alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl();
            Ticket_Airport item = (Ticket_Airport)e.Row;
            try
            {
                Ticket_Airport returnItem = db.UpdateAirport(item);
                item.ID = returnItem.ID;
                alertControl1.Show(this.FindForm(), "Successful", "Thành công");
            }
            catch (Exception ex)
            {
                alertControl1.Show(this.FindForm(), "Error", ex.Message);
            }
        }
    }
}