namespace CrewInfo.Forms.Briefing
{
    partial class FrmAddBrfDiary
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lookUpEditEmployee = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxHoTen = new System.Windows.Forms.TextBox();
            this.tbxMaNV = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxLienDoi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxChuyenBay = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxNoiDung = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxHinhThuc = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.cbxBase = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditEmployee.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày: ";
            // 
            // dtpNgay
            // 
            this.dtpNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgay.Location = new System.Drawing.Point(117, 20);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(185, 21);
            this.dtpNgay.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên: ";
            // 
            // lookUpEditEmployee
            // 
            this.lookUpEditEmployee.Location = new System.Drawing.Point(117, 46);
            this.lookUpEditEmployee.Name = "lookUpEditEmployee";
            this.lookUpEditEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditEmployee.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FirstNameVn", "FirstName")});
            this.lookUpEditEmployee.Properties.NullText = "";
            this.lookUpEditEmployee.Size = new System.Drawing.Size(185, 20);
            this.lookUpEditEmployee.TabIndex = 8;
            this.lookUpEditEmployee.EditValueChanged += new System.EventHandler(this.lookUpEditEmployee_EditValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Họ tên: ";
            // 
            // tbxHoTen
            // 
            this.tbxHoTen.Location = new System.Drawing.Point(117, 73);
            this.tbxHoTen.Name = "tbxHoTen";
            this.tbxHoTen.ReadOnly = true;
            this.tbxHoTen.Size = new System.Drawing.Size(185, 21);
            this.tbxHoTen.TabIndex = 10;
            // 
            // tbxMaNV
            // 
            this.tbxMaNV.Location = new System.Drawing.Point(117, 99);
            this.tbxMaNV.Name = "tbxMaNV";
            this.tbxMaNV.ReadOnly = true;
            this.tbxMaNV.Size = new System.Drawing.Size(185, 21);
            this.tbxMaNV.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "MSNV: ";
            // 
            // tbxLienDoi
            // 
            this.tbxLienDoi.Location = new System.Drawing.Point(117, 126);
            this.tbxLienDoi.Name = "tbxLienDoi";
            this.tbxLienDoi.Size = new System.Drawing.Size(185, 21);
            this.tbxLienDoi.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Liên đội: ";
            // 
            // tbxChuyenBay
            // 
            this.tbxChuyenBay.Location = new System.Drawing.Point(117, 153);
            this.tbxChuyenBay.Name = "tbxChuyenBay";
            this.tbxChuyenBay.Size = new System.Drawing.Size(185, 21);
            this.tbxChuyenBay.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Chuyến bay: ";
            // 
            // tbxNoiDung
            // 
            this.tbxNoiDung.Location = new System.Drawing.Point(117, 180);
            this.tbxNoiDung.Multiline = true;
            this.tbxNoiDung.Name = "tbxNoiDung";
            this.tbxNoiDung.Size = new System.Drawing.Size(294, 107);
            this.tbxNoiDung.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Nội dung xử lý: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 294);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Hình thức xử lý: ";
            // 
            // cbxHinhThuc
            // 
            this.cbxHinhThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHinhThuc.FormattingEnabled = true;
            this.cbxHinhThuc.Location = new System.Drawing.Point(117, 291);
            this.cbxHinhThuc.Name = "cbxHinhThuc";
            this.cbxHinhThuc.Size = new System.Drawing.Size(185, 21);
            this.cbxHinhThuc.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(117, 357);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(198, 357);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 22;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // cbxBase
            // 
            this.cbxBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBase.FormattingEnabled = true;
            this.cbxBase.Location = new System.Drawing.Point(117, 318);
            this.cbxBase.Name = "cbxBase";
            this.cbxBase.Size = new System.Drawing.Size(185, 21);
            this.cbxBase.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 321);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Base: ";
            // 
            // FrmAddBrfDiary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 414);
            this.Controls.Add(this.cbxBase);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbxHinhThuc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbxNoiDung);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbxChuyenBay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbxLienDoi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxMaNV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxHoTen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lookUpEditEmployee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpNgay);
            this.Controls.Add(this.label1);
            this.Name = "FrmAddBrfDiary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm nhật ký";
            this.Load += new System.EventHandler(this.FrmAddBrfDiary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditEmployee.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditEmployee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxHoTen;
        private System.Windows.Forms.TextBox tbxMaNV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxLienDoi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxChuyenBay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxNoiDung;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxHinhThuc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ComboBox cbxBase;
        private System.Windows.Forms.Label label9;
    }
}