namespace PlantClient
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
            this.ImageChangeLb = new System.Windows.Forms.Label();
            this.TitleLb = new System.Windows.Forms.Label();
            this.GrowcntLb = new System.Windows.Forms.Label();
            this.UpdateBt = new System.Windows.Forms.Button();
            this.LightChangeBt = new System.Windows.Forms.Button();
            this.PlantGroupBox = new System.Windows.Forms.GroupBox();
            this.WaterWarningLb = new System.Windows.Forms.Label();
            this.GrowLb = new System.Windows.Forms.Label();
            this.PeriodLb = new System.Windows.Forms.Label();
            this.LenghtLb = new System.Windows.Forms.Label();
            this.LightLb = new System.Windows.Forms.Label();
            this.TodayLb = new System.Windows.Forms.Label();
            this.StartdayLb = new System.Windows.Forms.Label();
            this.PlantComboBox = new System.Windows.Forms.ComboBox();
            this.OpenPlantBt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PlantPictureBox)).BeginInit();
            this.PlantGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlantPictureBox
            // 
            this.PlantPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlantPictureBox.Location = new System.Drawing.Point(615, 27);
            this.PlantPictureBox.Name = "PlantPictureBox";
            this.PlantPictureBox.Size = new System.Drawing.Size(407, 511);
            this.PlantPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PlantPictureBox.TabIndex = 0;
            this.PlantPictureBox.TabStop = false;
            this.PlantPictureBox.Click += new System.EventHandler(this.PlantPictureBox_Click);
            // 
            // ImageChangeLb
            // 
            this.ImageChangeLb.AutoSize = true;
            this.ImageChangeLb.Location = new System.Drawing.Point(731, 9);
            this.ImageChangeLb.Name = "ImageChangeLb";
            this.ImageChangeLb.Size = new System.Drawing.Size(160, 15);
            this.ImageChangeLb.TabIndex = 1;
            this.ImageChangeLb.Text = "クリックで画像が変わります";
            // 
            // TitleLb
            // 
            this.TitleLb.AutoSize = true;
            this.TitleLb.Font = new System.Drawing.Font("Yu Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TitleLb.Location = new System.Drawing.Point(35, 27);
            this.TitleLb.Name = "TitleLb";
            this.TitleLb.Size = new System.Drawing.Size(328, 55);
            this.TitleLb.TabIndex = 2;
            this.TitleLb.Text = "カイワレダイコン";
            // 
            // GrowcntLb
            // 
            this.GrowcntLb.AutoSize = true;
            this.GrowcntLb.Font = new System.Drawing.Font("Yu Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GrowcntLb.Location = new System.Drawing.Point(247, 82);
            this.GrowcntLb.Name = "GrowcntLb";
            this.GrowcntLb.Size = new System.Drawing.Size(213, 40);
            this.GrowcntLb.TabIndex = 3;
            this.GrowcntLb.Text = "～育成０回目～";
            // 
            // UpdateBt
            // 
            this.UpdateBt.Font = new System.Drawing.Font("Yu Gothic UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.UpdateBt.Location = new System.Drawing.Point(96, 184);
            this.UpdateBt.Name = "UpdateBt";
            this.UpdateBt.Size = new System.Drawing.Size(60, 30);
            this.UpdateBt.TabIndex = 4;
            this.UpdateBt.Text = "更新";
            this.UpdateBt.UseVisualStyleBackColor = true;
            this.UpdateBt.Click += new System.EventHandler(this.UpdateBt_Click);
            // 
            // LightChangeBt
            // 
            this.LightChangeBt.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LightChangeBt.Location = new System.Drawing.Point(228, 184);
            this.LightChangeBt.Name = "LightChangeBt";
            this.LightChangeBt.Size = new System.Drawing.Size(101, 29);
            this.LightChangeBt.TabIndex = 5;
            this.LightChangeBt.Text = "ライト変更";
            this.LightChangeBt.UseVisualStyleBackColor = true;
            this.LightChangeBt.Click += new System.EventHandler(this.LightChangeBt_Click);
            // 
            // PlantGroupBox
            // 
            this.PlantGroupBox.Controls.Add(this.WaterWarningLb);
            this.PlantGroupBox.Controls.Add(this.GrowLb);
            this.PlantGroupBox.Controls.Add(this.PeriodLb);
            this.PlantGroupBox.Controls.Add(this.LenghtLb);
            this.PlantGroupBox.Controls.Add(this.LightLb);
            this.PlantGroupBox.Controls.Add(this.TodayLb);
            this.PlantGroupBox.Controls.Add(this.StartdayLb);
            this.PlantGroupBox.Font = new System.Drawing.Font("Yu Gothic UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PlantGroupBox.Location = new System.Drawing.Point(12, 256);
            this.PlantGroupBox.Name = "PlantGroupBox";
            this.PlantGroupBox.Size = new System.Drawing.Size(587, 270);
            this.PlantGroupBox.TabIndex = 6;
            this.PlantGroupBox.TabStop = false;
            this.PlantGroupBox.Text = "育成開始から0日目";
            // 
            // WaterWarningLb
            // 
            this.WaterWarningLb.AutoSize = true;
            this.WaterWarningLb.ForeColor = System.Drawing.Color.Red;
            this.WaterWarningLb.Location = new System.Drawing.Point(81, 216);
            this.WaterWarningLb.Name = "WaterWarningLb";
            this.WaterWarningLb.Size = new System.Drawing.Size(178, 25);
            this.WaterWarningLb.TabIndex = 6;
            this.WaterWarningLb.Text = "警告：水がありません";
            // 
            // GrowLb
            // 
            this.GrowLb.AutoSize = true;
            this.GrowLb.Location = new System.Drawing.Point(347, 216);
            this.GrowLb.Name = "GrowLb";
            this.GrowLb.Size = new System.Drawing.Size(160, 25);
            this.GrowLb.TabIndex = 5;
            this.GrowLb.Text = "強制収穫されました";
            // 
            // PeriodLb
            // 
            this.PeriodLb.AutoSize = true;
            this.PeriodLb.Location = new System.Drawing.Point(237, 161);
            this.PeriodLb.Name = "PeriodLb";
            this.PeriodLb.Size = new System.Drawing.Size(107, 25);
            this.PeriodLb.TabIndex = 4;
            this.PeriodLb.Text = "過剰成長期";
            // 
            // LenghtLb
            // 
            this.LenghtLb.AutoSize = true;
            this.LenghtLb.Location = new System.Drawing.Point(347, 104);
            this.LenghtLb.Name = "LenghtLb";
            this.LenghtLb.Size = new System.Drawing.Size(145, 25);
            this.LenghtLb.TabIndex = 3;
            this.LenghtLb.Text = "伸長：測定不可";
            // 
            // LightLb
            // 
            this.LightLb.AutoSize = true;
            this.LightLb.Location = new System.Drawing.Point(79, 104);
            this.LightLb.Name = "LightLb";
            this.LightLb.Size = new System.Drawing.Size(171, 25);
            this.LightLb.TabIndex = 2;
            this.LightLb.Text = "植物育成LED：OFF";
            // 
            // TodayLb
            // 
            this.TodayLb.AutoSize = true;
            this.TodayLb.Location = new System.Drawing.Point(347, 47);
            this.TodayLb.Name = "TodayLb";
            this.TodayLb.Size = new System.Drawing.Size(154, 25);
            this.TodayLb.TabIndex = 1;
            this.TodayLb.Text = "現在日付：01/01";
            // 
            // StartdayLb
            // 
            this.StartdayLb.AutoSize = true;
            this.StartdayLb.Location = new System.Drawing.Point(79, 47);
            this.StartdayLb.Name = "StartdayLb";
            this.StartdayLb.Size = new System.Drawing.Size(154, 25);
            this.StartdayLb.TabIndex = 0;
            this.StartdayLb.Text = "開始日付：01/01";
            // 
            // PlantComboBox
            // 
            this.PlantComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlantComboBox.FormattingEnabled = true;
            this.PlantComboBox.Location = new System.Drawing.Point(415, 169);
            this.PlantComboBox.Name = "PlantComboBox";
            this.PlantComboBox.Size = new System.Drawing.Size(121, 23);
            this.PlantComboBox.TabIndex = 7;
            // 
            // OpenPlantBt
            // 
            this.OpenPlantBt.Location = new System.Drawing.Point(438, 212);
            this.OpenPlantBt.Name = "OpenPlantBt";
            this.OpenPlantBt.Size = new System.Drawing.Size(75, 23);
            this.OpenPlantBt.TabIndex = 8;
            this.OpenPlantBt.Text = "開く";
            this.OpenPlantBt.UseVisualStyleBackColor = true;
            this.OpenPlantBt.Click += new System.EventHandler(this.OpenPlantBt_Click);
            // 
            // MainWind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 538);
            this.Controls.Add(this.OpenPlantBt);
            this.Controls.Add(this.PlantComboBox);
            this.Controls.Add(this.PlantGroupBox);
            this.Controls.Add(this.LightChangeBt);
            this.Controls.Add(this.UpdateBt);
            this.Controls.Add(this.GrowcntLb);
            this.Controls.Add(this.TitleLb);
            this.Controls.Add(this.ImageChangeLb);
            this.Controls.Add(this.PlantPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWind";
            this.Text = "PlantClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWind_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PlantPictureBox)).EndInit();
            this.PlantGroupBox.ResumeLayout(false);
            this.PlantGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PlantPictureBox;
        private System.Windows.Forms.Label ImageChangeLb;
        private System.Windows.Forms.Label TitleLb;
        private System.Windows.Forms.Label GrowcntLb;
        private System.Windows.Forms.Button UpdateBt;
        private System.Windows.Forms.Button LightChangeBt;
        private System.Windows.Forms.GroupBox PlantGroupBox;
        private System.Windows.Forms.Label GrowLb;
        private System.Windows.Forms.Label PeriodLb;
        private System.Windows.Forms.Label LenghtLb;
        private System.Windows.Forms.Label LightLb;
        private System.Windows.Forms.Label TodayLb;
        private System.Windows.Forms.Label StartdayLb;
        private System.Windows.Forms.ComboBox PlantComboBox;
        private System.Windows.Forms.Button OpenPlantBt;
        private System.Windows.Forms.Label WaterWarningLb;
    }
}

