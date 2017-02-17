using System.Windows.Forms;
using System.Runtime.InteropServices;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.IO;

namespace FloatImages
{
    public partial class FrmPrincipal : Form
    {
        private GlobalHotkey ghk;


        public string imgPath;
        public Rectangle? rectImage;
        public Point? pointImage;
        public int totalOpenedImages = 0;

        private NotifyIcon mynotifyicon = new NotifyIcon();
        private List<string> imageList;
        private FrmPrint frmPrint;

        public List<FrmImage> frmImages;        

        public FrmPrincipal()
        {
            InitializeComponent();            
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            ghk = new GlobalHotkey(Constants.ALT + Constants.SHIFT, Keys.None, this);
            ghk.Register();

            imageList = new List<string>();
            frmImages = new List<FrmImage>();
        }

        private void HandleHotkey()
        {
            if (frmPrint == null)
            {
                frmPrint = new FrmPrint(this);
                frmPrint.ShowDialog();

                if (rectImage != null && pointImage != null)
                {
                    using (Bitmap bitmap = new Bitmap(Math.Abs(rectImage.Value.Width), Math.Abs(rectImage.Value.Height)))
                    {
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            g.CopyFromScreen(pointImage.Value, Point.Empty, rectImage.Value.Size);
                        }

                        imgPath = string.Concat(DateTime.Now.ToString("ddMMyyyyhhmmss"), ".jpg");
                        bitmap.Save(imgPath, ImageFormat.Jpeg);
                    }
                }
                else imgPath = string.Empty;

                if (!string.IsNullOrEmpty(imgPath))
                {
                    //show image form.
                    var img = new FrmImage(imgPath, this, pointImage.Value);
                    img.Show();

                    //variables to control main close form action.
                    imageList.Add(imgPath);
                    frmImages.Add(img);

                    //update info label
                    lblStatus.Text = string.Format("Total de imagens abertas: {0}", ++totalOpenedImages);
                }

                frmPrint = null;
            }
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //This clone is needed because on every close form call, the FrmImage instance remove itself from imageList.
            //If we don't do this, ever one form won't be closed.            
            var cloneImageList = new List<FrmImage>();
            cloneImageList.AddRange(frmImages);

            cloneImageList.ForEach(frm => frm.Close());
            imageList.ForEach(image => File.Delete(image));
        }

        #region Methods to handle Windows HotKeys
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ghk.Unregiser())
                MessageBox.Show("Hotkey failed to unregister!");
        }

        #endregion
    }
}
