using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Xml.Serialization;
using System.Diagnostics;
using System.IO;
using ReceiveLib;
using SendLib;
using plant_lenght;
using plant_gridpicture;
using CoreTweet.Core;

namespace PlantServer
{
    public partial class Form1 : Form
    {
        private FileSystemWatcher watcher = null;
        private int FileWatcherCnt = 0;
        public Plant_Information LC_p_info = new Plant_Information();
        private Server_Information s_info = new Server_Information();
        public Plant_Information[] plant_info = new Plant_Information[1];
        public Plant_Client_Information plant_c_info = new Plant_Client_Information();
        private Network_Information Net_info = new Network_Information();
        private Send Machine_send = new Send();
        private StringIoReceive Myreceive = new StringIoReceive();
        public Form1()
        {
            InitializeComponent();
            OriginalInitializeComponent();
        }
        private void OriginalInitializeComponent()
        {

            this.MaximizeBox = !this.MaximizeBox;
            s_info.ENDform = true;
            //ディレクトリ設定
            s_info.stClientDir = Directory.GetCurrentDirectory().TrimEnd('s', 'e', 'r', 'v', 'e', 'r') + "client\\";
            s_info.stPlantPicturetDir = Directory.GetCurrentDirectory().TrimEnd('s', 'e', 'r', 'v', 'e', 'r') + "植物画像\\";
            s_info.stPlantinfoDir = Directory.GetCurrentDirectory().TrimEnd('s', 'e', 'r', 'v', 'e', 'r') + "植物情報\\";
            s_info.stLightChangeXmlDir = s_info.stClientDir + "LightChange.xml";
            string hostname = Dns.GetHostName();
            IPAddress[] adrList = Dns.GetHostAddresses(hostname);
            foreach (IPAddress address in adrList)
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    Net_info.MyServerIPAdress = address.ToString();
                    break;
                }
            }
            Net_info.MyServerReceivePort = Myreceive.Getport();
            if (Net_info.MyServerReceivePort == -1)
            {
                MessageBox.Show("使用できる受信用ポー トがないため開始できません。\n終了します。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MainWindClosing();
            }
            Myreceive.Start(Net_info.MyServerReceivePort);
            MyServerIPAdressLb.Text = "IPv4：\n" + Net_info.MyServerIPAdress;
            MyServerPortnumLb.Text = "ポート番号：\n" + Net_info.MyServerReceivePort.ToString();
            TwitterLb.Text = "";

            //PlantClientInformation.xmlファイル初期設定
            StartupPlantClientInformationXmlWrite();

            FileWatcher();
            //イベントハンドラ
            Myreceive.ConnectedPeer += MyReceive_ConnectedPeer;
            Myreceive.LostConnectedPeer += MyReceive_LostConnectedPeer;
            Myreceive.ReceivedMessage += MyReceive_ReceivedMessage;
        }

        /// <summary>
        /// 新たに接続が確立されたときに発生するイベント
        /// </summary>
        void MyReceive_ConnectedPeer(object sender, IPEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                Net_info.MachineIPAdress = e.IPAddress.ToString();
                Net_info.MachineSendPort = int.Parse(e.PortNumber);
            });
        }
        /// <summary>
        /// 切断されたときに発生するイベント
        /// </summary>
        void MyReceive_LostConnectedPeer(object sender, IPEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                if (Machine_send.ConnectCheck()) Machine_send.Close();
                ConnectLb.Text = "切断";
                MainWindClosing();
            });
        }
        /// <summary>
        /// メッセージを受信したときに発生するイベント
        /// </summary>
        void MyReceive_ReceivedMessage(object sender, MessageEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate ()//別スレッドでイベントが発生するため、必ず必要
            {

                //受け取ったものがメッセージだった場合
                //次に画像を受信するためメッセージから各植物情報を取り出し変数に代入するだけ
                if (e.Type == MessageType.Message)
                {
                    string[] message_info = e.Message.Split(',');
                    if (message_info[0] == "M")
                    {
                        if (message_info[1] == "0")
                        {
                            Net_info.MachineReceivePort = int.Parse(message_info[2]);
                            ConnectMachine();
                        }
                        
                        else if (message_info[1] == "1")
                        {
                            s_info.grocwcnt = int.Parse(message_info[2]);
                            s_info.dayscnt = int.Parse(message_info[3]);
                            s_info.startday = message_info[4];
                            s_info.today = message_info[5];
                            s_info.pixel = int.Parse(message_info[6]);
                            s_info.watercheck = int.Parse(message_info[7]);
                            s_info.lenght = lenght.get_lenght(int.Parse(message_info[6]));
                            s_info.foldername = s_info.stPlantPicturetDir + "植物(" + s_info.grocwcnt.ToString() + ")" + "\\";
                            s_info.filename = s_info.foldername + s_info.today.Replace("/", "-") + ".JPG";
                            s_info.makefilename = s_info.foldername + s_info.today.Replace("/", "-") + "(罫線).JPG";
                        }
                        else if (message_info[1] == "2")
                        {
                            if (message_info[2] == "0")
                            {
                                HarvestPlantClientInformationXmlWrite(0);
                                if (TwitterBt.Text == "ON") TwetterTweetInterval(2);
                            }
                            else if (message_info[2] == "1")
                            {
                                HarvestPlantClientInformationXmlWrite(1);
                                if (TwitterBt.Text == "ON") TwetterTweetInterval(3);
                            }
                            string message = "S" + "," + "0";
                            MessageSend(message);
                            s_info.ENDform = true;
                        }

                    }
                }
                //受け取ったものが画像だった場合
                else if (e.Type == MessageType.Image)
                {
                    plant_c_info.startup = 2;
                    //育成日数が一日であればフォルダを作成
                    if (!Directory.Exists(s_info.foldername))
                    {
                        s_info.ENDform = false;
                        Directory.CreateDirectory(s_info.foldername);
                        // hStream が破棄されることを保証するために using を使用する
                        // 指定したパスのファイルを作成する
                        using (FileStream hStream = File.Create(s_info.stPlantinfoDir + "植物(" + s_info.grocwcnt.ToString() + ").xml"))
                        {
                            if (hStream != null) hStream.Close();
                        }
                        Array.Resize<Plant_Information>(ref plant_info, 1);
                        plant_c_info.startup = 3;//育成開始番号:3
                        if (TwitterBt.Text == "ON") TwetterTweetInterval(1);
                    }
                    Bitmap bmp = new Bitmap(e.Image);
                    bmp.Save(s_info.filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //罫線のある画像の生成
                    gridpicture.make((int)Math.Floor((double)s_info.pixel / 4), s_info.filename, s_info.makefilename);
                    //クライアントのアプリケーションに必要な情報をxml ファイルに書き込む
                    PlantClientInformationXmlWrite();
                    PlantInformationXmlWrite();
                    if (TwitterBt.Text == "ON") TwetterTweetPlant();
                    string message = "S" + "," + "0";
                    MessageSend(message);
                }
            });
        }
        private void ConnectMachine()
        {
            try
            {
                Machine_send.Connect(Net_info.MachineIPAdress, Net_info.MachineReceivePort);//接続
                ConnectLb.Text = "接続中";
            }
            catch
            {
                MessageBox.Show(
                    "接続できませんでした。\r\n" +
                    "Plant-IoT機器が動作しているかをもう一度ご確認ください\r\n",
                    "接続失敗", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// メッセージ(植物情報)をサーバに送信
        /// </summary>
        private bool MessageSend(string message)
        {
            bool flg = true;
            try
            {
                Machine_send.SendMessage(message);//メッセージ送信
            }
            catch (Exception)
            {
                Machine_send.Close();//不正常なので切断
                flg = false;
            }
            return flg;
        }

        /// <summary>
        ///TwetterTweet
        /// </summary>
        private void TwetterTweetPlant()
        {
            Tweet_Information twe = new Tweet_Information();
            twe.tweetcmp01 = "カイワレダイコン\n<<育成" + plant_c_info.growcnt.ToString() + ">>\n開始日付(仮)：\n" + plant_c_info.startday + "から" + (plant_c_info.dayscnt - 1).ToString() + "日目\n**" + plant_c_info.period + "**\n";
            if (plant_c_info.lenght < 0) twe.tweetcmp02 = "伸長：---\n";
            else twe.tweetcmp02 = "伸長：" + plant_c_info.lenght.ToString() + "\n";
            twe.tweetcmp03 = "育成LED：" + plant_c_info.light + "\n水(有無)：" + plant_c_info.watercheck;
            if (plant_c_info.watercheck == "なし")
            {
                if (plant_c_info.period == "過剰成長期" || plant_c_info.period == "測定不可") twe.tweetcmp04 = "\n警告：水がありません。\n成長しすぎですので、\n収穫してください。";
                else twe.tweetcmp04 = "\n警告：水がありません。";
            }
            else if (plant_c_info.period == "過剰成長期" || plant_c_info.period == "測定不可") twe.tweetcmp04 = "\n警告：\n成長しすぎですので、\n収穫してください。";
            twe.tweetstr = twe.tweetcmp01 + twe.tweetcmp02 + twe.tweetcmp03 + twe.tweetcmp04;
            var tokens = CoreTweet.Tokens.Create("L4CTQYTkUxuC1sJp1to10Idgy"
                , "uzCwiV3xpcdgxupVSGS5b6jKfRVXEMu6xTTU6B5KtjSSlccKZc"
                , "795954379438206976-m27OuUHKg4Ot5hxGYtft8x3gsW0hZrR"
                , "kIK99Dd7kzISAlXta8kWUwAFEeX8CS9N5qX7XCGSOvkkH");

            try
            {
                tokens.Statuses.UpdateWithMedia(status => twe.tweetstr, media => new FileInfo(plant_c_info.stPictureDir));
                TwitterLb.Text = "OK";
            }
            catch
            {
                TwitterLb.Text = "NO";
                goto E01;
            }
            E01:;
        }
        private void TwetterTweetInterval(int point)
        {
            var tokens = CoreTweet.Tokens.Create("L4CTQYTkUxuC1sJp1to10Idgy"
                , "uzCwiV3xpcdgxupVSGS5b6jKfRVXEMu6xTTU6B5KtjSSlccKZc"
                , "795954379438206976-m27OuUHKg4Ot5hxGYtft8x3gsW0hZrR"
                , "kIK99Dd7kzISAlXta8kWUwAFEeX8CS9N5qX7XCGSOvkkH");
            try
            {
                if (point == 1) tokens.Statuses.Update(new { status = "第" + s_info.grocwcnt.ToString() + "回目の育成が開始されました。" });
                if (point == 2) tokens.Statuses.Update(new { status = "第" + s_info.grocwcnt.ToString() + "回目のカイワレダイコンが収穫されました。" });
                if (point == 3) tokens.Statuses.Update(new { status = "第" + s_info.grocwcnt.ToString() + "回目の育成が強制終了されました。" });
                if (point == 4) tokens.Statuses.Update(new { status = "第" + s_info.grocwcnt.ToString() + "回目のライトが変更されました。" });
                TwitterLb.Text = "OK";
            }
            catch
            {
                TwitterLb.Text = "NO";
                goto Ei;
            }
            Ei:;
        }
        /// <summary>
        /// PlantClientInformation.xml初期化
        /// </summary>
        private void StartupPlantClientInformationXmlWrite()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Plant_Client_Information));
            StreamWriter sw = new StreamWriter(s_info.stClientDir + "PlantClientInformation.xml", false, new UTF8Encoding(false));
            serializer.Serialize(sw, plant_c_info);
            sw.Close();
        }
        /// <summary>
        /// PlantClientInformation.xml収穫されたときの情報の書き込み
        /// </summary>
        private void HarvestPlantClientInformationXmlWrite(int HPCI_StartUp)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Plant_Client_Information));
            StreamReader sr = new StreamReader(s_info.stClientDir + "PlantClientInformation.xml", new UTF8Encoding(false));
            plant_c_info = (Plant_Client_Information)serializer.Deserialize(sr);
            sr.Close();
            plant_c_info.startup = HPCI_StartUp;
            XmlSerializer serializer1 = new XmlSerializer(typeof(Plant_Client_Information));
            StreamWriter sw = new StreamWriter(s_info.stClientDir + "PlantClientInformation.xml", false, new UTF8Encoding(false));
            serializer1.Serialize(sw, plant_c_info);
            sw.Close();
        }
        /// <summary>
        /// PlantClientInformation.xml植物情報を書き込み
        /// </summary>
        private void PlantClientInformationXmlWrite()
        {
            plant_c_info.growcnt = s_info.grocwcnt;
            plant_c_info.dayscnt = s_info.dayscnt;
            plant_c_info.startday = s_info.startday;
            plant_c_info.today = s_info.today;
            plant_c_info.lenght = s_info.lenght;
            if (s_info.pixel < 479) plant_c_info.period = "測定不可";
            else if (s_info.pixel < 837) plant_c_info.period = "過剰成長期";
            else if (s_info.pixel < 1437) plant_c_info.period = "収穫期";
            else if (s_info.pixel < 2668) plant_c_info.period = "成長期";
            else plant_c_info.period = "発芽期";
            if (s_info.pixel >= 837 && s_info.pixel < 2668) plant_c_info.light = "ON";
            else plant_c_info.light = "OFF";
            if (s_info.watercheck == 1) plant_c_info.watercheck = "あり";
            else plant_c_info.watercheck = "なし";
            plant_c_info.stPictureDir = s_info.filename;
            plant_c_info.stPictureGridDir = s_info.makefilename;
            XmlSerializer serializer = new XmlSerializer(typeof(Plant_Client_Information));
            StreamWriter sw = new StreamWriter(s_info.stClientDir + "PlantClientInformation.xml", false, new UTF8Encoding(false));
            serializer.Serialize(sw, plant_c_info);
            sw.Close();
        }
        /// <summary>
        /// 各植物情報をデータベースとしてxmlファイルに書き込み
        /// </summary>
        private void PlantInformationXmlWrite()
        {
            if (s_info.dayscnt != 1)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Plant_Information[]));
                StreamReader sr = new StreamReader(s_info.stPlantinfoDir + "植物(" + s_info.grocwcnt.ToString() + ").xml", new UTF8Encoding(false));
                plant_info = (Plant_Information[])serializer.Deserialize(sr);
                sr.Close();
                Array.Resize<Plant_Information>(ref plant_info, plant_info.Length + 1);
            }
            plant_info[plant_info.Length - 1] = new Plant_Information();
            plant_info[plant_info.Length - 1].stPictureDir = plant_c_info.stPictureDir;
            plant_info[plant_info.Length - 1].stPictureGridDir = plant_c_info.stPictureGridDir;
            plant_info[plant_info.Length - 1].day = plant_c_info.today;
            plant_info[plant_info.Length - 1].period = plant_c_info.period;
            plant_info[plant_info.Length - 1].lenght = plant_c_info.lenght.ToString();
            plant_info[plant_info.Length - 1].light = plant_c_info.light;
            plant_info[plant_info.Length - 1].watercheck = plant_c_info.watercheck;
            XmlSerializer serializer1 = new XmlSerializer(typeof(Plant_Information[]));
            StreamWriter sw = new StreamWriter(s_info.stPlantinfoDir + "植物(" + s_info.grocwcnt.ToString() + ").xml", false, new UTF8Encoding(false));
            serializer1.Serialize(sw, plant_info);
            sw.Close();
        }



        /// <summary>
        ///PlantClientInformation.xmlを監視してサーバからの更新を待つ
        /// </summary>
        private void FileWatcher()
        {
            if (watcher != null) return;
            watcher = new System.IO.FileSystemWatcher();
            //監視するディレクトリを指定
            watcher.Path = Directory.GetCurrentDirectory().TrimEnd('s', 'e', 'r', 'v', 'e', 'r') + "client";

            //ファイルの変更を監視する
            watcher.NotifyFilter = (System.IO.NotifyFilters.LastWrite);
            //サブディレクトリは監視しない
            watcher.IncludeSubdirectories = false;
            watcher.Filter = "LightChange.xml";
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
                string message;
                XmlSerializer serializer = new XmlSerializer(typeof(Plant_Information));
                StreamReader sr = new StreamReader(s_info.stLightChangeXmlDir, new UTF8Encoding(false));
                LC_p_info = (Plant_Information)serializer.Deserialize(sr);
                if (LC_p_info.light == "ON") message = "S" + "," + "1" + "," + "1";
                else message = "S" + "," + "1" + "," + "0";
                MessageSend(message);
                plant_c_info.light = LC_p_info.light;
                XmlSerializer serializer1 = new XmlSerializer(typeof(Plant_Client_Information));
                StreamWriter sw = new StreamWriter(s_info.stClientDir + "PlantClientInformation.xml", false, new UTF8Encoding(false));
                serializer1.Serialize(sw, plant_c_info);
                sw.Close();
                PlantInformationXmlWrite();
                if (TwitterBt.Text == "ON") TwetterTweetInterval(4);
                FileWatcherCnt = 0;
            }
        }

        private void TwitterBt_Click(object sender, EventArgs e)
        {
            if (TwitterBt.Text == "ON") TwitterBt.Text = "OFF";
            else TwitterBt.Text = "ON";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult result = DialogResult.Yes;
            if (!s_info.ENDform)
            {
                result = MessageBox.Show("テスト中ですが、強制終了しますか？", "質問", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (result == DialogResult.No) e.Cancel = true;
            else MainWindClosing();

        }
        private void MainWindClosing()
        {
            string exe_name = "plant_client";
            //エラー処理

            while (true)
            {
                if (Process.GetProcessesByName(exe_name).Length >= 1)
                {
                    MessageBox.Show("閉じる(初期化)出来ません。\nplant_client.exeを終了させて下さい。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else break;
            }
            //完全に終了できないときがあるので強制終了する
            watcher.EnableRaisingEvents = false;
            watcher.Dispose();
            //初期化//
            // フォルダを削除する
            Directory.Delete(s_info.stPlantPicturetDir, true);
            Directory.Delete(s_info.stPlantinfoDir, true);
            // フォルダを作成する
            Directory.CreateDirectory(s_info.stPlantPicturetDir);
            Directory.CreateDirectory(s_info.stPlantinfoDir);
            //PlantClientInformation.xmlファイル初期化
            plant_c_info = new Plant_Client_Information();
            plant_c_info.startup = -2;
            XmlSerializer serializer = new XmlSerializer(typeof(Plant_Client_Information));
            StreamWriter sw = new StreamWriter(s_info.stClientDir + "PlantClientInformation.xml", false, new UTF8Encoding(false));
            serializer.Serialize(sw, plant_c_info);
            sw.Close();
            Environment.Exit(0);
        }
    }
}