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
using System.Xml.Serialization;

namespace PlantClient
{
    public partial class PlantInformationRecordForm : Form
    {
        private Plant_Information[] plant_info;
        private PreviewForm pv_fm = new PreviewForm();
        public PlantInformationRecordForm(string stPlantInforDir = "")
        {
            InitializeComponent();
            if (stPlantInforDir != "") OriginalInitializeComponent(stPlantInforDir);
        }
        /// <summary>
        ///初期設定
        /// </summary>
        private void OriginalInitializeComponent(string stPlantInforDir)
        {
            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            XmlSerializer serializer = new XmlSerializer(typeof(Plant_Information[]));
            StreamReader sr = new StreamReader(stPlantInforDir, new UTF8Encoding(false));
            plant_info = (Plant_Information[])serializer.Deserialize(sr);
            sr.Close();
            for (int i = 0; i < plant_info.Length; i++)
            {
                dataGridView1.Rows.Add("表示", plant_info[i].day, plant_info[i].period, plant_info[i].lenght, plant_info[i].light, plant_info[i].watercheck);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            //"Button"列ならば、ボタンがクリックされた
            if (dgv.Columns[e.ColumnIndex].Name == "picture")
            {
                if (pv_fm.Visible) return;
                else pv_fm = new PreviewForm(plant_info[e.RowIndex].stPictureDir, plant_info[e.RowIndex].stPictureGridDir);
                pv_fm.StartPosition = FormStartPosition.CenterScreen;
                pv_fm.Show();
            }
        }
    }
}
