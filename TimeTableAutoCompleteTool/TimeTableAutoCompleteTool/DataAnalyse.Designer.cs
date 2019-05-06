namespace TimeTableAutoCompleteTool
{
    partial class DataAnalyse
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
            this.up_cb = new CCWin.SkinControl.SkinCheckBox();
            this.down_cb = new CCWin.SkinControl.SkinCheckBox();
            this.psngerTrain_cb = new CCWin.SkinControl.SkinCheckBox();
            this.nonPsngerTrain_cb = new CCWin.SkinControl.SkinCheckBox();
            this.checked_cb = new CCWin.SkinControl.SkinCheckBox();
            this.nonChecked_cb = new CCWin.SkinControl.SkinCheckBox();
            this.AllTrainsInCommand_lbl = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.currentShow_lbl = new System.Windows.Forms.Label();
            this.search_tb = new System.Windows.Forms.TextBox();
            this.secondListTitle_lbl = new System.Windows.Forms.Label();
            this.data_lv = new System.Windows.Forms.ListView();
            this.Match = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.trainIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.trainNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.secondTrainNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._upOrDown = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._trainType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._trainModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._trainID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // up_cb
            // 
            this.up_cb.AutoSize = true;
            this.up_cb.BackColor = System.Drawing.Color.Transparent;
            this.up_cb.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.up_cb.DownBack = null;
            this.up_cb.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.up_cb.Location = new System.Drawing.Point(72, 819);
            this.up_cb.MouseBack = null;
            this.up_cb.Name = "up_cb";
            this.up_cb.NormlBack = null;
            this.up_cb.SelectedDownBack = null;
            this.up_cb.SelectedMouseBack = null;
            this.up_cb.SelectedNormlBack = null;
            this.up_cb.Size = new System.Drawing.Size(94, 35);
            this.up_cb.TabIndex = 1;
            this.up_cb.Text = "上行";
            this.up_cb.UseVisualStyleBackColor = false;
            this.up_cb.CheckedChanged += new System.EventHandler(this.up_cb_CheckedChanged);
            // 
            // down_cb
            // 
            this.down_cb.AutoSize = true;
            this.down_cb.BackColor = System.Drawing.Color.Transparent;
            this.down_cb.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.down_cb.DownBack = null;
            this.down_cb.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.down_cb.Location = new System.Drawing.Point(237, 819);
            this.down_cb.MouseBack = null;
            this.down_cb.Name = "down_cb";
            this.down_cb.NormlBack = null;
            this.down_cb.SelectedDownBack = null;
            this.down_cb.SelectedMouseBack = null;
            this.down_cb.SelectedNormlBack = null;
            this.down_cb.Size = new System.Drawing.Size(94, 35);
            this.down_cb.TabIndex = 2;
            this.down_cb.Text = "下行";
            this.down_cb.UseVisualStyleBackColor = false;
            this.down_cb.CheckedChanged += new System.EventHandler(this.down_cb_CheckedChanged);
            // 
            // psngerTrain_cb
            // 
            this.psngerTrain_cb.AutoSize = true;
            this.psngerTrain_cb.BackColor = System.Drawing.Color.Transparent;
            this.psngerTrain_cb.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.psngerTrain_cb.DownBack = null;
            this.psngerTrain_cb.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.psngerTrain_cb.Location = new System.Drawing.Point(409, 819);
            this.psngerTrain_cb.MouseBack = null;
            this.psngerTrain_cb.Name = "psngerTrain_cb";
            this.psngerTrain_cb.NormlBack = null;
            this.psngerTrain_cb.SelectedDownBack = null;
            this.psngerTrain_cb.SelectedMouseBack = null;
            this.psngerTrain_cb.SelectedNormlBack = null;
            this.psngerTrain_cb.Size = new System.Drawing.Size(142, 35);
            this.psngerTrain_cb.TabIndex = 3;
            this.psngerTrain_cb.Text = "旅客列车";
            this.psngerTrain_cb.UseVisualStyleBackColor = false;
            this.psngerTrain_cb.CheckedChanged += new System.EventHandler(this.psngerTrain_cb_CheckedChanged);
            // 
            // nonPsngerTrain_cb
            // 
            this.nonPsngerTrain_cb.AutoSize = true;
            this.nonPsngerTrain_cb.BackColor = System.Drawing.Color.Transparent;
            this.nonPsngerTrain_cb.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.nonPsngerTrain_cb.DownBack = null;
            this.nonPsngerTrain_cb.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nonPsngerTrain_cb.Location = new System.Drawing.Point(613, 819);
            this.nonPsngerTrain_cb.MouseBack = null;
            this.nonPsngerTrain_cb.Name = "nonPsngerTrain_cb";
            this.nonPsngerTrain_cb.NormlBack = null;
            this.nonPsngerTrain_cb.SelectedDownBack = null;
            this.nonPsngerTrain_cb.SelectedMouseBack = null;
            this.nonPsngerTrain_cb.SelectedNormlBack = null;
            this.nonPsngerTrain_cb.Size = new System.Drawing.Size(176, 35);
            this.nonPsngerTrain_cb.TabIndex = 4;
            this.nonPsngerTrain_cb.Text = "出库/检测车";
            this.nonPsngerTrain_cb.UseVisualStyleBackColor = false;
            this.nonPsngerTrain_cb.CheckedChanged += new System.EventHandler(this.nonPsngerTrain_cb_CheckedChanged);
            // 
            // checked_cb
            // 
            this.checked_cb.AutoSize = true;
            this.checked_cb.BackColor = System.Drawing.Color.Transparent;
            this.checked_cb.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.checked_cb.DownBack = null;
            this.checked_cb.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checked_cb.Location = new System.Drawing.Point(854, 819);
            this.checked_cb.MouseBack = null;
            this.checked_cb.Name = "checked_cb";
            this.checked_cb.NormlBack = null;
            this.checked_cb.SelectedDownBack = null;
            this.checked_cb.SelectedMouseBack = null;
            this.checked_cb.SelectedNormlBack = null;
            this.checked_cb.Size = new System.Drawing.Size(118, 35);
            this.checked_cb.TabIndex = 5;
            this.checked_cb.Text = "已核对";
            this.checked_cb.UseVisualStyleBackColor = false;
            this.checked_cb.CheckedChanged += new System.EventHandler(this.checked_cb_CheckedChanged);
            // 
            // nonChecked_cb
            // 
            this.nonChecked_cb.AutoSize = true;
            this.nonChecked_cb.BackColor = System.Drawing.Color.Transparent;
            this.nonChecked_cb.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.nonChecked_cb.DownBack = null;
            this.nonChecked_cb.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nonChecked_cb.Location = new System.Drawing.Point(1037, 819);
            this.nonChecked_cb.MouseBack = null;
            this.nonChecked_cb.Name = "nonChecked_cb";
            this.nonChecked_cb.NormlBack = null;
            this.nonChecked_cb.SelectedDownBack = null;
            this.nonChecked_cb.SelectedMouseBack = null;
            this.nonChecked_cb.SelectedNormlBack = null;
            this.nonChecked_cb.Size = new System.Drawing.Size(118, 35);
            this.nonChecked_cb.TabIndex = 6;
            this.nonChecked_cb.Text = "未匹配";
            this.nonChecked_cb.UseVisualStyleBackColor = false;
            this.nonChecked_cb.CheckedChanged += new System.EventHandler(this.nonChecked_cb_CheckedChanged);
            // 
            // AllTrainsInCommand_lbl
            // 
            this.AllTrainsInCommand_lbl.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AllTrainsInCommand_lbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.AllTrainsInCommand_lbl.Location = new System.Drawing.Point(286, 81);
            this.AllTrainsInCommand_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.AllTrainsInCommand_lbl.Name = "AllTrainsInCommand_lbl";
            this.AllTrainsInCommand_lbl.Size = new System.Drawing.Size(146, 62);
            this.AllTrainsInCommand_lbl.TabIndex = 30;
            this.AllTrainsInCommand_lbl.Text = "0";
            this.AllTrainsInCommand_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(446, 98);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(158, 31);
            this.label14.TabIndex = 29;
            this.label14.Text = "当前筛选数量";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(66, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 31);
            this.label1.TabIndex = 31;
            this.label1.Text = "客调命令总车次数：";
            // 
            // currentShow_lbl
            // 
            this.currentShow_lbl.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentShow_lbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.currentShow_lbl.Location = new System.Drawing.Point(616, 81);
            this.currentShow_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.currentShow_lbl.Name = "currentShow_lbl";
            this.currentShow_lbl.Size = new System.Drawing.Size(146, 62);
            this.currentShow_lbl.TabIndex = 32;
            this.currentShow_lbl.Text = "0";
            this.currentShow_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // search_tb
            // 
            this.search_tb.Location = new System.Drawing.Point(893, 98);
            this.search_tb.Margin = new System.Windows.Forms.Padding(6);
            this.search_tb.Name = "search_tb";
            this.search_tb.Size = new System.Drawing.Size(262, 35);
            this.search_tb.TabIndex = 34;
            this.search_tb.TextChanged += new System.EventHandler(this.search_tb_TextChanged);
            // 
            // secondListTitle_lbl
            // 
            this.secondListTitle_lbl.AutoSize = true;
            this.secondListTitle_lbl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.secondListTitle_lbl.Location = new System.Drawing.Point(771, 98);
            this.secondListTitle_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.secondListTitle_lbl.Name = "secondListTitle_lbl";
            this.secondListTitle_lbl.Size = new System.Drawing.Size(110, 31);
            this.secondListTitle_lbl.TabIndex = 33;
            this.secondListTitle_lbl.Text = "搜索车次";
            // 
            // data_lv
            // 
            this.data_lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Match,
            this.trainIndex,
            this.trainNumber,
            this.secondTrainNumber,
            this._upOrDown,
            this._trainType,
            this._trainModel,
            this._trainID});
            this.data_lv.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.data_lv.Location = new System.Drawing.Point(72, 160);
            this.data_lv.Name = "data_lv";
            this.data_lv.Size = new System.Drawing.Size(1083, 622);
            this.data_lv.TabIndex = 35;
            this.data_lv.UseCompatibleStateImageBehavior = false;
            this.data_lv.View = System.Windows.Forms.View.Details;
            // 
            // Match
            // 
            this.Match.Text = "位于";
            // 
            // trainIndex
            // 
            this.trainIndex.Text = "匹配";
            // 
            // trainNumber
            // 
            this.trainNumber.Text = "车次";
            // 
            // secondTrainNumber
            // 
            this.secondTrainNumber.Text = "车次(2)";
            // 
            // _upOrDown
            // 
            this._upOrDown.Text = "上下行";
            // 
            // _trainType
            // 
            this._trainType.Text = "类型";
            // 
            // _trainModel
            // 
            this._trainModel.Text = "车型";
            // 
            // _trainID
            // 
            this._trainID.Text = "车号";
            // 
            // DataAnalyse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 900);
            this.Controls.Add(this.data_lv);
            this.Controls.Add(this.search_tb);
            this.Controls.Add(this.secondListTitle_lbl);
            this.Controls.Add(this.currentShow_lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AllTrainsInCommand_lbl);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.nonChecked_cb);
            this.Controls.Add(this.checked_cb);
            this.Controls.Add(this.nonPsngerTrain_cb);
            this.Controls.Add(this.psngerTrain_cb);
            this.Controls.Add(this.down_cb);
            this.Controls.Add(this.up_cb);
            this.Name = "DataAnalyse";
            this.Text = "核对数据";
            this.Load += new System.EventHandler(this.DataAnalyse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CCWin.SkinControl.SkinCheckBox up_cb;
        private CCWin.SkinControl.SkinCheckBox down_cb;
        private CCWin.SkinControl.SkinCheckBox psngerTrain_cb;
        private CCWin.SkinControl.SkinCheckBox nonPsngerTrain_cb;
        private CCWin.SkinControl.SkinCheckBox checked_cb;
        private CCWin.SkinControl.SkinCheckBox nonChecked_cb;
        private System.Windows.Forms.Label AllTrainsInCommand_lbl;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currentShow_lbl;
        private System.Windows.Forms.TextBox search_tb;
        private System.Windows.Forms.Label secondListTitle_lbl;
        private System.Windows.Forms.ListView data_lv;
        private System.Windows.Forms.ColumnHeader trainIndex;
        private System.Windows.Forms.ColumnHeader Match;
        private System.Windows.Forms.ColumnHeader trainNumber;
        private System.Windows.Forms.ColumnHeader secondTrainNumber;
        private System.Windows.Forms.ColumnHeader _upOrDown;
        private System.Windows.Forms.ColumnHeader _trainType;
        private System.Windows.Forms.ColumnHeader _trainModel;
        private System.Windows.Forms.ColumnHeader _trainID;
    }
}