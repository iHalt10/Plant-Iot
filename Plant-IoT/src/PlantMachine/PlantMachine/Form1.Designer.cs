namespace PlantMachine
{
    partial class MainWind
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWind));
            this.PlantPictureBox = new System.Windows.Forms.PictureBox();
            this.WaterPictureBox = new System.Windows.Forms.PictureBox();
            this.LightPictureBox = new System.Windows.Forms.PictureBox();
            this.StartBt = new System.Windows.Forms.Button();
            this.HarvestBt = new System.Windows.Forms.Button();
            this.WaterChangeBt = new System.Windows.Forms.Button();
            this.WaterLb = new System.Windows.Forms.Label();
            this.TestComboBox = new System.Windows.Forms.ComboBox();
            this.StartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.NextDayBt = new System.Windows.Forms.Button();
            this.NetworkGroupBox1 = new System.Windows.Forms.GroupBox();
            this.ConnectBt = new System.Windows.Forms.Button();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.IPv4TextBox = new System.Windows.Forms.TextBox();
            this.PortLb = new System.Windows.Forms.Label();
            this.IPv4Lb = new System.Windows.Forms.Label();
            this.PlantGroupBox = new System.Windows.Forms.GroupBox();
            this.LightLb = new System.Windows.Forms.Label();
            this.MaxdayLb = new System.Windows.Forms.Label();
            this.TodayLb = new System.Windows.Forms.Label();
            this.StartdayLb = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.TestSelectLb = new System.Windows.Forms.Label();
            this.StartSelectLb = new System.Windows.Forms.Label();
            this.PeriodLb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PlantPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WaterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightPictureBox)).BeginInit();
            this.NetworkGroupBox1.SuspendLayout();
            this.PlantGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlantPictureBox
            // 
            this.PlantPictureBox.Location = new System.Drawing.Point(0, 0);
            this.PlantPictureBox.Name = "PlantPictureBox";
            this.PlantPictureBox.Size = new System.Drawing.Size(479, 605);
            this.PlantPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PlantPictureBox.TabIndex = 0;
            this.PlantPictureBox.TabStop = false;
            // 
            // WaterPictureBox
            // 
            this.WaterPictureBox.BackColor = System.Drawing.Color.Aqua;
            this.WaterPictureBox.Location = new System.Drawing.Point(0, 603);
            this.WaterPictureBox.Name = "WaterPictureBox";
            this.WaterPictureBox.Size = new System.Drawing.Size(479, 73);
            this.WaterPictureBox.TabIndex = 1;
            this.WaterPictureBox.TabStop = false;
            // 
            // LightPictureBox
            // 
            this.LightPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.LightPictureBox.Location = new System.Drawing.Point(191, 12);
            this.LightPictureBox.Name = "LightPictureBox";
            this.LightPictureBox.Size = new System.Drawing.Size(88, 126);
            this.LightPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LightPictureBox.TabIndex = 2;
            this.LightPictureBox.TabStop = false;
            // 
            // StartBt
            // 
            this.StartBt.BackColor = System.Drawing.SystemColors.Info;
            this.StartBt.Font = new System.Drawing.Font("Yu Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StartBt.Location = new System.Drawing.Point(756, 50);
            this.StartBt.Name = "StartBt";
            this.StartBt.Size = new System.Drawing.Size(80, 80);
            this.StartBt.TabIndex = 3;
            this.StartBt.Text = "種まき";
            this.StartBt.UseVisualStyleBackColor = false;
            this.StartBt.Click += new System.EventHandler(this.StartBt_Click);
            // 
            // HarvestBt
            // 
            this.HarvestBt.BackColor = System.Drawing.Color.Honeydew;
            this.HarvestBt.Font = new System.Drawing.Font("Yu Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.HarvestBt.Location = new System.Drawing.Point(1046, 50);
            this.HarvestBt.Name = "HarvestBt";
            this.HarvestBt.Size = new System.Drawing.Size(80, 80);
            this.HarvestBt.TabIndex = 4;
            this.HarvestBt.Text = "収穫";
            this.HarvestBt.UseVisualStyleBackColor = false;
            this.HarvestBt.Click += new System.EventHandler(this.HarvestBt_Click);
            // 
            // WaterChangeBt
            // 
            this.WaterChangeBt.BackColor = System.Drawing.Color.LightCyan;
            this.WaterChangeBt.Font = new System.Drawing.Font("Yu Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.WaterChangeBt.Location = new System.Drawing.Point(904, 179);
            this.WaterChangeBt.Name = "WaterChangeBt";
            this.WaterChangeBt.Size = new System.Drawing.Size(80, 80);
            this.WaterChangeBt.TabIndex = 5;
            this.WaterChangeBt.Text = "水替え";
            this.WaterChangeBt.UseVisualStyleBackColor = false;
            this.WaterChangeBt.Click += new System.EventHandler(this.WaterChangeBt_Click);
            // 
            // WaterLb
            // 
            this.WaterLb.AutoSize = true;
            this.WaterLb.Font = new System.Drawing.Font("MS UI Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.WaterLb.ForeColor = System.Drawing.Color.Red;
            this.WaterLb.Location = new System.Drawing.Point(1013, 211);
            this.WaterLb.Name = "WaterLb";
            this.WaterLb.Size = new System.Drawing.Size(145, 19);
            this.WaterLb.TabIndex = 6;
            this.WaterLb.Text = "※水がありません";
            // 
            // TestComboBox
            // 
            this.TestComboBox.Font = new System.Drawing.Font("MS UI Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TestComboBox.FormattingEnabled = true;
            this.TestComboBox.Location = new System.Drawing.Point(499, 71);
            this.TestComboBox.Name = "TestComboBox";
            this.TestComboBox.Size = new System.Drawing.Size(176, 26);
            this.TestComboBox.TabIndex = 7;
            // 
            // StartDateTimePicker
            // 
            this.StartDateTimePicker.Font = new System.Drawing.Font("MS UI Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StartDateTimePicker.Location = new System.Drawing.Point(499, 179);
            this.StartDateTimePicker.Name = "StartDateTimePicker";
            this.StartDateTimePicker.Size = new System.Drawing.Size(176, 25);
            this.StartDateTimePicker.TabIndex = 0;
            // 
            // NextDayBt
            // 
            this.NextDayBt.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NextDayBt.Location = new System.Drawing.Point(899, 100);
            this.NextDayBt.Name = "NextDayBt";
            this.NextDayBt.Size = new System.Drawing.Size(85, 30);
            this.NextDayBt.TabIndex = 8;
            this.NextDayBt.Text = "次の日＞";
            this.NextDayBt.UseVisualStyleBackColor = true;
            this.NextDayBt.Click += new System.EventHandler(this.NextDayBt_Click);
            // 
            // NetworkGroupBox1
            // 
            this.NetworkGroupBox1.Controls.Add(this.ConnectBt);
            this.NetworkGroupBox1.Controls.Add(this.PortTextBox);
            this.NetworkGroupBox1.Controls.Add(this.IPv4TextBox);
            this.NetworkGroupBox1.Controls.Add(this.PortLb);
            this.NetworkGroupBox1.Controls.Add(this.IPv4Lb);
            this.NetworkGroupBox1.Font = new System.Drawing.Font("MS UI Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NetworkGroupBox1.Location = new System.Drawing.Point(691, 295);
            this.NetworkGroupBox1.Name = "NetworkGroupBox1";
            this.NetworkGroupBox1.Size = new System.Drawing.Size(181, 366);
            this.NetworkGroupBox1.TabIndex = 9;
            this.NetworkGroupBox1.TabStop = false;
            this.NetworkGroupBox1.Text = "サーバ側接続";
            // 
            // ConnectBt
            // 
            this.ConnectBt.Location = new System.Drawing.Point(47, 269);
            this.ConnectBt.Name = "ConnectBt";
            this.ConnectBt.Size = new System.Drawing.Size(85, 30);
            this.ConnectBt.TabIndex = 4;
            this.ConnectBt.Text = "接続";
            this.ConnectBt.UseVisualStyleBackColor = true;
            this.ConnectBt.Click += new System.EventHandler(this.ConnectBt_Click);
            // 
            // PortTextBox
            // 
            this.PortTextBox.Font = new System.Drawing.Font("MS UI Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PortTextBox.Location = new System.Drawing.Point(6, 199);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(169, 24);
            this.PortTextBox.TabIndex = 3;
            this.PortTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PortTextBox_KeyPress);
            // 
            // IPv4TextBox
            // 
            this.IPv4TextBox.Font = new System.Drawing.Font("MS UI Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.IPv4TextBox.Location = new System.Drawing.Point(6, 102);
            this.IPv4TextBox.Name = "IPv4TextBox";
            this.IPv4TextBox.Size = new System.Drawing.Size(169, 24);
            this.IPv4TextBox.TabIndex = 2;
            // 
            // PortLb
            // 
            this.PortLb.AutoSize = true;
            this.PortLb.Font = new System.Drawing.Font("MS UI Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PortLb.Location = new System.Drawing.Point(6, 174);
            this.PortLb.Name = "PortLb";
            this.PortLb.Size = new System.Drawing.Size(87, 17);
            this.PortLb.TabIndex = 1;
            this.PortLb.Text = "ポート番号";
            // 
            // IPv4Lb
            // 
            this.IPv4Lb.AutoSize = true;
            this.IPv4Lb.Font = new System.Drawing.Font("MS UI Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.IPv4Lb.Location = new System.Drawing.Point(6, 73);
            this.IPv4Lb.Name = "IPv4Lb";
            this.IPv4Lb.Size = new System.Drawing.Size(126, 17);
            this.IPv4Lb.TabIndex = 0;
            this.IPv4Lb.Text = "IPアドレス(IPv4)";
            // 
            // PlantGroupBox
            // 
            this.PlantGroupBox.Controls.Add(this.LightLb);
            this.PlantGroupBox.Controls.Add(this.MaxdayLb);
            this.PlantGroupBox.Controls.Add(this.TodayLb);
            this.PlantGroupBox.Controls.Add(this.StartdayLb);
            this.PlantGroupBox.Font = new System.Drawing.Font("MS UI Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PlantGroupBox.Location = new System.Drawing.Point(485, 295);
            this.PlantGroupBox.Name = "PlantGroupBox";
            this.PlantGroupBox.Size = new System.Drawing.Size(200, 366);
            this.PlantGroupBox.TabIndex = 5;
            this.PlantGroupBox.TabStop = false;
            this.PlantGroupBox.Text = "その他　育成情報";
            // 
            // LightLb
            // 
            this.LightLb.AutoSize = true;
            this.LightLb.Location = new System.Drawing.Point(11, 258);
            this.LightLb.Name = "LightLb";
            this.LightLb.Size = new System.Drawing.Size(120, 17);
            this.LightLb.TabIndex = 3;
            this.LightLb.Text = "育成LED：OFF";
            // 
            // MaxdayLb
            // 
            this.MaxdayLb.AutoSize = true;
            this.MaxdayLb.Font = new System.Drawing.Font("MS UI Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MaxdayLb.Location = new System.Drawing.Point(11, 190);
            this.MaxdayLb.Name = "MaxdayLb";
            this.MaxdayLb.Size = new System.Drawing.Size(102, 17);
            this.MaxdayLb.TabIndex = 2;
            this.MaxdayLb.Text = "(最大日付)：";
            // 
            // TodayLb
            // 
            this.TodayLb.AutoSize = true;
            this.TodayLb.Font = new System.Drawing.Font("MS UI Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TodayLb.Location = new System.Drawing.Point(6, 122);
            this.TodayLb.Name = "TodayLb";
            this.TodayLb.Size = new System.Drawing.Size(90, 17);
            this.TodayLb.TabIndex = 1;
            this.TodayLb.Text = "現在日付：";
            // 
            // StartdayLb
            // 
            this.StartdayLb.AutoSize = true;
            this.StartdayLb.Font = new System.Drawing.Font("MS UI Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StartdayLb.Location = new System.Drawing.Point(6, 51);
            this.StartdayLb.Name = "StartdayLb";
            this.StartdayLb.Size = new System.Drawing.Size(90, 17);
            this.StartdayLb.TabIndex = 0;
            this.StartdayLb.Text = "開始日付：";
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 15;
            this.listBox.Location = new System.Drawing.Point(887, 299);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(370, 364);
            this.listBox.TabIndex = 10;
            // 
            // TestSelectLb
            // 
            this.TestSelectLb.AutoSize = true;
            this.TestSelectLb.Font = new System.Drawing.Font("MS UI Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TestSelectLb.Location = new System.Drawing.Point(496, 51);
            this.TestSelectLb.Name = "TestSelectLb";
            this.TestSelectLb.Size = new System.Drawing.Size(85, 17);
            this.TestSelectLb.TabIndex = 11;
            this.TestSelectLb.Text = "テスト項目";
            // 
            // StartSelectLb
            // 
            this.StartSelectLb.AutoSize = true;
            this.StartSelectLb.Font = new System.Drawing.Font("MS UI Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StartSelectLb.Location = new System.Drawing.Point(496, 159);
            this.StartSelectLb.Name = "StartSelectLb";
            this.StartSelectLb.Size = new System.Drawing.Size(80, 17);
            this.StartSelectLb.TabIndex = 12;
            this.StartSelectLb.Text = "開始日付";
            // 
            // PeriodLb
            // 
            this.PeriodLb.AutoSize = true;
            this.PeriodLb.Font = new System.Drawing.Font("Yu Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PeriodLb.Location = new System.Drawing.Point(872, 34);
            this.PeriodLb.Name = "PeriodLb";
            this.PeriodLb.Size = new System.Drawing.Size(135, 34);
            this.PeriodLb.TabIndex = 13;
            this.PeriodLb.Text = "過剰成長期";
            // 
            // MainWind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.PeriodLb);
            this.Controls.Add(this.StartSelectLb);
            this.Controls.Add(this.TestSelectLb);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.PlantGroupBox);
            this.Controls.Add(this.NetworkGroupBox1);
            this.Controls.Add(this.NextDayBt);
            this.Controls.Add(this.StartDateTimePicker);
            this.Controls.Add(this.TestComboBox);
            this.Controls.Add(this.WaterLb);
            this.Controls.Add(this.WaterChangeBt);
            this.Controls.Add(this.HarvestBt);
            this.Controls.Add(this.StartBt);
            this.Controls.Add(this.LightPictureBox);
            this.Controls.Add(this.WaterPictureBox);
            this.Controls.Add(this.PlantPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWind";
            this.Text = "Plant-Machine";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWind_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PlantPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WaterPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightPictureBox)).EndInit();
            this.NetworkGroupBox1.ResumeLayout(false);
            this.NetworkGroupBox1.PerformLayout();
            this.PlantGroupBox.ResumeLayout(false);
            this.PlantGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PlantPictureBox;
        private System.Windows.Forms.PictureBox WaterPictureBox;
        private System.Windows.Forms.PictureBox LightPictureBox;
        private System.Windows.Forms.Button StartBt;
        private System.Windows.Forms.Button HarvestBt;
        private System.Windows.Forms.Button WaterChangeBt;
        private System.Windows.Forms.Label WaterLb;
        private System.Windows.Forms.ComboBox TestComboBox;
        private System.Windows.Forms.DateTimePicker StartDateTimePicker;
        private System.Windows.Forms.Button NextDayBt;
        private System.Windows.Forms.GroupBox NetworkGroupBox1;
        private System.Windows.Forms.Button ConnectBt;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.TextBox IPv4TextBox;
        private System.Windows.Forms.Label PortLb;
        private System.Windows.Forms.Label IPv4Lb;
        private System.Windows.Forms.GroupBox PlantGroupBox;
        private System.Windows.Forms.Label MaxdayLb;
        private System.Windows.Forms.Label TodayLb;
        private System.Windows.Forms.Label StartdayLb;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label TestSelectLb;
        private System.Windows.Forms.Label StartSelectLb;
        private System.Windows.Forms.Label PeriodLb;
        private System.Windows.Forms.Label LightLb;
    }
}

