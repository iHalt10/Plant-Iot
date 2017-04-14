namespace PlantServer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ConnectLb = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MyServerPortnumLb = new System.Windows.Forms.Label();
            this.MyServerIPAdressLb = new System.Windows.Forms.Label();
            this.TwitterBt = new System.Windows.Forms.Button();
            this.TwitterLb = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectLb
            // 
            this.ConnectLb.AutoSize = true;
            this.ConnectLb.Font = new System.Drawing.Font("Yu Gothic UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ConnectLb.Location = new System.Drawing.Point(103, 23);
            this.ConnectLb.Name = "ConnectLb";
            this.ConnectLb.Size = new System.Drawing.Size(50, 25);
            this.ConnectLb.TabIndex = 0;
            this.ConnectLb.Text = "切断";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MyServerPortnumLb);
            this.groupBox1.Controls.Add(this.MyServerIPAdressLb);
            this.groupBox1.Font = new System.Drawing.Font("Yu Gothic UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 148);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "サーバ側";
            // 
            // MyServerPortnumLb
            // 
            this.MyServerPortnumLb.AutoSize = true;
            this.MyServerPortnumLb.Location = new System.Drawing.Point(31, 86);
            this.MyServerPortnumLb.Name = "MyServerPortnumLb";
            this.MyServerPortnumLb.Size = new System.Drawing.Size(110, 50);
            this.MyServerPortnumLb.TabIndex = 1;
            this.MyServerPortnumLb.Text = "ポート番号：\r\n1111111";
            // 
            // MyServerIPAdressLb
            // 
            this.MyServerIPAdressLb.AutoSize = true;
            this.MyServerIPAdressLb.Location = new System.Drawing.Point(31, 27);
            this.MyServerIPAdressLb.Name = "MyServerIPAdressLb";
            this.MyServerIPAdressLb.Size = new System.Drawing.Size(110, 50);
            this.MyServerIPAdressLb.TabIndex = 0;
            this.MyServerIPAdressLb.Text = "IPv4：\r\n111.111.111";
            // 
            // TwitterBt
            // 
            this.TwitterBt.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TwitterBt.Location = new System.Drawing.Point(204, 100);
            this.TwitterBt.Name = "TwitterBt";
            this.TwitterBt.Size = new System.Drawing.Size(50, 33);
            this.TwitterBt.TabIndex = 2;
            this.TwitterBt.Text = "ON";
            this.TwitterBt.UseVisualStyleBackColor = true;
            this.TwitterBt.Click += new System.EventHandler(this.TwitterBt_Click);
            // 
            // TwitterLb
            // 
            this.TwitterLb.AutoSize = true;
            this.TwitterLb.Font = new System.Drawing.Font("Yu Gothic UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TwitterLb.Location = new System.Drawing.Point(213, 161);
            this.TwitterLb.Name = "TwitterLb";
            this.TwitterLb.Size = new System.Drawing.Size(33, 23);
            this.TwitterLb.TabIndex = 3;
            this.TwitterLb.Text = "OK";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 233);
            this.Controls.Add(this.TwitterLb);
            this.Controls.Add(this.TwitterBt);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ConnectLb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ConnectLb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label MyServerPortnumLb;
        private System.Windows.Forms.Label MyServerIPAdressLb;
        private System.Windows.Forms.Button TwitterBt;
        private System.Windows.Forms.Label TwitterLb;
    }
}

