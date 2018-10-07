namespace CrewInfo.Forms.VNCrew
{
    partial class FrmFlightFinalReportAddDepartment
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.memoEditNote = new DevExpress.XtraEditors.MemoEdit();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.treeListBand1 = new DevExpress.XtraTreeList.Columns.TreeListBand();
            this.lookUpEditCategory = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditDepartment = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDepartment.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(39, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Bộ phận";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(25, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Danh mục";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(25, 69);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(37, 13);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "Đề nghị";
            // 
            // memoEditNote
            // 
            this.memoEditNote.Location = new System.Drawing.Point(98, 68);
            this.memoEditNote.Name = "memoEditNote";
            this.memoEditNote.Size = new System.Drawing.Size(468, 223);
            this.memoEditNote.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(98, 297);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // treeListBand1
            // 
            this.treeListBand1.Caption = "treeListBand1";
            this.treeListBand1.Name = "treeListBand1";
            // 
            // lookUpEditCategory
            // 
            this.lookUpEditCategory.Location = new System.Drawing.Point(98, 38);
            this.lookUpEditCategory.Name = "lookUpEditCategory";
            this.lookUpEditCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCategory.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Category", "Mục cha"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SubCategory", "Mục con")});
            this.lookUpEditCategory.Properties.NullText = "";
            this.lookUpEditCategory.Size = new System.Drawing.Size(468, 20);
            this.lookUpEditCategory.TabIndex = 1;
            // 
            // lookUpEditDepartment
            // 
            this.lookUpEditDepartment.Location = new System.Drawing.Point(98, 9);
            this.lookUpEditDepartment.Name = "lookUpEditDepartment";
            this.lookUpEditDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditDepartment.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentName", "Bộ phận")});
            this.lookUpEditDepartment.Properties.NullText = "";
            this.lookUpEditDepartment.Size = new System.Drawing.Size(468, 20);
            this.lookUpEditDepartment.TabIndex = 0;
            // 
            // FrmFlightFinalReportAddDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 332);
            this.Controls.Add(this.lookUpEditDepartment);
            this.Controls.Add(this.lookUpEditCategory);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.memoEditNote);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "FrmFlightFinalReportAddDepartment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm bộ phận";
            this.Load += new System.EventHandler(this.FrmFlightFinalReportAddDepartment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.memoEditNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDepartment.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit memoEditNote;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraTreeList.Columns.TreeListBand treeListBand1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCategory;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditDepartment;
    }
}