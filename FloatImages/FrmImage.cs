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
        string ownPath;

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
            imgContainer = null;       

            //update main form label status
            mainForm.lblStatus.Text = string.Format("Total de imagens abertas: {0}", --mainForm.totalOpenedImages);

            //Remove itself from closing control main form list
            mainForm.frmImages.Remove(this);
        }

        private void FrmImage_KeyDown(object sender, KeyEventArgs e)
        {
            //Copy the current image to clipboard
            if (e.KeyCode == Keys.C && e.Control)           
                Clipboard.SetImage(imgContainer.Image);            
        }
    }
}
