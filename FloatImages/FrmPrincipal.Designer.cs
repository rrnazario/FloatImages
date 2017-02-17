namespace FloatImages
{
    partial class FrmPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.lblStatus = new System.Windows.Forms.Label();
            this.ntfIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ckbShowImagesTaskbar = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(51, 29);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(174, 15);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Total de imagens abertas: 0";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ntfIcon
            // 
            this.ntfIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ntfIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfIcon.Icon")));
            this.ntfIcon.Text = "FloatImages 0.1";
            this.ntfIcon.Visible = true;
            this.ntfIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ntfIcon_MouseDoubleClick);
            // 
            // ckbShowImagesTaskbar
            // 
            this.ckbShowImagesTaskbar.AutoSize = true;
            this.ckbShowImagesTaskbar.Checked = true;
            this.ckbShowImagesTaskbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbShowImagesTaskbar.Location = new System.Drawing.Point(56, 72);
            this.ckbShowImagesTaskbar.Name = "ckbShowImagesTaskbar";
            this.ckbShowImagesTaskbar.Size = new System.Drawing.Size(169, 17);
            this.ckbShowImagesTaskbar.TabIndex = 1;
            this.ckbShowImagesTaskbar.Text = "Show image icons on Taskbar";
            this.ckbShowImagesTaskbar.UseVisualStyleBackColor = true;
            this.ckbShowImagesTaskbar.CheckedChanged += new System.EventHandler(this.ckbShowImagesTaskbar_CheckedChanged);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 152);
            this.Controls.Add(this.ckbShowImagesTaskbar);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FloatImages 0.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.Resize += new System.EventHandler(this.FrmPrincipal_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.NotifyIcon ntfIcon;
        private System.Windows.Forms.CheckBox ckbShowImagesTaskbar;
    }
}

