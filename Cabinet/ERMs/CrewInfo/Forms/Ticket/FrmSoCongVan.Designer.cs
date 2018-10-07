namespace CrewInfo.Forms.Ticket
{
    partial class FrmSoCongVan
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
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.txtSoCV = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoCV.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(32, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Số CV:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(197, 35);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Ok";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtSoCV
            // 
            this.txtSoCV.Location = new System.Drawing.Point(60, 9);
            this.txtSoCV.Name = "txtSoCV";
            this.txtSoCV.Size = new System.Drawing.Size(212, 20);
            this.txtSoCV.TabIndex = 5;
            // 
            // FrmSoCongVan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 67);
            this.Controls.Add(this.txtSoCV);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelControl1);
            this.Name = "FrmSoCongVan";
            this.Text = "Nhập số công văn";
            ((System.ComponentModel.ISupportInitialize)(this.txtSoCV.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.TextEdit txtSoCV;
    }
}