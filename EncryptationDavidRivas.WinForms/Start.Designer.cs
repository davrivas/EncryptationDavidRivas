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
            this.tabStart = new System.Windows.Forms.TabControl();
            this.tabLogin = new System.Windows.Forms.TabPage();
            this.Register = new System.Windows.Forms.TabPage();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.tabStart.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabStart
            // 
            resources.ApplyResources(this.tabStart, "tabStart");
            this.tabStart.Controls.Add(this.tabLogin);
            this.tabStart.Controls.Add(this.Register);
            this.tabStart.Controls.Add(this.tabUsers);
            this.tabStart.Name = "tabStart";
            this.tabStart.SelectedIndex = 0;
            // 
            // tabLogin
            // 
            resources.ApplyResources(this.tabLogin, "tabLogin");
            this.tabLogin.Name = "tabLogin";
            this.tabLogin.UseVisualStyleBackColor = true;
            // 
            // Register
            // 
            resources.ApplyResources(this.Register, "Register");
            this.Register.Name = "Register";
            this.Register.UseVisualStyleBackColor = true;
            // 
            // tabUsers
            // 
            resources.ApplyResources(this.tabUsers, "tabUsers");
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // Start
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabStart);
            this.MaximizeBox = false;
            this.Name = "Start";
            this.tabStart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabStart;
        private System.Windows.Forms.TabPage tabLogin;
        private System.Windows.Forms.TabPage Register;
        private System.Windows.Forms.TabPage tabUsers;
    }
}

