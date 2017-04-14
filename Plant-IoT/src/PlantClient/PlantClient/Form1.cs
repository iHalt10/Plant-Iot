using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace PlantClient
{
    public partial class MainWind : Form
    {
        public Plant_Client_Information plant_c_info = new Plant_Client_Information();
        private FileSystemWatcher watcher = null;
        private int FileWatcherCnt = 0;
        private bool picture_change;
        private PlantInformationRecordForm p_info_fm = new PlantInformationRecordForm();
        public Plant_Information LC_p_info = new Plant_Information();
        public MainWind()
        {
            InitializeComponent();
            OriginalInitializeComponent();
        }
        private void OriginalInitializeComponent()
        {
            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            
            StartupPlantClientInformationXmlRead();
            if (plant_c_info.startup == -2)
            {
                MessageBox.Show("サーバを開始してから起動してください。\n「OK」でこのアプリを終了します", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(0);
            }
            else if (plant_c_info.startup == -1)
            {
                MessageBox.Show("第一回植物育成を開始してから起動してください。\n「OK」でこのアプリを終了します", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(0);
            }
            FileWatcher();
            UpdateBt.Enabled = false;
            Plant_Substitution();
        }

        /// <summary>
        /// 植物情報（PlantClientInformation.xml）を読み込む
        /// </summary>
        private void StartupPlantClientInformationXmlRead()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Plant_Client_Information));
            StreamReader sr = new StreamReader("PlantClientInformation.xml", new UTF8Encoding(false));
            plant_c_info = (Plant_Client_Information)serializer.Deserialize(sr);
            sr.Close();
        }

        private void PlantPictureBox_Click(object sender, EventArgs e)
        {
            PlantPictureBox.Enabled = false;
            if (picture_change)
            {
                PlantPictureBox.Image = Image.FromFile(plant_c_info.stPictureGridDir);
                picture_change = false;
            }
            else
            {
                PlantPictureBox.Image = Image.FromFile(plant_c_info.stPictureDir);
                picture_change = true;
            }
            PlantPictureBox.Enabled = true;
        }

        /// <summary>
        ///PlantClientInformation.xmlを監視してサーバからの更新を待つ
        /// </summary>
        private void FileWatcher()
        {
            if (watcher != null) return;
            watcher = new System.IO.FileSystemWatcher();
            //監視するディレクトリを指定
            watcher.Path = Directory.GetCurrentDirectory();

            //ファイルの変更を監視する
            watcher.NotifyFilter = (System.IO.NotifyFilters.LastWrite);
            //サブディレクトリは監視しない
            watcher.IncludeSubdirectories = false;
            watcher.Filter = "PlantClientInformation.xml";
            //UIのスレッドにマーシャリングする
            //コンソールアプリケーションでの使用では必要ない
            watcher.SynchronizingObject = this;
            //イベントハンドラの追加
            watcher.Changed += new System.IO.FileSystemEventHandler(watcher_Changed);
            //監視を開始する
            watcher.EnableRaisingEvents = true;

        }
        //ファイル監視イベントハンドラ
        private void watcher_Changed(object source, FileSystemEventArgs e)
        {
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Changed:
                    FileWatcherCnt++;
                    break;
            }
            if (FileWatcherCnt == 2)
            {
                UpdateBt.Enabled = true;
                FileWatcherCnt = 0;
            }
        }




        /// <summary>
        ///ラベル・画像の設定
        /// </summary>
        private void Plant_Substitution()
        {
            GrowcntLb.Text = "～育成" + plant_c_info.growcnt.ToString() + "回目～";
            PlantGroupBox.Text = "育成開始から" + plant_c_info.dayscnt + "日目";
            StartdayLb.Text = "開始日付：" + plant_c_info.startday;
            PeriodLb.ForeColor = Color.Black;
            if (plant_c_info.period == "収穫期") PeriodLb.ForeColor = Color.Red;
            PeriodLb.Text = plant_c_info.period;
            LightLb.Text = "植物育成LED：" + plant_c_info.light;
            if (plant_c_info.startup == 0)
            {
                GrowLb.ForeColor = Color.Black;
                GrowLb.Text = "収穫されました";
                TodayLb.Text = "終了日付：" + plant_c_info.today;
            }
            else if (plant_c_info.startup == 1)
            {
                GrowLb.ForeColor = Color.Red;
                GrowLb.Text = "強制収穫されました";
                TodayLb.Text = "終了日付：" + plant_c_info.today;
            }
            else if (plant_c_info.startup == 2)
            {
                GrowLb.ForeColor = Color.Black;
                GrowLb.Text = "育成中です";
                TodayLb.Text = "現在日付：" + plant_c_info.today;
            }
            else if (plant_c_info.startup == 3)
            {
                GrowLb.ForeColor = Color.Black;
                GrowLb.Text = "育成が開始されました";
                TodayLb.Text = "現在日付：" + plant_c_info.today;
            }
            LightChangeBt.Enabled = false;
            if (plant_c_info.period == "発芽期" || plant_c_info.period == "測定不可") LenghtLb.Text = "伸長：測定できません";
            else
            {
                if (plant_c_info.startup == 2 && !(plant_c_info.period == "過剰成長期")) LightChangeBt.Enabled = true;
                LenghtLb.Text = "伸長：" + plant_c_info.lenght + " cm";
            }
            WaterWarningLb.Text = "";
            if (plant_c_info.watercheck == "なし") WaterWarningLb.Text = "警告：水がありません。";
            PlantPictureBox.Image = Image.FromFile(plant_c_info.stPictureDir);
            picture_change = true;
            PlantComboBox.Items.Clear();
            PlantXml_Items Items = new PlantXml_Items(plant_c_info.growcnt);
            for (int i = 0; i < plant_c_info.growcnt; i++) PlantComboBox.Items.Add(Items.Add[i]); ;
            PlantComboBox.SelectedIndex = plant_c_info.growcnt - 1;
        }





        private void MainWind_FormClosing(object sender, FormClosingEventArgs e)
        {
            //完全に終了できないときがあるので強制終了する
            watcher.EnableRaisingEvents = false;
            watcher.Dispose();
            Environment.Exit(0);
        }

        private void UpdateBt_Click(object sender, EventArgs e)
        {
            UpdateBt.Enabled = false;
            StartupPlantClientInformationXmlRead();
            Plant_Substitution();
        }

        private void LightChangeBt_Click(object sender, EventArgs e)
        {
            if (UpdateBt.Enabled == true)
            {
                MessageBox.Show("更新してください。", "確認", MessageBoxButtons.OK);
                return;
            }
            string str;
            if (plant_c_info.light == "ON")
            {
                str = "ライトをONからOFFに変更しますか？";
                LC_p_info.light = "OFF";
            }
            else
            {
                str = "ライトをOFFからONに変更しますか？";
                LC_p_info.light = "ON";
            }
            DialogResult result = MessageBox.Show(str, "質問", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            LightChangeBt.Enabled = false;
            LC_p_info.stPictureDir = plant_c_info.stPictureDir;
            LC_p_info.stPictureGridDir = plant_c_info.stPictureGridDir;
            LC_p_info.day = plant_c_info.today;
            LC_p_info.period = plant_c_info.period;
            LC_p_info.lenght = plant_c_info.lenght.ToString();
            LC_p_info.watercheck = plant_c_info.watercheck;
            XmlSerializer serializer1 = new XmlSerializer(typeof(Plant_Information));
            StreamWriter sw = new StreamWriter("LightChange.xml", false, new UTF8Encoding(false));
            serializer1.Serialize(sw, LC_p_info);
            sw.Close();
        }

        private void OpenPlantBt_Click(object sender, EventArgs e)
        {
            ComboBoxCustomItem cbci = (ComboBoxCustomItem)PlantComboBox.SelectedItem;
            if (p_info_fm.Visible) return;
            else p_info_fm = new PlantInformationRecordForm(cbci.dir);
            p_info_fm.StartPosition = FormStartPosition.CenterScreen;
            p_info_fm.Show();
        }
    }
}
