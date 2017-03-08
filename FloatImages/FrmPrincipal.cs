using System.Windows.Forms;
using System.Runtime.InteropServices;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Linq;

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

        public List<FrmImage> frmImagesList;



        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            ghk = new GlobalHotkey(Constants.ALT + Constants.SHIFT, Keys.None, this);
            ghk.Register();

            imageList = new List<string>();
            frmImagesList = new List<FrmImage>();
#if DEBUG
            lblInfo.Visible = true;
#endif

            var minutesInterval = 1;
            var MinutesToMilliseconds = (int)(new TimeSpan(0, minutesInterval, 0)).TotalMilliseconds;

            var timer = new System.Timers.Timer(MinutesToMilliseconds);

            timer.Elapsed += (s, ev) => EraseDeadImages();
            timer.Start();
        }

        /// <summary>
        /// Remove images that user no longer uses.
        /// </summary>
        private void EraseDeadImages()
        {
            var cloneImageList = new List<string>();
            cloneImageList.AddRange(imageList);

            frmImagesList.ForEach(frmImg => 
            {
                cloneImageList.Remove(frmImg.ownPath);                
            });

            cloneImageList.ForEach( img => 
            {
                File.Delete(img);

                imageList.Remove(img);
            });
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

                        imgPath = string.Concat(DateTime.Now.ToString("ddMMyyyyhhmmss"), ".bmp");
                        bitmap.Save(imgPath, ImageFormat.Bmp);
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
                    frmImagesList.Add(img);

                    //update info label
                    lblStatus.Text = string.Format("Openned images: {0}", ++totalOpenedImages);
                }

                frmPrint = null;
            }
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseAllImages(sender, e);
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

        private void FrmPrincipal_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                ntfIcon.Visible = true;
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                ntfIcon.Visible = false;
            }
        }

        private void ntfIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void ckbShowImagesTaskbar_CheckedChanged(object sender, EventArgs e)
        {
            frmImagesList.ForEach(frm => frm.ShowInTaskbar = (sender as CheckBox).Checked);
        }

        private void lblStatus_TextChanged(object sender, EventArgs e)
        {
            ntfIcon.Text = string.Concat(Application.ProductName, " - ", lblStatus.Text);
        }

        /// <summary>
        /// Close all images generated and erase them from disk.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseAllImages(object sender, EventArgs e)
        {
            //This clone is needed because on every close form method call, the FrmImage instance remove itself from imageList.
            //If we don't do this, ever one form won't be closed.            
            var cloneImageList = new List<FrmImage>();
            cloneImageList.AddRange(frmImagesList);

            cloneImageList.ForEach(frm => frm.Close());
            imageList.ForEach(image => File.Delete(image));
        }

        private void tsExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
