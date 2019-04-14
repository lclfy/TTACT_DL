namespace DisplaySystem
{
    partial class ModifyTrackLine
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
            this.TrackLine_lv = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.describe = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.leftX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rightX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lPoint = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rPoint = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.leftX_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.leftY_tb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rightY_tb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rightX_tb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lPoint_tb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rPoint_tb = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.Point_lv = new System.Windows.Forms.ListView();
            this.pointID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.L1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.R1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.R2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.describe_tb = new System.Windows.Forms.TextBox();
            this.leftPlus_btn = new System.Windows.Forms.Button();
            this.leftMinus_btn = new System.Windows.Forms.Button();
            this.rightMinus_btn = new System.Windows.Forms.Button();
            this.rightPlus_btn = new System.Windows.Forms.Button();
            this.leftWayTo_tb = new System.Windows.Forms.TextBox();
            this.rightWayTo_tb = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TrackLine_lv
            // 
            this.TrackLine_lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.describe,
            this.leftX,
            this.rightX,
            this.lPoint,
            this.rPoint});
            this.TrackLine_lv.FullRowSelect = true;
            this.TrackLine_lv.Location = new System.Drawing.Point(24, 65);
            this.TrackLine_lv.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.TrackLine_lv.MultiSelect = false;
            this.TrackLine_lv.Name = "TrackLine_lv";
            this.TrackLine_lv.Size = new System.Drawing.Size(904, 773);
            this.TrackLine_lv.TabIndex = 0;
            this.TrackLine_lv.UseCompatibleStateImageBehavior = false;
            this.TrackLine_lv.View = System.Windows.Forms.View.Details;
            this.TrackLine_lv.SelectedIndexChanged += new System.EventHandler(this.TrackLine_lv_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 40;
            // 
            // describe
            // 
            this.describe.Text = "描述";
            this.describe.Width = 100;
            // 
            // leftX
            // 
            this.leftX.Text = "左坐标";
            this.leftX.Width = 100;
            // 
            // rightX
            // 
            this.rightX.Text = "右坐标";
            this.rightX.Width = 100;
            // 
            // lPoint
            // 
            this.lPoint.Text = "左节点";
            // 
            // rPoint
            // 
            this.rPoint.Text = "右节点";
            // 
            // id_tb
            // 
            this.id_tb.Location = new System.Drawing.Point(1484, 89);
            this.id_tb.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.id_tb.Name = "id_tb";
            this.id_tb.Size = new System.Drawing.Size(196, 37);
            this.id_tb.TabIndex = 1;
            this.id_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.id_tb_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1438, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1438, 297);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "X";
            // 
            // leftX_tb
            // 
            this.leftX_tb.Location = new System.Drawing.Point(1484, 290);
            this.leftX_tb.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.leftX_tb.Name = "leftX_tb";
            this.leftX_tb.Size = new System.Drawing.Size(104, 37);
            this.leftX_tb.TabIndex = 3;
            this.leftX_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.leftX_tb_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1438, 234);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "左坐标";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1438, 363);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Y";
            // 
            // leftY_tb
            // 
            this.leftY_tb.Location = new System.Drawing.Point(1484, 355);
            this.leftY_tb.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.leftY_tb.Name = "leftY_tb";
            this.leftY_tb.Size = new System.Drawing.Size(104, 37);
            this.leftY_tb.TabIndex = 6;
            this.leftY_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.leftY_tb_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1438, 553);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 29);
            this.label5.TabIndex = 12;
            this.label5.Text = "Y";
            // 
            // rightY_tb
            // 
            this.rightY_tb.Location = new System.Drawing.Point(1484, 546);
            this.rightY_tb.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.rightY_tb.Name = "rightY_tb";
            this.rightY_tb.Size = new System.Drawing.Size(104, 37);
            this.rightY_tb.TabIndex = 11;
            this.rightY_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rightY_tb_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1438, 425);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 29);
            this.label6.TabIndex = 10;
            this.label6.Text = "右坐标";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1438, 488);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 29);
            this.label7.TabIndex = 9;
            this.label7.Text = "X";
            // 
            // rightX_tb
            // 
            this.rightX_tb.Location = new System.Drawing.Point(1484, 481);
            this.rightX_tb.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.rightX_tb.Name = "rightX_tb";
            this.rightX_tb.Size = new System.Drawing.Size(104, 37);
            this.rightX_tb.TabIndex = 8;
            this.rightX_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rightX_tb_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1402, 643);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 29);
            this.label8.TabIndex = 14;
            this.label8.Text = "左节点";
            // 
            // lPoint_tb
            // 
            this.lPoint_tb.Location = new System.Drawing.Point(1484, 636);
            this.lPoint_tb.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.lPoint_tb.Name = "lPoint_tb";
            this.lPoint_tb.ReadOnly = true;
            this.lPoint_tb.Size = new System.Drawing.Size(166, 37);
            this.lPoint_tb.TabIndex = 13;
            this.lPoint_tb.TextChanged += new System.EventHandler(this.lPoint_tb_TextChanged);
            this.lPoint_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lPoint_tb_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1402, 708);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 29);
            this.label9.TabIndex = 16;
            this.label9.Text = "右节点";
            // 
            // rPoint_tb
            // 
            this.rPoint_tb.Location = new System.Drawing.Point(1484, 701);
            this.rPoint_tb.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.rPoint_tb.Name = "rPoint_tb";
            this.rPoint_tb.ReadOnly = true;
            this.rPoint_tb.Size = new System.Drawing.Size(166, 37);
            this.rPoint_tb.TabIndex = 15;
            this.rPoint_tb.TextChanged += new System.EventHandler(this.rPoint_tb_TextChanged);
            this.rPoint_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rPoint_tb_KeyPress);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(1426, 771);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(150, 56);
            this.SaveBtn.TabIndex = 17;
            this.SaveBtn.Text = "保存";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(1588, 771);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(150, 56);
            this.deleteBtn.TabIndex = 18;
            this.deleteBtn.Text = "删除";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // Point_lv
            // 
            this.Point_lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pointID,
            this.L1,
            this.R1,
            this.R2});
            this.Point_lv.FullRowSelect = true;
            this.Point_lv.Location = new System.Drawing.Point(944, 65);
            this.Point_lv.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Point_lv.MultiSelect = false;
            this.Point_lv.Name = "Point_lv";
            this.Point_lv.Size = new System.Drawing.Size(434, 773);
            this.Point_lv.TabIndex = 19;
            this.Point_lv.UseCompatibleStateImageBehavior = false;
            this.Point_lv.View = System.Windows.Forms.View.Details;
            this.Point_lv.SelectedIndexChanged += new System.EventHandler(this.Point_lv_SelectedIndexChanged);
            // 
            // pointID
            // 
            this.pointID.Text = "ID";
            this.pointID.Width = 40;
            // 
            // L1
            // 
            this.L1.Text = "左节点";
            // 
            // R1
            // 
            this.R1.Text = "右节点";
            // 
            // R2
            // 
            this.R2.Text = "反位节点";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 29);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 29);
            this.label10.TabIndex = 20;
            this.label10.Text = "列表";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(940, 29);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 29);
            this.label11.TabIndex = 21;
            this.label11.Text = "节点";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1414, 162);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 29);
            this.label12.TabIndex = 61;
            this.label12.Text = "描述";
            // 
            // describe_tb
            // 
            this.describe_tb.Location = new System.Drawing.Point(1484, 155);
            this.describe_tb.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.describe_tb.Name = "describe_tb";
            this.describe_tb.Size = new System.Drawing.Size(196, 37);
            this.describe_tb.TabIndex = 60;
            // 
            // leftPlus_btn
            // 
            this.leftPlus_btn.Location = new System.Drawing.Point(1666, 631);
            this.leftPlus_btn.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.leftPlus_btn.Name = "leftPlus_btn";
            this.leftPlus_btn.Size = new System.Drawing.Size(38, 56);
            this.leftPlus_btn.TabIndex = 62;
            this.leftPlus_btn.Text = "+";
            this.leftPlus_btn.UseVisualStyleBackColor = true;
            this.leftPlus_btn.Click += new System.EventHandler(this.leftPlus_btn_Click);
            // 
            // leftMinus_btn
            // 
            this.leftMinus_btn.Location = new System.Drawing.Point(1700, 631);
            this.leftMinus_btn.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.leftMinus_btn.Name = "leftMinus_btn";
            this.leftMinus_btn.Size = new System.Drawing.Size(38, 56);
            this.leftMinus_btn.TabIndex = 63;
            this.leftMinus_btn.Text = "-";
            this.leftMinus_btn.UseVisualStyleBackColor = true;
            this.leftMinus_btn.Click += new System.EventHandler(this.leftMinus_btn_Click);
            // 
            // rightMinus_btn
            // 
            this.rightMinus_btn.Location = new System.Drawing.Point(1700, 701);
            this.rightMinus_btn.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.rightMinus_btn.Name = "rightMinus_btn";
            this.rightMinus_btn.Size = new System.Drawing.Size(38, 56);
            this.rightMinus_btn.TabIndex = 65;
            this.rightMinus_btn.Text = "-";
            this.rightMinus_btn.UseVisualStyleBackColor = true;
            this.rightMinus_btn.Click += new System.EventHandler(this.rightMinus_btn_Click);
            // 
            // rightPlus_btn
            // 
            this.rightPlus_btn.Location = new System.Drawing.Point(1666, 701);
            this.rightPlus_btn.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.rightPlus_btn.Name = "rightPlus_btn";
            this.rightPlus_btn.Size = new System.Drawing.Size(38, 56);
            this.rightPlus_btn.TabIndex = 64;
            this.rightPlus_btn.Text = "+";
            this.rightPlus_btn.UseVisualStyleBackColor = true;
            this.rightPlus_btn.Click += new System.EventHandler(this.rightPlus_btn_Click);
            // 
            // leftWayTo_tb
            // 
            this.leftWayTo_tb.Location = new System.Drawing.Point(1443, 593);
            this.leftWayTo_tb.Name = "leftWayTo_tb";
            this.leftWayTo_tb.Size = new System.Drawing.Size(100, 37);
            this.leftWayTo_tb.TabIndex = 66;
            this.leftWayTo_tb.TextChanged += new System.EventHandler(this.leftWayTo_tb_TextChanged);
            // 
            // rightWayTo_tb
            // 
            this.rightWayTo_tb.Location = new System.Drawing.Point(1588, 593);
            this.rightWayTo_tb.Name = "rightWayTo_tb";
            this.rightWayTo_tb.Size = new System.Drawing.Size(100, 37);
            this.rightWayTo_tb.TabIndex = 67;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1409, 596);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 29);
            this.label13.TabIndex = 68;
            this.label13.Text = "左";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1554, 596);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 29);
            this.label14.TabIndex = 69;
            this.label14.Text = "右";
            // 
            // ModifyTrackLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1760, 887);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.rightWayTo_tb);
            this.Controls.Add(this.leftWayTo_tb);
            this.Controls.Add(this.rightMinus_btn);
            this.Controls.Add(this.rightPlus_btn);
            this.Controls.Add(this.leftMinus_btn);
            this.Controls.Add(this.leftPlus_btn);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.describe_tb);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Point_lv);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.rPoint_tb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lPoint_tb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rightY_tb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rightX_tb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.leftY_tb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.leftX_tb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.id_tb);
            this.Controls.Add(this.TrackLine_lv);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "ModifyTrackLine";
            this.Text = "ModifyTrackLine";
            this.Load += new System.EventHandler(this.ModifyTrackLine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView TrackLine_lv;
        private System.Windows.Forms.TextBox id_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox leftX_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox leftY_tb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox rightY_tb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox rightX_tb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox lPoint_tb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox rPoint_tb;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.ListView Point_lv;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox describe_tb;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader describe;
        private System.Windows.Forms.ColumnHeader leftX;
        private System.Windows.Forms.ColumnHeader rightX;
        private System.Windows.Forms.ColumnHeader lPoint;
        private System.Windows.Forms.ColumnHeader rPoint;
        private System.Windows.Forms.ColumnHeader pointID;
        private System.Windows.Forms.ColumnHeader L1;
        private System.Windows.Forms.ColumnHeader R1;
        private System.Windows.Forms.ColumnHeader R2;
        private System.Windows.Forms.Button leftPlus_btn;
        private System.Windows.Forms.Button leftMinus_btn;
        private System.Windows.Forms.Button rightMinus_btn;
        private System.Windows.Forms.Button rightPlus_btn;
        private System.Windows.Forms.TextBox leftWayTo_tb;
        private System.Windows.Forms.TextBox rightWayTo_tb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}