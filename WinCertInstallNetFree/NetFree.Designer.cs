namespace WinCertInstallNetFree
{
    partial class NetFree
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_remove = new System.Windows.Forms.Button();
            this.bt_install = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.s_cert = new System.Windows.Forms.Label();
            this.s_isp = new System.Windows.Forms.Label();
            this.recheck = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::WinCertInstallNetFree.Properties.Resources.logo_small;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 129);
            this.panel1.TabIndex = 0;
            // 
            // bt_remove
            // 
            this.bt_remove.Location = new System.Drawing.Point(12, 193);
            this.bt_remove.Name = "bt_remove";
            this.bt_remove.Size = new System.Drawing.Size(114, 30);
            this.bt_remove.TabIndex = 1;
            this.bt_remove.Text = "הסר תעודה";
            this.bt_remove.UseVisualStyleBackColor = true;
            this.bt_remove.Click += new System.EventHandler(this.bt_remove_Click);
            // 
            // bt_install
            // 
            this.bt_install.Location = new System.Drawing.Point(12, 157);
            this.bt_install.Name = "bt_install";
            this.bt_install.Size = new System.Drawing.Size(114, 30);
            this.bt_install.TabIndex = 2;
            this.bt_install.Text = "התקן תעודה";
            this.bt_install.UseVisualStyleBackColor = true;
            this.bt_install.Click += new System.EventHandler(this.bt_install_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(270, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "מצב תעודה:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(269, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "חיבור לספק:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // s_cert
            // 
            this.s_cert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.s_cert.Location = new System.Drawing.Point(191, 159);
            this.s_cert.Name = "s_cert";
            this.s_cert.Size = new System.Drawing.Size(71, 27);
            this.s_cert.TabIndex = 5;
            this.s_cert.Text = "מותקן";
            this.s_cert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // s_isp
            // 
            this.s_isp.ForeColor = System.Drawing.Color.Lime;
            this.s_isp.Location = new System.Drawing.Point(191, 179);
            this.s_isp.Name = "s_isp";
            this.s_isp.Size = new System.Drawing.Size(71, 30);
            this.s_isp.TabIndex = 6;
            this.s_isp.Text = "מחובר";
            this.s_isp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // recheck
            // 
            this.recheck.AutoSize = true;
            this.recheck.Location = new System.Drawing.Point(286, 206);
            this.recheck.Name = "recheck";
            this.recheck.Size = new System.Drawing.Size(56, 13);
            this.recheck.TabIndex = 7;
            this.recheck.TabStop = true;
            this.recheck.Text = "בדוק שוב";
            this.recheck.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.recheck_LinkClicked);
            // 
            // NetFree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(355, 239);
            this.Controls.Add(this.recheck);
            this.Controls.Add(this.s_isp);
            this.Controls.Add(this.s_cert);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_install);
            this.Controls.Add(this.bt_remove);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NetFree";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "NetFree";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_remove;
        private System.Windows.Forms.Button bt_install;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label s_cert;
        private System.Windows.Forms.Label s_isp;
        private System.Windows.Forms.LinkLabel recheck;
    }
}

