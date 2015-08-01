namespace SnowCover
{
    partial class frmDisasterStatisticsFromExcel
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_FloderPath = new System.Windows.Forms.TextBox();
            this.btn_SetFloderPath = new System.Windows.Forms.Button();
            this.btn_BeginStatistic = new System.Windows.Forms.Button();
            this.btn_OutPutResult = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择文件目录：";
            // 
            // txt_FloderPath
            // 
            this.txt_FloderPath.Location = new System.Drawing.Point(108, 10);
            this.txt_FloderPath.Name = "txt_FloderPath";
            this.txt_FloderPath.Size = new System.Drawing.Size(266, 21);
            this.txt_FloderPath.TabIndex = 1;
            this.txt_FloderPath.Text = "F:\\LYQ\\灾害数据\\灾害数据Excel";
            // 
            // btn_SetFloderPath
            // 
            this.btn_SetFloderPath.Location = new System.Drawing.Point(380, 8);
            this.btn_SetFloderPath.Name = "btn_SetFloderPath";
            this.btn_SetFloderPath.Size = new System.Drawing.Size(60, 23);
            this.btn_SetFloderPath.TabIndex = 2;
            this.btn_SetFloderPath.Text = "浏览";
            this.btn_SetFloderPath.UseVisualStyleBackColor = true;
            this.btn_SetFloderPath.Click += new System.EventHandler(this.btn_SetFloderPath_Click);
            // 
            // btn_BeginStatistic
            // 
            this.btn_BeginStatistic.Location = new System.Drawing.Point(446, 8);
            this.btn_BeginStatistic.Name = "btn_BeginStatistic";
            this.btn_BeginStatistic.Size = new System.Drawing.Size(75, 23);
            this.btn_BeginStatistic.TabIndex = 3;
            this.btn_BeginStatistic.Text = "开始统计";
            this.btn_BeginStatistic.UseVisualStyleBackColor = true;
            this.btn_BeginStatistic.Click += new System.EventHandler(this.btn_BeginStatistic_Click);
            // 
            // btn_OutPutResult
            // 
            this.btn_OutPutResult.Location = new System.Drawing.Point(527, 8);
            this.btn_OutPutResult.Name = "btn_OutPutResult";
            this.btn_OutPutResult.Size = new System.Drawing.Size(75, 23);
            this.btn_OutPutResult.TabIndex = 4;
            this.btn_OutPutResult.Text = "结果输出";
            this.btn_OutPutResult.UseVisualStyleBackColor = true;
            this.btn_OutPutResult.Click += new System.EventHandler(this.btn_OutPutResult_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(591, 307);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.Resize += new System.EventHandler(this.dataGridView1_Resize);
            // 
            // frmDisasterStatisticsFromExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(615, 356);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_OutPutResult);
            this.Controls.Add(this.btn_BeginStatistic);
            this.Controls.Add(this.btn_SetFloderPath);
            this.Controls.Add(this.txt_FloderPath);
            this.Controls.Add(this.label1);
            this.Name = "frmDisasterStatisticsFromExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDisasterStatisticsFromExcel";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_FloderPath;
        private System.Windows.Forms.Button btn_SetFloderPath;
        private System.Windows.Forms.Button btn_BeginStatistic;
        private System.Windows.Forms.Button btn_OutPutResult;
        private System.Windows.Forms.DataGridView dataGridView1;

    }
}