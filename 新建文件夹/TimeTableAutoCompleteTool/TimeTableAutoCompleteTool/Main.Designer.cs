namespace TimeTableAutoCompleteTool
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondStepText_lbl = new System.Windows.Forms.Label();
            this.filePathLBL = new System.Windows.Forms.Label();
            this.filePath_lbl = new System.Windows.Forms.Label();
            this.outputTB = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.hint_label = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.developerLabel = new System.Windows.Forms.Label();
            this.secondListTitle_lbl = new System.Windows.Forms.Label();
            this.searchResult_tb = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.buildLBL = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.commandFile_lbl = new System.Windows.Forms.Label();
            this.importCommand_btn = new CCWin.SkinControl.SkinButton();
            this.label1 = new System.Windows.Forms.Label();
            this.command_rTb = new System.Windows.Forms.RichTextBox();
            this.FontSize_tb = new CCWin.SkinControl.SkinWaterTextBox();
            this.label222 = new CCWin.SkinControl.SkinLabel();
            this.label111 = new CCWin.SkinControl.SkinLabel();
            this.importTimeTable_Btn = new CCWin.SkinControl.SkinButton();
            this.start_Btn = new CCWin.SkinControl.SkinButton();
            this.rightGroupBox = new System.Windows.Forms.GroupBox();
            this.dataAnalyse_btn = new CCWin.SkinControl.SkinButton();
            this.search_tb = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.AllTrainsInTimeTableLBL = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.stoppedTrainsCountLBL = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.AllPsngerTrainsCountLBL = new System.Windows.Forms.Label();
            this.AllTrainsCountLBL = new System.Windows.Forms.Label();
            this.contentOfDeveloper = new System.Windows.Forms.ToolTip(this.components);
            this.updateReadMe = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.rightGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制toolStripMenuItem1,
            this.粘贴ToolStripMenuItem,
            this.清空ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 112);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 复制toolStripMenuItem1
            // 
            this.复制toolStripMenuItem1.Name = "复制toolStripMenuItem1";
            this.复制toolStripMenuItem1.Size = new System.Drawing.Size(136, 36);
            this.复制toolStripMenuItem1.Text = "复制";
            this.复制toolStripMenuItem1.Click += new System.EventHandler(this.复制toolStripMenuItem1_Click);
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(136, 36);
            this.粘贴ToolStripMenuItem.Text = "粘贴";
            this.粘贴ToolStripMenuItem.Click += new System.EventHandler(this.粘贴ToolStripMenuItem_Click);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(136, 36);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // secondStepText_lbl
            // 
            this.secondStepText_lbl.AutoSize = true;
            this.secondStepText_lbl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.secondStepText_lbl.Location = new System.Drawing.Point(14, 709);
            this.secondStepText_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.secondStepText_lbl.Name = "secondStepText_lbl";
            this.secondStepText_lbl.Size = new System.Drawing.Size(269, 41);
            this.secondStepText_lbl.TabIndex = 2;
            this.secondStepText_lbl.Text = "2.选择时刻表文件";
            // 
            // filePathLBL
            // 
            this.filePathLBL.AutoSize = true;
            this.filePathLBL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.filePathLBL.Location = new System.Drawing.Point(15, 798);
            this.filePathLBL.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.filePathLBL.Name = "filePathLBL";
            this.filePathLBL.Size = new System.Drawing.Size(110, 31);
            this.filePathLBL.TabIndex = 4;
            this.filePathLBL.Text = "已选择：";
            // 
            // filePath_lbl
            // 
            this.filePath_lbl.AutoSize = true;
            this.filePath_lbl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.filePath_lbl.Location = new System.Drawing.Point(224, 808);
            this.filePath_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.filePath_lbl.Name = "filePath_lbl";
            this.filePath_lbl.Size = new System.Drawing.Size(0, 31);
            this.filePath_lbl.TabIndex = 5;
            // 
            // outputTB
            // 
            this.outputTB.Location = new System.Drawing.Point(36, 64);
            this.outputTB.Margin = new System.Windows.Forms.Padding(6);
            this.outputTB.Name = "outputTB";
            this.outputTB.ReadOnly = true;
            this.outputTB.Size = new System.Drawing.Size(416, 603);
            this.outputTB.TabIndex = 9;
            this.outputTB.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(336, 750);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 31);
            this.label6.TabIndex = 8;
            // 
            // hint_label
            // 
            this.hint_label.AutoSize = true;
            this.hint_label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hint_label.ForeColor = System.Drawing.SystemColors.Highlight;
            this.hint_label.Location = new System.Drawing.Point(56, 1064);
            this.hint_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.hint_label.Name = "hint_label";
            this.hint_label.Size = new System.Drawing.Size(1138, 31);
            this.hint_label.TabIndex = 10;
            this.hint_label.Text = "绿色为开行，红色为停开，白色为调令未含车次，黄色为次日接入车次。高峰/临客/周末在车次前含有标注";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(32, 4);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(338, 41);
            this.label8.TabIndex = 11;
            this.label8.Text = "日计划中提取出的车次";
            // 
            // developerLabel
            // 
            this.developerLabel.AutoSize = true;
            this.developerLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.developerLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.developerLabel.Location = new System.Drawing.Point(1208, 1064);
            this.developerLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.developerLabel.Name = "developerLabel";
            this.developerLabel.Size = new System.Drawing.Size(456, 31);
            this.developerLabel.TabIndex = 12;
            this.developerLabel.Text = "反馈请联系运转车间-罗思聪（或技术科）";
            // 
            // secondListTitle_lbl
            // 
            this.secondListTitle_lbl.AutoSize = true;
            this.secondListTitle_lbl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.secondListTitle_lbl.Location = new System.Drawing.Point(464, 4);
            this.secondListTitle_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.secondListTitle_lbl.Name = "secondListTitle_lbl";
            this.secondListTitle_lbl.Size = new System.Drawing.Size(146, 41);
            this.secondListTitle_lbl.TabIndex = 13;
            this.secondListTitle_lbl.Text = "搜索车次";
            // 
            // searchResult_tb
            // 
            this.searchResult_tb.Location = new System.Drawing.Point(464, 64);
            this.searchResult_tb.Margin = new System.Windows.Forms.Padding(6);
            this.searchResult_tb.Name = "searchResult_tb";
            this.searchResult_tb.ReadOnly = true;
            this.searchResult_tb.Size = new System.Drawing.Size(416, 603);
            this.searchResult_tb.TabIndex = 14;
            this.searchResult_tb.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(1552, 1034);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 31);
            this.label11.TabIndex = 15;
            // 
            // buildLBL
            // 
            this.buildLBL.AutoSize = true;
            this.buildLBL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buildLBL.ForeColor = System.Drawing.Color.Tomato;
            this.buildLBL.Location = new System.Drawing.Point(1738, 1064);
            this.buildLBL.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.buildLBL.Name = "buildLBL";
            this.buildLBL.Size = new System.Drawing.Size(110, 31);
            this.buildLBL.TabIndex = 16;
            this.buildLBL.Text = "修订内容";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.commandFile_lbl);
            this.groupBox1.Controls.Add(this.importCommand_btn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.command_rTb);
            this.groupBox1.Controls.Add(this.FontSize_tb);
            this.groupBox1.Controls.Add(this.label222);
            this.groupBox1.Controls.Add(this.label111);
            this.groupBox1.Controls.Add(this.importTimeTable_Btn);
            this.groupBox1.Controls.Add(this.filePathLBL);
            this.groupBox1.Controls.Add(this.secondStepText_lbl);
            this.groupBox1.Controls.Add(this.start_Btn);
            this.groupBox1.Location = new System.Drawing.Point(96, 98);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(966, 967);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(12, 4);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(306, 41);
            this.label5.TabIndex = 28;
            this.label5.Text = "【日计划文件内容】";
            // 
            // commandFile_lbl
            // 
            this.commandFile_lbl.AutoSize = true;
            this.commandFile_lbl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.commandFile_lbl.Location = new System.Drawing.Point(18, 624);
            this.commandFile_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.commandFile_lbl.Name = "commandFile_lbl";
            this.commandFile_lbl.Size = new System.Drawing.Size(110, 31);
            this.commandFile_lbl.TabIndex = 33;
            this.commandFile_lbl.Text = "已选择：";
            // 
            // importCommand_btn
            // 
            this.importCommand_btn.BackColor = System.Drawing.Color.Transparent;
            this.importCommand_btn.BaseColor = System.Drawing.Color.OrangeRed;
            this.importCommand_btn.BorderColor = System.Drawing.Color.OrangeRed;
            this.importCommand_btn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.importCommand_btn.DownBack = null;
            this.importCommand_btn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.importCommand_btn.ForeColor = System.Drawing.Color.White;
            this.importCommand_btn.Location = new System.Drawing.Point(753, 514);
            this.importCommand_btn.Margin = new System.Windows.Forms.Padding(6);
            this.importCommand_btn.MouseBack = null;
            this.importCommand_btn.Name = "importCommand_btn";
            this.importCommand_btn.NormlBack = null;
            this.importCommand_btn.Size = new System.Drawing.Size(190, 82);
            this.importCommand_btn.TabIndex = 32;
            this.importCommand_btn.Text = "导入";
            this.importCommand_btn.UseVisualStyleBackColor = false;
            this.importCommand_btn.Click += new System.EventHandler(this.importCommand_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(14, 532);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 41);
            this.label1.TabIndex = 31;
            this.label1.Text = "1.选择日计划命令文件";
            // 
            // command_rTb
            // 
            this.command_rTb.ContextMenuStrip = this.contextMenuStrip1;
            this.command_rTb.Location = new System.Drawing.Point(17, 64);
            this.command_rTb.Margin = new System.Windows.Forms.Padding(6);
            this.command_rTb.Name = "command_rTb";
            this.command_rTb.Size = new System.Drawing.Size(926, 422);
            this.command_rTb.TabIndex = 1;
            this.command_rTb.Text = "";
            this.command_rTb.TextChanged += new System.EventHandler(this.command_rTb_TextChanged);
            // 
            // FontSize_tb
            // 
            this.FontSize_tb.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FontSize_tb.Location = new System.Drawing.Point(825, 794);
            this.FontSize_tb.Margin = new System.Windows.Forms.Padding(6);
            this.FontSize_tb.Name = "FontSize_tb";
            this.FontSize_tb.Size = new System.Drawing.Size(46, 50);
            this.FontSize_tb.TabIndex = 30;
            this.FontSize_tb.Text = "12";
            this.FontSize_tb.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.FontSize_tb.WaterText = "";
            this.FontSize_tb.TextChanged += new System.EventHandler(this.FontSize_tb_TextChanged);
            // 
            // label222
            // 
            this.label222.AutoSize = true;
            this.label222.BackColor = System.Drawing.Color.Transparent;
            this.label222.BorderColor = System.Drawing.Color.White;
            this.label222.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label222.Location = new System.Drawing.Point(555, 824);
            this.label222.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label222.Name = "label222";
            this.label222.Size = new System.Drawing.Size(278, 31);
            this.label222.TabIndex = 29;
            this.label222.Text = "（字体大小有误请修改）";
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.BackColor = System.Drawing.Color.Transparent;
            this.label111.BorderColor = System.Drawing.Color.White;
            this.label111.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label111.Location = new System.Drawing.Point(581, 790);
            this.label111.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(230, 31);
            this.label111.TabIndex = 1;
            this.label111.Text = "时刻表车次字体大小";
            // 
            // importTimeTable_Btn
            // 
            this.importTimeTable_Btn.BackColor = System.Drawing.Color.Transparent;
            this.importTimeTable_Btn.BaseColor = System.Drawing.Color.DodgerBlue;
            this.importTimeTable_Btn.BorderColor = System.Drawing.Color.DodgerBlue;
            this.importTimeTable_Btn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.importTimeTable_Btn.DownBack = null;
            this.importTimeTable_Btn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.importTimeTable_Btn.ForeColor = System.Drawing.Color.White;
            this.importTimeTable_Btn.Location = new System.Drawing.Point(753, 700);
            this.importTimeTable_Btn.Margin = new System.Windows.Forms.Padding(6);
            this.importTimeTable_Btn.MouseBack = null;
            this.importTimeTable_Btn.Name = "importTimeTable_Btn";
            this.importTimeTable_Btn.NormlBack = null;
            this.importTimeTable_Btn.Size = new System.Drawing.Size(190, 82);
            this.importTimeTable_Btn.TabIndex = 7;
            this.importTimeTable_Btn.Text = "导入";
            this.importTimeTable_Btn.UseVisualStyleBackColor = false;
            this.importTimeTable_Btn.Click += new System.EventHandler(this.importTimeTable_Btn_Click);
            // 
            // start_Btn
            // 
            this.start_Btn.BackColor = System.Drawing.Color.Transparent;
            this.start_Btn.BaseColor = System.Drawing.Color.DodgerBlue;
            this.start_Btn.BorderColor = System.Drawing.Color.DodgerBlue;
            this.start_Btn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.start_Btn.DownBack = null;
            this.start_Btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.start_Btn.ForeColor = System.Drawing.Color.White;
            this.start_Btn.Location = new System.Drawing.Point(13, 868);
            this.start_Btn.Margin = new System.Windows.Forms.Padding(6);
            this.start_Btn.MouseBack = null;
            this.start_Btn.Name = "start_Btn";
            this.start_Btn.NormlBack = null;
            this.start_Btn.Size = new System.Drawing.Size(930, 86);
            this.start_Btn.TabIndex = 8;
            this.start_Btn.Text = "生成时刻表/班计划";
            this.start_Btn.UseVisualStyleBackColor = false;
            this.start_Btn.Click += new System.EventHandler(this.start_Btn_Click);
            // 
            // rightGroupBox
            // 
            this.rightGroupBox.Controls.Add(this.dataAnalyse_btn);
            this.rightGroupBox.Controls.Add(this.search_tb);
            this.rightGroupBox.Controls.Add(this.groupBox3);
            this.rightGroupBox.Controls.Add(this.outputTB);
            this.rightGroupBox.Controls.Add(this.searchResult_tb);
            this.rightGroupBox.Controls.Add(this.label8);
            this.rightGroupBox.Controls.Add(this.secondListTitle_lbl);
            this.rightGroupBox.Location = new System.Drawing.Point(1074, 98);
            this.rightGroupBox.Margin = new System.Windows.Forms.Padding(6);
            this.rightGroupBox.Name = "rightGroupBox";
            this.rightGroupBox.Padding = new System.Windows.Forms.Padding(6);
            this.rightGroupBox.Size = new System.Drawing.Size(928, 967);
            this.rightGroupBox.TabIndex = 20;
            this.rightGroupBox.TabStop = false;
            // 
            // dataAnalyse_btn
            // 
            this.dataAnalyse_btn.BackColor = System.Drawing.Color.Transparent;
            this.dataAnalyse_btn.BaseColor = System.Drawing.Color.DeepPink;
            this.dataAnalyse_btn.BorderColor = System.Drawing.Color.DeepPink;
            this.dataAnalyse_btn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.dataAnalyse_btn.DownBack = null;
            this.dataAnalyse_btn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataAnalyse_btn.ForeColor = System.Drawing.Color.White;
            this.dataAnalyse_btn.Location = new System.Drawing.Point(32, 869);
            this.dataAnalyse_btn.Margin = new System.Windows.Forms.Padding(6);
            this.dataAnalyse_btn.MouseBack = null;
            this.dataAnalyse_btn.Name = "dataAnalyse_btn";
            this.dataAnalyse_btn.NormlBack = null;
            this.dataAnalyse_btn.Size = new System.Drawing.Size(852, 86);
            this.dataAnalyse_btn.TabIndex = 34;
            this.dataAnalyse_btn.Text = "统计数据";
            this.dataAnalyse_btn.UseVisualStyleBackColor = false;
            this.dataAnalyse_btn.Click += new System.EventHandler(this.dataAnalyse_btn_Click);
            // 
            // search_tb
            // 
            this.search_tb.Location = new System.Drawing.Point(622, 4);
            this.search_tb.Margin = new System.Windows.Forms.Padding(6);
            this.search_tb.Name = "search_tb";
            this.search_tb.Size = new System.Drawing.Size(262, 35);
            this.search_tb.TabIndex = 27;
            this.search_tb.TextChanged += new System.EventHandler(this.search_tb_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AllTrainsInTimeTableLBL);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.stoppedTrainsCountLBL);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.AllPsngerTrainsCountLBL);
            this.groupBox3.Controls.Add(this.AllTrainsCountLBL);
            this.groupBox3.Location = new System.Drawing.Point(32, 656);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(852, 199);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            // 
            // AllTrainsInTimeTableLBL
            // 
            this.AllTrainsInTimeTableLBL.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AllTrainsInTimeTableLBL.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.AllTrainsInTimeTableLBL.Location = new System.Drawing.Point(284, 36);
            this.AllTrainsInTimeTableLBL.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.AllTrainsInTimeTableLBL.Name = "AllTrainsInTimeTableLBL";
            this.AllTrainsInTimeTableLBL.Size = new System.Drawing.Size(146, 62);
            this.AllTrainsInTimeTableLBL.TabIndex = 28;
            this.AllTrainsInTimeTableLBL.Text = "0";
            this.AllTrainsInTimeTableLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(82, 50);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(182, 31);
            this.label14.TabIndex = 27;
            this.label14.Text = "时刻表内车次数";
            // 
            // stoppedTrainsCountLBL
            // 
            this.stoppedTrainsCountLBL.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stoppedTrainsCountLBL.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.stoppedTrainsCountLBL.Location = new System.Drawing.Point(694, 113);
            this.stoppedTrainsCountLBL.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.stoppedTrainsCountLBL.Name = "stoppedTrainsCountLBL";
            this.stoppedTrainsCountLBL.Size = new System.Drawing.Size(146, 68);
            this.stoppedTrainsCountLBL.TabIndex = 26;
            this.stoppedTrainsCountLBL.Text = "0";
            this.stoppedTrainsCountLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(476, 148);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(224, 31);
            this.label13.TabIndex = 25;
            this.label13.Text = "标注停运+客调未含";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(522, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 31);
            this.label3.TabIndex = 24;
            this.label3.Text = "停开车次数";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(82, 116);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(182, 31);
            this.label15.TabIndex = 21;
            this.label15.Text = "匹配旅客列车数";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(76, 150);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(198, 31);
            this.label16.TabIndex = 23;
            this.label16.Text = "(去除0G,0J,DJ等)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(522, 50);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 31);
            this.label12.TabIndex = 17;
            this.label12.Text = "匹配车次数";
            // 
            // AllPsngerTrainsCountLBL
            // 
            this.AllPsngerTrainsCountLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AllPsngerTrainsCountLBL.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AllPsngerTrainsCountLBL.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.AllPsngerTrainsCountLBL.Location = new System.Drawing.Point(280, 107);
            this.AllPsngerTrainsCountLBL.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.AllPsngerTrainsCountLBL.Name = "AllPsngerTrainsCountLBL";
            this.AllPsngerTrainsCountLBL.Size = new System.Drawing.Size(150, 81);
            this.AllPsngerTrainsCountLBL.TabIndex = 22;
            this.AllPsngerTrainsCountLBL.Text = "0";
            this.AllPsngerTrainsCountLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AllTrainsCountLBL
            // 
            this.AllTrainsCountLBL.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AllTrainsCountLBL.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.AllTrainsCountLBL.Location = new System.Drawing.Point(690, 36);
            this.AllTrainsCountLBL.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.AllTrainsCountLBL.Name = "AllTrainsCountLBL";
            this.AllTrainsCountLBL.Size = new System.Drawing.Size(150, 62);
            this.AllTrainsCountLBL.TabIndex = 18;
            this.AllTrainsCountLBL.Text = "0";
            this.AllTrainsCountLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Tomato;
            this.label2.Location = new System.Drawing.Point(1620, 1098);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 31);
            this.label2.TabIndex = 27;
            this.label2.Text = "鼠标移动至版本号查看更新内容";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CaptionBackColorBottom = System.Drawing.Color.White;
            this.CaptionBackColorTop = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2094, 1170);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buildLBL);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.developerLabel);
            this.Controls.Add(this.hint_label);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.filePath_lbl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rightGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.rightGroupBox.ResumeLayout(false);
            this.rightGroupBox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label secondStepText_lbl;
        private System.Windows.Forms.Label filePathLBL;
        private System.Windows.Forms.Label filePath_lbl;
        private System.Windows.Forms.RichTextBox outputTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label hint_label;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label developerLabel;
        private System.Windows.Forms.Label secondListTitle_lbl;
        private System.Windows.Forms.RichTextBox searchResult_tb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label buildLBL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox rightGroupBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label AllTrainsCountLBL;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label AllPsngerTrainsCountLBL;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label stoppedTrainsCountLBL;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label AllTrainsInTimeTableLBL;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.TextBox search_tb;
        private System.Windows.Forms.ToolTip contentOfDeveloper;
        private System.Windows.Forms.ToolTip updateReadMe;
        private System.Windows.Forms.Label label2;
        private CCWin.SkinControl.SkinButton importTimeTable_Btn;
        private CCWin.SkinControl.SkinButton start_Btn;
        private CCWin.SkinControl.SkinLabel label222;
        private CCWin.SkinControl.SkinLabel label111;
        private System.Windows.Forms.RichTextBox command_rTb;
        private CCWin.SkinControl.SkinWaterTextBox FontSize_tb;
        private System.Windows.Forms.ToolStripMenuItem 复制toolStripMenuItem1;
        private System.Windows.Forms.Label commandFile_lbl;
        private CCWin.SkinControl.SkinButton importCommand_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private CCWin.SkinControl.SkinButton dataAnalyse_btn;
    }
}

