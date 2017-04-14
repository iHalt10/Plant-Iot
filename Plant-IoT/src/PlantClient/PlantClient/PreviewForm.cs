using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantClient
{
    public partial class PreviewForm : Form
    {
        private string stPictureDir;
        private string stPictureGridDir;
        private bool picture_change;
        public PreviewForm(string stPictureDir1 = "", string stPictureGridDir1 = "")
        {
            InitializeComponent();
            if (stPictureDir1 != "") OriginalInitializeComponent(stPictureDir1, stPictureGridDir1);
        }
        /// <summary>
        ///初期設定
        /// </summary>
        private void OriginalInitializeComponent(string stPictureDir1, string stPictureGridDir1)
        {
            //初期設定
            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            stPictureDir = stPictureDir1;
            stPictureGridDir = stPictureGridDir1;
            pictureBox1.Image = Image.FromFile(stPictureDir);
            picture_change = true;
        }

    }
}
