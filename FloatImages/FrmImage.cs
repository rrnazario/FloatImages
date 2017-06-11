using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FloatImages
{
    public partial class FrmImage : Form
    {
        /// <summary>
        /// Main form of application.
        /// </summary>
        FrmPrincipal mainForm;

        /// <summary>
        /// Path of current image.
        /// </summary>
        public string ownPath;

        public FrmImage()
        {
            InitializeComponent();
        }

        public FrmImage(string path, FrmPrincipal frmPrincipal, Point initialPlace)
        {
            InitializeComponent();
            imgContainer.Load(path);
            imgContainer.Invalidate();

            Width = imgContainer.PreferredSize.Width + 10; //required for form border does not cover a litle image border part.
            Height = imgContainer.PreferredSize.Height + 35; //required for form border does not cover a litle image border part.

            Top = initialPlace.X;
            Left = initialPlace.Y;

            imgContainer.Top = 0;
            imgContainer.Left = 0;

            mainForm = frmPrincipal;
            ownPath = path;
        }

        private void FrmImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.imgPath = ownPath;

            imgContainer = null;       

            //update main form label status
            mainForm.lblStatus.Text = string.Format("Openned images: {0}", --mainForm.totalOpenedImages);

            //Remove itself from closing control main form list
            mainForm.frmImagesList.Remove(this);            
        }

        private void FrmImage_KeyDown(object sender, KeyEventArgs e)
        {
            //Copy the current image to clipboard
            if (e.KeyCode == Keys.C && e.Control)
                Clipboard.SetImage(imgContainer.Image);
            else
            if (e.KeyCode == Keys.Escape)
                Close();
            else
            if(e.KeyCode == Keys.S && e.Control)
            {
                var dr = svd.ShowDialog();

                if (dr == DialogResult.OK)
                    imgContainer.Image.Save(svd.FileName);
            }
        }

        private void imgContainer_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                ctxImgForm.Show(this, e.X, e.Y);
        }

        public void setFormTitleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Text = Interaction.InputBox("Type the new form name:", "Set form title", Text, Top, Left);
        }
    }
}
