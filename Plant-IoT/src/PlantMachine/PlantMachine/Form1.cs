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
using System.IO;
using SendLib;
using ReceiveLib;
using plant_pixel;
using plant_resizepicture;

namespace PlantMachine
{
    public partial class MainWind : Form
    {
        
        private ButtonCheck BtCheck = new ButtonCheck();
        private ComboBoxCustomItem cbci;
        private MachinePlantInformation m_info = new MachinePlantInformation();
        private Network_Information Net_info = new Network_Information();
        private Send Server_send = new Send();
        private StringIoReceive Myreceive = new StringIoReceive();
        public MainWind()
        {
            InitializeComponent();
            OriginalInitializeComponent();
        }
        private void OriginalInitializeComponent()
        {
            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            StartBt.Enabled = false;
            NextDayBt.Enabled = false;
            HarvestBt.Enabled = false;
            BtCheck.ENDform = true;
            Lb_Pb_initialization();

            m_info.grocwcnt = 0;
            //TestComboBox
            string stCurrentDir = Directory.GetCurrentDirectory();
            string stDir = stCurrentDir.TrimEnd('m', 'a', 'c', 'h', 'i', 'n', 'e');
            Plant_TestItems testitems = new Plant_TestItems(stDir + "植物画像(テスト)\\");
            for (int i = 0; i < testitems.ItemsNum; i++) TestComboBox.Items.Add(testitems.Add[i]);
            TestComboBox.SelectedIndex = 0;

            string hostname = Dns.GetHostName();
            IPAddress[] adrList = Dns.GetHostAddresses(hostname);
            foreach (IPAddress address in adrList)
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    Net_info.MyMachineIPAdress = address.ToString();
                    break;
                }
            }
            Net_info.MyMachineReceivePort = Myreceive.Getport();
            if (Net_info.MyMachineReceivePort == -1)
            {
                MessageBox.Show("使用できる受信用ポー トがないため開始できません。\n終了します。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(0);
            }
            Myreceive.Start(Net_info.MyMachineReceivePort);
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
                Net_info.ServerSendPort = int.Parse(e.PortNumber);
                listBox.Items.Add("サーバとの送受信できます。");
                ConnectBt.Text = "接続中";
                StartBt.Enabled = true;
            });
        }
        /// <summary>
        /// 切断されたときに発生するイベント
        /// </summary>
        void MyReceive_LostConnectedPeer(object sender, IPEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                if(Server_send.ConnectCheck())Server_send.Close();
                ConnectBt.Text = "切断";
                listBox.Items.Add("サーバとの送受信できません。");
                MessageBox.Show("サーバに接続できません。強制終了します。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(0);
            });
        }
        /// <summary>
        /// メッセージを受信したときに発生するイベント
        /// </summary>
        void MyReceive_ReceivedMessage(object sender, MessageEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate ()//別スレッドでイベントが発生するため、必ず必要
            {

                if (e.Type == MessageType.Message)
                {
                    string[] message_info = e.Message.Split(',');
                    if (message_info[0] == "S")
                    {
                        if (message_info[1] == "0")
                        {
                            if (BtCheck.ActionBtCheck == 1)//StartBt
                            {
                                BtCheck.ENDform = false;
                                Lb_pb_substitution();
                                NextDayBt.Enabled = true;
                                HarvestBt.Enabled = true;
                                listBox.Items.Add("育成を開始");
                            }
                            else if (BtCheck.ActionBtCheck == 2)//NextBt
                            {
                                NextDayBt.Enabled = true;
                                if (m_info.dayscnt == cbci.fileCount)
                                {
                                    NextDayBt.Enabled = false;
                                    HarvestBt.Text = "強制\n収穫";
                                    MessageBox.Show("テストファイルが最後まで到達しました。\n強制収穫して下さい。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                Lb_pb_substitution();
                                listBox.Items.Add("次の日");
                            }
                            else if (BtCheck.ActionBtCheck == 3)//HarvestBt
                            {
                                if (HarvestBt.Text == "強制\n収穫") HarvestBt.Text = "収穫";
                                Lb_Pb_initialization();
                                TestComboBox.Enabled = true;
                                StartDateTimePicker.Enabled = true;
                                StartBt.Enabled = true;
                                NextDayBt.Enabled = false;
                                HarvestBt.Enabled = false;
                                BtCheck.ENDform = true;
                                listBox.Items.Add("収穫");
                            }
                        }
                        else if(message_info[1] == "1")
                        {
                            if(message_info[2]=="1")
                            {
                                LightPictureBox.Image = Image.FromFile("Light_ON.JPG");
                                LightLb.Text = "育成LED：ON";
                            }
                            else
                            {
                                LightPictureBox.Image = Image.FromFile("Light_OFF.JPG");
                                LightLb.Text = "育成LED：OFF";
                            }
                            listBox.Items.Add("ライト変更");
                        }
                    }
                }
            });
        }

        private void ConnectBt_Click(object sender, EventArgs e)
        {
            //そうでない場合（切断状態）だったら接続処理をする
            if (IPv4TextBox.Text == "" || PortTextBox.Text == "") return;//未入力項目がある場合
            Server_send.Connect(IPv4TextBox.Text, int.Parse(PortTextBox.Text));//接続
            Net_info.ServerIPAdress = IPv4TextBox.Text;
            ConnectBt.Enabled = false;
            try
            {
                Net_info.ServerReceivePort = int.Parse(PortTextBox.Text);
                listBox.Items.Add("サーバへの送信接続が確立");
            }
            catch
            {
                MessageBox.Show(
                    "接続できませんでした。\r\n" +
                    "入力内容が正しいか、植物育成管理サーバーが動作しているかをもう一度ご確認ください\r\n",
                    "接続失敗", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConnectBt.Enabled = true;
                goto Error1;
            }
            string message = "M" + "," + "0" + "," + Net_info.MyMachineReceivePort.ToString();
            if (MessageSend(message)) listBox.Items.Add("サーバに受信用ポート番号を送信しました。");
            else
            {
                listBox.Items.Add("送信することができませんでした。\n植物育成管理サーバーと接続されていない可能性があります。\n再接続してください。");
                ConnectBt.Enabled = true;
            }
        Error1:;
        }

        private void StartBt_Click(object sender, EventArgs e)
        {
            cbci = new ComboBoxCustomItem();
            cbci = (ComboBoxCustomItem)TestComboBox.SelectedItem;
            if (cbci.text == "選択されていません") return;
            BtCheck.ActionBtCheck = 1;
            StartBt.Enabled = false;
            WaterChangeBt.Enabled = false;
            if (m_info.grocwcnt == 10000)
            {
                MessageBox.Show("植物育成回数の限界値を超えたため、\n強制終了します。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(0);
            }
            TestComboBox.Enabled = false;
            StartDateTimePicker.Enabled = false;
            m_info.grocwcnt++;
            m_info.dayscnt = 0;
            m_info.startday = StartDateTimePicker.Value;
            m_info.maxday = m_info.startday.AddDays(cbci.fileCount - 1);
            PlantAdvance();
            WaterChangeBt.Enabled = true;
        }
        private void NextDayBt_Click(object sender, EventArgs e)
        {
            NextDayBt.Enabled = false;
            WaterChangeBt.Enabled = false;
            BtCheck.ActionBtCheck = 2;
            PlantAdvance();
            WaterChangeBt.Enabled = true;
        }
        private void HarvestBt_Click(object sender, EventArgs e)
        {
            string message;
            HarvestBt.Enabled = false;
            BtCheck.ActionBtCheck = 3;
            if (HarvestBt.Text == "収穫") message = "M" + "," + "2" + "," + "0";
            else message = "M" + "," + "2" + "," + "1";
            MessageSend(message);
        }
        private void PlantAdvance()
        {
            PlantPictureBox.Image.Dispose();
            m_info.dayscnt++;
            m_info.today = m_info.startday.AddDays(m_info.dayscnt - 1);
            m_info.watercheck = WaterCheckCount("CNT");
            m_info.pixel = pixel.get_pixel(cbci.dir + "image(" + m_info.dayscnt.ToString() + ").JPG");
            string message = "M" + "," + "1" + "," + m_info.grocwcnt.ToString() + "," + m_info.dayscnt.ToString() + "," + m_info.startday.ToShortDateString() + "," + m_info.today.ToShortDateString() + "," + m_info.pixel.ToString() + "," + m_info.watercheck;
            resizepicture.make(cbci.dir + "image(" + m_info.dayscnt.ToString() + ").JPG");
            Image picsend = Image.FromFile("Resize.JPG");
            MessageSend(message);
            PictureSend(picsend);
            picsend.Dispose();
        }
        /// <summary>
        /// メッセージ(植物情報)をサーバに送信
        /// </summary>
        private bool MessageSend(string message)
        {
            bool flg = true;
            try
            {
                Server_send.SendMessage(message);//メッセージ送信
            }
            catch (Exception)
            {
                Server_send.Close();//不正常なので切断
                flg = false;
            }
            return flg;
        }
        /// <summary>
        /// 画像をサーバに送信
        /// </summary>
        private bool PictureSend(Image imagesend)
        {
            bool flg = true;
            try
            {
                Server_send.SendImage(imagesend);//画像送信
            }
            catch (Exception)
            {
                Server_send.Close();//不正常なので切断
                flg = false;
            }
            return flg;
        }
        private void Lb_Pb_initialization()
        {
            StartdayLb.Text = "開始日付：";
            TodayLb.Text = "現在日付：";
            MaxdayLb.Text = "(最大日付)：";
            LightLb.Text = "育成LED：";
            PeriodLb.Text = "";
            PlantPictureBox.Image = Image.FromFile("Plant_initial.JPG");
            LightPictureBox.Image = Image.FromFile("Light_OFF.JPG");
            if (WaterCheckCount("CHE") == "1")
            {
                WaterLb.Text = "";
                WaterPictureBox.BackColor = Color.Aqua;
            }
            else
            {
                WaterLb.Text = "※水がありません";
                WaterPictureBox.BackColor = Color.AliceBlue;
            }
        }
        private void Lb_pb_substitution()
        {

            StartdayLb.Text = "開始日付：\n" + m_info.startday.ToShortDateString();
            TodayLb.Text = "現在日付：\n" + m_info.today.ToShortDateString();
            MaxdayLb.Text = "(最大日付)：\n" + m_info.maxday.ToShortDateString();
            if (m_info.pixel < 479) PeriodLb.Text = "測定不可";
            else if (m_info.pixel < 837) PeriodLb.Text = "過剰成長期";
            else if (m_info.pixel < 1437) PeriodLb.Text = "収穫期";
            else if (m_info.pixel < 2668) PeriodLb.Text = "成長期";
            else PeriodLb.Text = "発芽期";
            PlantPictureBox.Image = Image.FromFile("Resize.JPG");
            if (m_info.pixel >= 837 && m_info.pixel < 2668)
            {
                LightLb.Text = "育成LED：ON";
                LightPictureBox.Image = Image.FromFile("Light_ON.JPG");
            }
            else
            {
                LightLb.Text = "育成LED：OFF";
                LightPictureBox.Image = Image.FromFile("Light_OFF.JPG");
            }

            if (WaterCheckCount("CHE") == "1")
            {
                WaterLb.Text = "";
                WaterPictureBox.BackColor = Color.Aqua;
            }
            else
            {
                WaterLb.Text = "※水がありません";
                WaterPictureBox.BackColor = Color.AliceBlue;
            }
        }
        private string WaterCheckCount(string mode)
        {
            if (mode == "CHE" && m_info.waterCnt > 0) return "1";
            else if (mode == "CHE") return "0";
            if (mode == "CNT")
            {
                m_info.waterCnt--;
                if (m_info.waterCnt > 0)return "1";
                else return "0";
            }
            return "-1";
            
        }

        private void WaterChangeBt_Click(object sender, EventArgs e)
        {
            m_info.waterCnt = 3;
            WaterLb.Text = "";
            WaterPictureBox.BackColor = Color.Aqua;
        }

        private void PortTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //0～9と、バックスペース以外の時は、イベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b') e.Handled = true;
        }

        private void MainWind_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = DialogResult.Yes;
            if (!BtCheck.ENDform)
            {
                result = MessageBox.Show("テスト中ですが、強制終了しますか？", "質問", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            }
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

    }
}
