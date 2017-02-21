namespace FloatImages
{
    partial class FrmPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrint));
            this.SuspendLayout();
            // 
            // FrmPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrint";
            this.Text = "Selecione a imagem.";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrint_FormClosed);
            this.Load += new System.EventHandler(this.frmPrint_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmPrint_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrint_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmPrint_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmPrint_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmPrint_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}