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
using ERMs.Data.Ticket;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

namespace eTicket
{
    public partial class FrmRoute : ERMs.SharedBase.XtraDialogBase
    {
        public TicketFormModel _ticketForm = null;
        public Ticket_FormDetail _ticket_FormDetail = null;
        //List<Ticket_Airport> _lstTicketAirport = null;
        //List<TicketAirportModel> lstTicketAirportModel = new List<TicketAirportModel>();        
        BindingSource bind = new BindingSource();
        public RouteModel _routeModel = null;
        public FrmRoute(TicketFormModel iTicketForm, Ticket_FormDetail iTicket_FormDetail)
        {
            _ticketForm = iTicketForm;
            _ticket_FormDetail = iTicket_FormDetail;
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            _routeModel = new RouteModel();

            comboBoxBase.SelectedIndex = 0;
            List<ERMs.Data.TicketModel.TicketType> lstTicketType = new List<ERMs.Data.TicketModel.TicketType>();
            foreach (var ticket in ERMs.Data.TicketModel.DicTicketType)
            {
                lstTicketType.Add(ticket.Value);
            }
            lookUpEditTicketType.Properties.DataSource = lstTicketType;
            if (!string.IsNullOrEmpty(_ticket_FormDetail.Base))
                comboBoxBase.EditValue = _ticket_FormDetail.Base;
            if (string.IsNullOrEmpty(_ticket_FormDetail.Type))
                lookUpEditTicketType.EditValue = TicketModel.TicketType.ID90;
            else
                lookUpEditTicketType.EditValue = new TicketModel().GetTicketType(_ticket_FormDetail.Type);

            if (_ticketForm != null)
            {
                if (_ticketForm.ticketQuota.ID90 != null && _ticketForm.ticketQuota.ID90 > 0)                
                    lookUpEditTicketType.EditValue = TicketModel.TicketType.ID90;
                else if (_ticketForm.ticketQuota.ID75 != null && _ticketForm.ticketQuota.ID75 > 0)
                    lookUpEditTicketType.EditValue = TicketModel.TicketType.ID75;
                else if (_ticketForm.ticketQuota.ID50 != null && _ticketForm.ticketQuota.ID50 > 0)
                    lookUpEditTicketType.EditValue = TicketModel.TicketType.ID50;
            }

            if (!string.IsNullOrEmpty(_ticket_FormDetail.Route))
                _routeModel.GetListRouteDetail(_ticket_FormDetail.Route);

            repositoryItemLookUpEdit1.DataSource = _routeModel.LstTicketAirport.ToList();
            repositoryItemLookUpEdit1.DisplayMember = "Code";
            repositoryItemLookUpEdit1.ValueMember = "Code";

            repositoryItemLookUpEdit2.DataSource = _routeModel.LstTicketAirport.ToList();
            repositoryItemLookUpEdit2.DisplayMember = "Code";
            repositoryItemLookUpEdit2.ValueMember = "Code";
                        
            lbInformation.Text = String.Format("Tên tôi là: {0}\r\nNgày tháng năm sinh:{1}",
                                                _ticket_FormDetail.Fullname,
                                                _ticket_FormDetail.Birthday == null ? "" : _ticket_FormDetail.Birthday.Value.ToString("dd/MM/yyyy"));

            bind.DataSource = _routeModel.lstRouteDetail;
            gridControl1.DataSource = bind;
        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName != "To") return;
            RouteDetail routeDetail = gridView1.GetRow(e.RowHandle) as RouteDetail;            
            if (routeDetail != null)
            {
                RepositoryItemLookUpEdit repositoryItemLookUpEditTemp = new RepositoryItemLookUpEdit();
                repositoryItemLookUpEditTemp.DisplayMember = "Code";
                repositoryItemLookUpEditTemp.ValueMember = "Code";
                repositoryItemLookUpEditTemp.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                    new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code"),
                    new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"),
                    new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Country", "Country")});
                repositoryItemLookUpEditTemp.NullText = "";
                repositoryItemLookUpEditTemp.DataSource = _routeModel.LstTicketAirportTo(routeDetail.From);
                e.RepositoryItem = repositoryItemLookUpEditTemp;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            bind.Clear();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (_routeModel.lstRouteDetail.Count > 0)
            {
                _routeModel.lstRouteDetail = (List<RouteDetail>)bind.DataSource;
                _routeModel.ticketType = (TicketModel.TicketType)lookUpEditTicketType.EditValue;
                _routeModel.Base = comboBoxBase.EditValue.ToString();                
            }
            this.DialogResult = DialogResult.OK;
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Name == "clDel")
            {
                var routeDetail = gridView1.GetRow(e.RowHandle) as RouteDetail;
                _routeModel.lstRouteDetail.Remove(routeDetail);
                gridControl1.RefreshDataSource();
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            RouteDetail routeDetail = e.Row as RouteDetail;
            if (string.IsNullOrWhiteSpace(routeDetail.From))
            {
                e.Valid = false;
                view.SetColumnError(gridColumn1, "This is not empty.");
            }
            if (string.IsNullOrWhiteSpace(routeDetail.To))
            {
                e.Valid = false;
                view.SetColumnError(gridColumn2, "This is not empty.");
            }
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        //
        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

        }

    }
}