namespace PlantClient
{
    partial class PlantInformationRecordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlantInformationRecordForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.picture = new System.Windows.Forms.DataGridViewButtonColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lenght = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.light = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.watercheck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.picture,
            this.date,
            this.period,
            this.lenght,
            this.light,
            this.watercheck});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(828, 554);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // picture
            // 
            this.picture.HeaderText = "写真";
            this.picture.Name = "picture";
            this.picture.ReadOnly = true;
            // 
            // date
            // 
            this.date.HeaderText = "日付";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // period
            // 
            this.period.HeaderText = "期間";
            this.period.Name = "period";
            this.period.ReadOnly = true;
            this.period.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.period.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lenght
            // 
            this.lenght.HeaderText = "伸長";
            this.lenght.Name = "lenght";
            this.lenght.ReadOnly = true;
            // 
            // light
            // 
            this.light.HeaderText = "ライト";
            this.light.Name = "light";
            this.light.ReadOnly = true;
            // 
            // watercheck
            // 
            this.watercheck.HeaderText = "水(有無)";
            this.watercheck.Name = "watercheck";
            this.watercheck.ReadOnly = true;
            // 
            // PlantInformationRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 553);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlantInformationRecordForm";
            this.Text = "植物データベース";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn picture;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn period;
        private System.Windows.Forms.DataGridViewTextBoxColumn lenght;
        private System.Windows.Forms.DataGridViewTextBoxColumn light;
        private System.Windows.Forms.DataGridViewTextBoxColumn watercheck;
    }
}