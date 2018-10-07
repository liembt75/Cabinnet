namespace CrewInfo.Forms.VNCrew
{
    partial class FrmFlightFinalReportDepartmentRely
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
            this.lookUpEditDepartment = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditCategory = new DevExpress.XtraEditors.LookUpEdit();
            this.btnRely = new DevExpress.XtraEditors.SimpleButton();
            this.memoEditNote = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.memoRelyEdit = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoRelyEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lookUpEditDepartment
            // 
            this.lookUpEditDepartment.Location = new System.Drawing.Point(106, 22);
            this.lookUpEditDepartment.Name = "lookUpEditDepartment";
            this.lookUpEditDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditDepartment.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", "Bộ phận")});
            this.lookUpEditDepartment.Properties.NullText = "";
            this.lookUpEditDepartment.Properties.ReadOnly = true;
            this.lookUpEditDepartment.Size = new System.Drawing.Size(468, 20);
            this.lookUpEditDepartment.TabIndex = 25;
            // 
            // lookUpEditCategory
            // 
            this.lookUpEditCategory.Location = new System.Drawing.Point(106, 51);
            this.lookUpEditCategory.Name = "lookUpEditCategory";
            this.lookUpEditCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCategory.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Category", "Mục cha"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SubCategory", "Mục con")});
            this.lookUpEditCategory.Properties.NullText = "";
            this.lookUpEditCategory.Properties.ReadOnly = true;
            this.lookUpEditCategory.Size = new System.Drawing.Size(468, 20);
            this.lookUpEditCategory.TabIndex = 24;
            // 
            // btnRely
            // 
            this.btnRely.Location = new System.Drawing.Point(106, 544);
            this.btnRely.Name = "btnRely";
            this.btnRely.Size = new System.Drawing.Size(75, 23);
            this.btnRely.TabIndex = 23;
            this.btnRely.Text = "Trả lời";
            this.btnRely.Click += new System.EventHandler(this.btnRely_Click);
            // 
            // memoEditNote
            // 
            this.memoEditNote.Location = new System.Drawing.Point(106, 81);
            this.memoEditNote.Name = "memoEditNote";
            this.memoEditNote.Properties.ReadOnly = true;
            this.memoEditNote.Size = new System.Drawing.Size(468, 223);
            this.memoEditNote.TabIndex = 22;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(33, 82);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(37, 13);
            this.labelControl3.TabIndex = 21;
            this.labelControl3.Text = "Đề nghị";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(33, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 20;
            this.labelControl2.Text = "Danh mục";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(33, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(39, 13);
            this.labelControl1.TabIndex = 19;
            this.labelControl1.Text = "Bộ phận";
            // 
            // memoRelyEdit
            // 
            this.memoRelyEdit.Location = new System.Drawing.Point(106, 315);
            this.memoRelyEdit.Name = "memoRelyEdit";
            this.memoRelyEdit.Size = new System.Drawing.Size(468, 223);
            this.memoRelyEdit.TabIndex = 27;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(33, 316);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(29, 13);
            this.labelControl4.TabIndex = 26;
            this.labelControl4.Text = "Trả lời";
            // 
            // FrmFlightFinalReportDepartmentRely
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 577);
            this.Controls.Add(this.memoRelyEdit);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.lookUpEditDepartment);
            this.Controls.Add(this.lookUpEditCategory);
            this.Controls.Add(this.btnRely);
            this.Controls.Add(this.memoEditNote);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "FrmFlightFinalReportDepartmentRely";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmFlightFinalReportDepartmentRely";
            this.Load += new System.EventHandler(this.FrmFlightFinalReportDepartmentRely_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoRelyEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpEditDepartment;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCategory;
        private DevExpress.XtraEditors.SimpleButton btnRely;
        private DevExpress.XtraEditors.MemoEdit memoEditNote;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit memoRelyEdit;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}