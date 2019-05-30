namespace TimeTableAutoCompleteTool
{
    partial class TrainEarlyCaculator
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
            this.CurrentTrainNumber_lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NextTrain_btn = new System.Windows.Forms.Button();
            this.PreviousTrain_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ShouldArriveTime_lbl = new System.Windows.Forms.Label();
            this.ShouldStartTime_lbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ActuallyArriveTime_tb = new System.Windows.Forms.TextBox();
            this.ActuallyStartTime_tb = new System.Windows.Forms.TextBox();
            this.Caculate_btn = new System.Windows.Forms.Button();
            this.trainsInformation_lv = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            this.earlyTimeCount_lbl = new System.Windows.Forms.Label();
            this.copy_btn = new System.Windows.Forms.Button();
            this.ArriveMinus_btn = new System.Windows.Forms.Button();
            this.ArrivePlus_btn = new System.Windows.Forms.Button();
            this.StartMinus_btn = new System.Windows.Forms.Button();
            this.StartPlus_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CurrentTrainNumber_lbl
            // 
            this.CurrentTrainNumber_lbl.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CurrentTrainNumber_lbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.CurrentTrainNumber_lbl.Location = new System.Drawing.Point(142, 25);
            this.CurrentTrainNumber_lbl.Name = "CurrentTrainNumber_lbl";
            this.CurrentTrainNumber_lbl.Size = new System.Drawing.Size(94, 31);
            this.CurrentTrainNumber_lbl.TabIndex = 0;
            this.CurrentTrainNumber_lbl.Text = "----";
            this.CurrentTrainNumber_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(157, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "当前车次";
            // 
            // NextTrain_btn
            // 
            this.NextTrain_btn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NextTrain_btn.Location = new System.Drawing.Point(264, 91);
            this.NextTrain_btn.Name = "NextTrain_btn";
            this.NextTrain_btn.Size = new System.Drawing.Size(75, 29);
            this.NextTrain_btn.TabIndex = 2;
            this.NextTrain_btn.Text = "跳过当前";
            this.NextTrain_btn.UseVisualStyleBackColor = true;
            // 
            // PreviousTrain_btn
            // 
            this.PreviousTrain_btn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PreviousTrain_btn.Location = new System.Drawing.Point(43, 91);
            this.PreviousTrain_btn.Name = "PreviousTrain_btn";
            this.PreviousTrain_btn.Size = new System.Drawing.Size(75, 29);
            this.PreviousTrain_btn.TabIndex = 3;
            this.PreviousTrain_btn.Text = "上一个";
            this.PreviousTrain_btn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(34, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "图定到达时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(254, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "图定发车时间";
            // 
            // ShouldArriveTime_lbl
            // 
            this.ShouldArriveTime_lbl.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShouldArriveTime_lbl.ForeColor = System.Drawing.Color.Crimson;
            this.ShouldArriveTime_lbl.Location = new System.Drawing.Point(37, 162);
            this.ShouldArriveTime_lbl.Name = "ShouldArriveTime_lbl";
            this.ShouldArriveTime_lbl.Size = new System.Drawing.Size(90, 40);
            this.ShouldArriveTime_lbl.TabIndex = 6;
            this.ShouldArriveTime_lbl.Text = "9:29";
            this.ShouldArriveTime_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShouldStartTime_lbl
            // 
            this.ShouldStartTime_lbl.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShouldStartTime_lbl.ForeColor = System.Drawing.Color.Crimson;
            this.ShouldStartTime_lbl.Location = new System.Drawing.Point(258, 162);
            this.ShouldStartTime_lbl.Name = "ShouldStartTime_lbl";
            this.ShouldStartTime_lbl.Size = new System.Drawing.Size(89, 40);
            this.ShouldStartTime_lbl.TabIndex = 7;
            this.ShouldStartTime_lbl.Text = "9:32";
            this.ShouldStartTime_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(35, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "实际到达时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(256, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "实际发车时间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(81, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(237, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "输入时间无需冒号分割（例：0808）";
            // 
            // ActuallyArriveTime_tb
            // 
            this.ActuallyArriveTime_tb.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ActuallyArriveTime_tb.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ActuallyArriveTime_tb.Location = new System.Drawing.Point(44, 213);
            this.ActuallyArriveTime_tb.Name = "ActuallyArriveTime_tb";
            this.ActuallyArriveTime_tb.Size = new System.Drawing.Size(74, 35);
            this.ActuallyArriveTime_tb.TabIndex = 11;
            this.ActuallyArriveTime_tb.Text = "0000";
            this.ActuallyArriveTime_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ActuallyArriveTime_tb.Click += new System.EventHandler(this.ActuallyArriveTime_tb_Click);
            this.ActuallyArriveTime_tb.TextChanged += new System.EventHandler(this.ActuallyArriveTime_tb_TextChanged);
            this.ActuallyArriveTime_tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActuallyArriveTime_tb_KeyDown);
            this.ActuallyArriveTime_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ActuallyArriveTime_tb_KeyPress);
            // 
            // ActuallyStartTime_tb
            // 
            this.ActuallyStartTime_tb.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ActuallyStartTime_tb.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ActuallyStartTime_tb.Location = new System.Drawing.Point(263, 213);
            this.ActuallyStartTime_tb.Name = "ActuallyStartTime_tb";
            this.ActuallyStartTime_tb.Size = new System.Drawing.Size(75, 35);
            this.ActuallyStartTime_tb.TabIndex = 12;
            this.ActuallyStartTime_tb.Text = "0000";
            this.ActuallyStartTime_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ActuallyStartTime_tb.Click += new System.EventHandler(this.ActuallyStartTime_tb_Click);
            this.ActuallyStartTime_tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActuallyStartTime_tb_KeyDown);
            this.ActuallyStartTime_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ActuallyStartTime_tb_KeyPress);
            // 
            // Caculate_btn
            // 
            this.Caculate_btn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Caculate_btn.Location = new System.Drawing.Point(38, 318);
            this.Caculate_btn.Name = "Caculate_btn";
            this.Caculate_btn.Size = new System.Drawing.Size(309, 42);
            this.Caculate_btn.TabIndex = 13;
            this.Caculate_btn.Text = "计算";
            this.Caculate_btn.UseVisualStyleBackColor = true;
            // 
            // trainsInformation_lv
            // 
            this.trainsInformation_lv.FullRowSelect = true;
            this.trainsInformation_lv.Location = new System.Drawing.Point(377, 91);
            this.trainsInformation_lv.MultiSelect = false;
            this.trainsInformation_lv.Name = "trainsInformation_lv";
            this.trainsInformation_lv.Size = new System.Drawing.Size(360, 269);
            this.trainsInformation_lv.TabIndex = 14;
            this.trainsInformation_lv.UseCompatibleStateImageBehavior = false;
            this.trainsInformation_lv.SelectedIndexChanged += new System.EventHandler(this.trainsInformation_lv_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(508, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "总赶点时间";
            // 
            // earlyTimeCount_lbl
            // 
            this.earlyTimeCount_lbl.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.earlyTimeCount_lbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.earlyTimeCount_lbl.Location = new System.Drawing.Point(467, 25);
            this.earlyTimeCount_lbl.Name = "earlyTimeCount_lbl";
            this.earlyTimeCount_lbl.Size = new System.Drawing.Size(160, 31);
            this.earlyTimeCount_lbl.TabIndex = 16;
            this.earlyTimeCount_lbl.Text = "0分钟";
            this.earlyTimeCount_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // copy_btn
            // 
            this.copy_btn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.copy_btn.Location = new System.Drawing.Point(662, 47);
            this.copy_btn.Name = "copy_btn";
            this.copy_btn.Size = new System.Drawing.Size(75, 29);
            this.copy_btn.TabIndex = 17;
            this.copy_btn.Text = "复制";
            this.copy_btn.UseVisualStyleBackColor = true;
            // 
            // ArriveMinus_btn
            // 
            this.ArriveMinus_btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ArriveMinus_btn.Location = new System.Drawing.Point(12, 216);
            this.ArriveMinus_btn.Name = "ArriveMinus_btn";
            this.ArriveMinus_btn.Size = new System.Drawing.Size(32, 29);
            this.ArriveMinus_btn.TabIndex = 18;
            this.ArriveMinus_btn.Text = "-";
            this.ArriveMinus_btn.UseVisualStyleBackColor = true;
            // 
            // ArrivePlus_btn
            // 
            this.ArrivePlus_btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ArrivePlus_btn.Location = new System.Drawing.Point(118, 216);
            this.ArrivePlus_btn.Name = "ArrivePlus_btn";
            this.ArrivePlus_btn.Size = new System.Drawing.Size(32, 29);
            this.ArrivePlus_btn.TabIndex = 19;
            this.ArrivePlus_btn.Text = "+";
            this.ArrivePlus_btn.UseVisualStyleBackColor = true;
            // 
            // StartMinus_btn
            // 
            this.StartMinus_btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartMinus_btn.Location = new System.Drawing.Point(231, 216);
            this.StartMinus_btn.Name = "StartMinus_btn";
            this.StartMinus_btn.Size = new System.Drawing.Size(32, 29);
            this.StartMinus_btn.TabIndex = 20;
            this.StartMinus_btn.Text = "-";
            this.StartMinus_btn.UseVisualStyleBackColor = true;
            // 
            // StartPlus_btn
            // 
            this.StartPlus_btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartPlus_btn.Location = new System.Drawing.Point(338, 216);
            this.StartPlus_btn.Name = "StartPlus_btn";
            this.StartPlus_btn.Size = new System.Drawing.Size(32, 29);
            this.StartPlus_btn.TabIndex = 21;
            this.StartPlus_btn.Text = "+";
            this.StartPlus_btn.UseVisualStyleBackColor = true;
            // 
            // TrainEarlyCaculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 398);
            this.Controls.Add(this.StartPlus_btn);
            this.Controls.Add(this.StartMinus_btn);
            this.Controls.Add(this.ArrivePlus_btn);
            this.Controls.Add(this.ArriveMinus_btn);
            this.Controls.Add(this.copy_btn);
            this.Controls.Add(this.earlyTimeCount_lbl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.trainsInformation_lv);
            this.Controls.Add(this.Caculate_btn);
            this.Controls.Add(this.ActuallyStartTime_tb);
            this.Controls.Add(this.ActuallyArriveTime_tb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ShouldStartTime_lbl);
            this.Controls.Add(this.ShouldArriveTime_lbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PreviousTrain_btn);
            this.Controls.Add(this.NextTrain_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CurrentTrainNumber_lbl);
            this.Name = "TrainEarlyCaculator";
            this.Text = "TrainEarlyCaculator";
            this.Load += new System.EventHandler(this.TrainEarlyCaculator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CurrentTrainNumber_lbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button NextTrain_btn;
        private System.Windows.Forms.Button PreviousTrain_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ShouldArriveTime_lbl;
        private System.Windows.Forms.Label ShouldStartTime_lbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ActuallyArriveTime_tb;
        private System.Windows.Forms.TextBox ActuallyStartTime_tb;
        private System.Windows.Forms.Button Caculate_btn;
        private System.Windows.Forms.ListView trainsInformation_lv;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label earlyTimeCount_lbl;
        private System.Windows.Forms.Button copy_btn;
        private System.Windows.Forms.Button ArriveMinus_btn;
        private System.Windows.Forms.Button ArrivePlus_btn;
        private System.Windows.Forms.Button StartMinus_btn;
        private System.Windows.Forms.Button StartPlus_btn;
    }
}