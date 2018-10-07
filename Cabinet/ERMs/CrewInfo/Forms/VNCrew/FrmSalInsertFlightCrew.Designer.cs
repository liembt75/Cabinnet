namespace CrewInfo.Forms.VNCrew
{
    partial class FrmSalInsertFlightCrew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSalInsertFlightCrew));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbCR_FlightInfo = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gcFlightCrew = new DevExpress.XtraGrid.GridControl();
            this.gvFlightCrew = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clFO_FlightNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clFO_Date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clFO_Job = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clFO_From_Place = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clFO_End_Place = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddFligthCrew = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFlightCrew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFlightCrew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddFligthCrew)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lbCR_FlightInfo);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(716, 141);
            this.panelControl1.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(184, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(195, 22);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Thông tin chuyến bay";
            // 
            // lbCR_FlightInfo
            // 
            this.lbCR_FlightInfo.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.lbCR_FlightInfo.Location = new System.Drawing.Point(12, 72);
            this.lbCR_FlightInfo.Name = "lbCR_FlightInfo";
            this.lbCR_FlightInfo.Size = new System.Drawing.Size(173, 22);
            this.lbCR_FlightInfo.TabIndex = 1;
            this.lbCR_FlightInfo.Text = "Thông tin chuyến bay";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gcFlightCrew);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 141);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(716, 469);
            this.panelControl2.TabIndex = 4;
            // 
            // gcFlightCrew
            // 
            this.gcFlightCrew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcFlightCrew.Location = new System.Drawing.Point(2, 2);
            this.gcFlightCrew.MainView = this.gvFlightCrew;
            this.gcFlightCrew.Name = "gcFlightCrew";
            this.gcFlightCrew.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnAddFligthCrew});
            this.gcFlightCrew.Size = new System.Drawing.Size(712, 465);
            this.gcFlightCrew.TabIndex = 0;
            this.gcFlightCrew.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFlightCrew});
            // 
            // gvFlightCrew
            // 
            this.gvFlightCrew.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clname,
            this.clFO_FlightNo,
            this.clFO_Date,
            this.clFO_Job,
            this.clFO_From_Place,
            this.clFO_End_Place,
            this.clAdd});
            this.gvFlightCrew.GridControl = this.gcFlightCrew;
            this.gvFlightCrew.Name = "gvFlightCrew";
            // 
            // clname
            // 
            this.clname.Caption = "name";
            this.clname.FieldName = "name";
            this.clname.Name = "clname";
            this.clname.Visible = true;
            this.clname.VisibleIndex = 0;
            // 
            // clFO_FlightNo
            // 
            this.clFO_FlightNo.Caption = "FO_FlightNo";
            this.clFO_FlightNo.FieldName = "FO_FlightNo";
            this.clFO_FlightNo.Name = "clFO_FlightNo";
            this.clFO_FlightNo.Visible = true;
            this.clFO_FlightNo.VisibleIndex = 1;
            // 
            // clFO_Date
            // 
            this.clFO_Date.Caption = "FO_Date";
            this.clFO_Date.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.clFO_Date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.clFO_Date.FieldName = "FO_Date";
            this.clFO_Date.Name = "clFO_Date";
            this.clFO_Date.Visible = true;
            this.clFO_Date.VisibleIndex = 2;
            // 
            // clFO_Job
            // 
            this.clFO_Job.Caption = "FO_Job";
            this.clFO_Job.FieldName = "FO_Job";
            this.clFO_Job.Name = "clFO_Job";
            this.clFO_Job.Visible = true;
            this.clFO_Job.VisibleIndex = 3;
            // 
            // clFO_From_Place
            // 
            this.clFO_From_Place.Caption = "FO_From_Place";
            this.clFO_From_Place.FieldName = "FO_From_Place";
            this.clFO_From_Place.Name = "clFO_From_Place";
            this.clFO_From_Place.Visible = true;
            this.clFO_From_Place.VisibleIndex = 4;
            // 
            // clFO_End_Place
            // 
            this.clFO_End_Place.Caption = "FO_End_Place";
            this.clFO_End_Place.FieldName = "FO_End_Place";
            this.clFO_End_Place.Name = "clFO_End_Place";
            this.clFO_End_Place.Visible = true;
            this.clFO_End_Place.VisibleIndex = 5;
            // 
            // clAdd
            // 
            this.clAdd.ColumnEdit = this.btnAddFligthCrew;
            this.clAdd.Name = "clAdd";
            this.clAdd.Visible = true;
            this.clAdd.VisibleIndex = 6;
            // 
            // btnAddFligthCrew
            // 
            this.btnAddFligthCrew.AutoHeight = false;
            this.btnAddFligthCrew.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("btnAddFligthCrew.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.btnAddFligthCrew.Name = "btnAddFligthCrew";
            this.btnAddFligthCrew.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnAddFligthCrew.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnAddFligthCrew_ButtonClick);
            // 
            // FrmSalInsertFlightCrew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 610);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmSalInsertFlightCrew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSalInsertFlightCrew";
            this.Load += new System.EventHandler(this.FrmSalInsertFlightCrew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcFlightCrew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFlightCrew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddFligthCrew)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lbCR_FlightInfo;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gcFlightCrew;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFlightCrew;
        private DevExpress.XtraGrid.Columns.GridColumn clname;
        private DevExpress.XtraGrid.Columns.GridColumn clFO_FlightNo;
        private DevExpress.XtraGrid.Columns.GridColumn clFO_Date;
        private DevExpress.XtraGrid.Columns.GridColumn clFO_Job;
        private DevExpress.XtraGrid.Columns.GridColumn clFO_From_Place;
        private DevExpress.XtraGrid.Columns.GridColumn clFO_End_Place;
        private DevExpress.XtraGrid.Columns.GridColumn clAdd;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnAddFligthCrew;
    }
}