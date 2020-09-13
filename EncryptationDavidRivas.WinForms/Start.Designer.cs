namespace EncryptationDavidRivas.WinForms
{
    partial class Start
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblRSA = new System.Windows.Forms.Label();
            this.lblAES = new System.Windows.Forms.Label();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.txtAES = new System.Windows.Forms.TextBox();
            this.txtRSA = new System.Windows.Forms.TextBox();
            this.picAreandina = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAreandina)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            resources.ApplyResources(this.lblUserName, "lblUserName");
            this.lblUserName.Name = "lblUserName";
            // 
            // txtUserName
            // 
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.Name = "txtUserName";
            // 
            // lblPassword
            // 
            resources.ApplyResources(this.lblPassword, "lblPassword");
            this.lblPassword.Name = "lblPassword";
            // 
            // txtPassword
            // 
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.Name = "txtPassword";
            // 
            // pnlMain
            // 
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.picAreandina);
            this.pnlMain.Controls.Add(this.txtRSA);
            this.pnlMain.Controls.Add(this.txtAES);
            this.pnlMain.Controls.Add(this.lblRSA);
            this.pnlMain.Controls.Add(this.lblAES);
            this.pnlMain.Name = "pnlMain";
            // 
            // lblRSA
            // 
            resources.ApplyResources(this.lblRSA, "lblRSA");
            this.lblRSA.Name = "lblRSA";
            // 
            // lblAES
            // 
            resources.ApplyResources(this.lblAES, "lblAES");
            this.lblAES.Name = "lblAES";
            // 
            // btnEncrypt
            // 
            resources.ApplyResources(this.btnEncrypt, "btnEncrypt");
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.BtnEncrypt_Click);
            // 
            // txtAES
            // 
            resources.ApplyResources(this.txtAES, "txtAES");
            this.txtAES.Name = "txtAES";
            // 
            // txtRSA
            // 
            resources.ApplyResources(this.txtRSA, "txtRSA");
            this.txtRSA.Name = "txtRSA";
            // 
            // picAreandina
            // 
            this.picAreandina.Image = global::EncryptationDavidRivas.WinForms.Properties.Resources.logo_areandina;
            resources.ApplyResources(this.picAreandina, "picAreandina");
            this.picAreandina.Name = "picAreandina";
            this.picAreandina.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Start
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.MaximizeBox = false;
            this.Name = "Start";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAreandina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Label lblRSA;
        private System.Windows.Forms.Label lblAES;
        private System.Windows.Forms.TextBox txtRSA;
        private System.Windows.Forms.TextBox txtAES;
        private System.Windows.Forms.PictureBox picAreandina;
        private System.Windows.Forms.Label label1;
    }
}

