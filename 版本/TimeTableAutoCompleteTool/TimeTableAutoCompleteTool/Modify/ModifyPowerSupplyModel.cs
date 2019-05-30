using DisplaySystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DisplaySystem.Modify
{
    public partial class ModifyPowerSupplyModel : Form
    {
        List<PowerSupplyModel> psModel;
        List<TrackLine> tLine;
        List<TrackPoint> tPoint;
        List<Signal> signal;

        Display main;
        public ModifyPowerSupplyModel(Display _main)
        {
            main = _main;
            psModel = _main.psModel;
            tLine = _main.tLine;
            tPoint = _main.tPoint;
            signal = main.signal;
            InitializeComponent();
        }

        private void ModifyPowerSupplyModel_Load(object sender, EventArgs e)
        {
            initUI(false);
            radioButton1.Checked = true;
            radioButton3.Checked = true;
        }

        private void initUI(bool refreshMode)
        {//false为首次，true为后续增删后
            ps_lv.Items.Clear();
            foreach (PowerSupplyModel _psModel in psModel)
            {
                ListViewItem lvi = new ListViewItem(_psModel.powerSupplyID.ToString());
                lvi.SubItems.Add(_psModel.powerSupplyName.ToString());
                lvi.SubItems.Add(_psModel.powerSupplyRange.ToString());
                ps_lv.Items.Add(lvi);
            }
            ps_lv.Update();
            if (!refreshMode)
            {
                otherPoints_lv.Items.Clear();
                otherTracks_lv.Items.Clear();
                foreach (TrackLine _line in tLine)
                {
                    ListViewItem lvi = new ListViewItem(_line.trackLineID.ToString());
                    lvi.SubItems.Add(_line.trackText.ToString());
                    otherTracks_lv.Items.Add(lvi);
                }
                foreach (TrackPoint _point in tPoint)
                {
                    ListViewItem lvi = new ListViewItem(_point.trackPointID.ToString());
                    lvi.SubItems.Add(_point.trackPoint.ToString());
                    otherPoints_lv.Items.Add(lvi);
                }
                foreach (Signal _signal in signal)
                {
                    ListViewItem lvi = new ListViewItem(_signal.signalID.ToString());
                    lvi.SubItems.Add(_signal.signalPoint.ToString());
                    otherFunctionalPoints_lv.Items.Add(lvi);
                }
                otherFunctionalPoints_lv.Update();
                otherPoints_lv.Update();
                otherTracks_lv.Update();
            }

        }

        private void refreshListViews(PowerSupplyModel _psModel)
        {//传空为清空表格
            containPoints_lv.Items.Clear();
            containTracks_lv.Items.Clear();
            containsFunctionalPoints_lv.Items.Clear();
            if(_psModel != null)
            {
                foreach (TrackPoint _tp in _psModel.containedTrackPoint)
                {
                    ListViewItem lvi_Point = new ListViewItem(_tp.trackPointID.ToString());
                    lvi_Point.SubItems.Add(_tp.trackPoint.ToString());
                    if(_tp.switchDirection == 1)
                    {
                        lvi_Point.SubItems.Add("定位");
                    }else if(_tp.switchDirection == 2)
                    {
                        lvi_Point.SubItems.Add("反位");
                    }
                    bool hasGotIt = false;
                    for(int ij = 0; ij < tPoint.Count; ij++)
                    {
                        if (tPoint[ij].trackPointID.Equals(_tp.trackPointID))
                        {
                            lvi_Point.SubItems.Add(ij.ToString());
                            hasGotIt = true;
                        }
                        if (hasGotIt)
                        {
                            break;
                        }
                    }
                    if (hasGotIt)
                    {
                        containPoints_lv.Items.Add(lvi_Point);
                    }
                }
                for(int i = 0; i< _psModel.containedTrackLine.Count; i++)
                {
                    TrackLine _tl = (TrackLine)_psModel.containedTrackLine[i];
                    ListViewItem lvi_Line = new ListViewItem(_tl.trackLineID.ToString());
                    lvi_Line.SubItems.Add(_tl.trackText.ToString());
                    if(_tl.containsInPS == 0)
                    {
                        lvi_Line.SubItems.Add("全部");
                    }else if(_tl.containsInPS == 1)
                    {
                        lvi_Line.SubItems.Add("左半");
                    }else if(_tl.containsInPS == 2)
                    {
                        lvi_Line.SubItems.Add("右半");
                    }
                    bool hasGotIt = false;
                    for (int ij = 0; ij < tLine.Count; ij++)
                    {
                        if (tLine[ij].trackLineID.Equals(_tl.trackLineID))
                        {
                            lvi_Line.SubItems.Add(ij.ToString());
                            hasGotIt = true;
                        }
                        if (hasGotIt)
                        {
                            break;
                        }
                    }
                    if (hasGotIt)
                    {
                        containTracks_lv.Items.Add(lvi_Line);
                    }
                }
                foreach (Signal _s in _psModel.functionalTrackPoint)
                {
                    ListViewItem lvi_Signal = new ListViewItem(_s.signalID.ToString());
                    lvi_Signal.SubItems.Add(_s.signalPoint.ToString());
                    bool hasGotIt = false;
                    for (int ij = 0; ij < signal.Count; ij++)
                    {
                        if (signal[ij].signalID.Equals(_s.signalID))
                        {
                            lvi_Signal.SubItems.Add(ij.ToString());
                            hasGotIt = true;
                        }
                        if (hasGotIt)
                        {
                            break;
                        }
                    }
                    if (hasGotIt)
                    {
                        containsFunctionalPoints_lv.Items.Add(lvi_Signal);
                    }
                }
                containsFunctionalPoints_lv.Update();
                containPoints_lv.Update();
                containTracks_lv.Update();
            }
            else
            {
                return;
            }

        }

        private void id_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void ModifyPowerSupplyModel_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.psModel = this.psModel;
            main.refreshButtons();
            main.Refresh();
        }

        private void removeText()
        {
            id_tb.Text = "";
            name_tb.Text = "";
            psRange_tb.Text = "";
            containPoints_lv.Items.Clear();
            containTracks_lv.Items.Clear();
            containsFunctionalPoints_lv.Items.Clear();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if(id_tb.Text.Length != 0 &&
                name_tb.Text.Length != 0)
            {
                try
                {
                    PowerSupplyModel _psModel = new PowerSupplyModel();
                    _psModel.powerSupplyID = int.Parse(id_tb.Text);
                    _psModel.powerSupplyName = name_tb.Text;
                    _psModel.powerSupplyRange = psRange_tb.Text;
                    List<TrackPoint> _tpList = new List<TrackPoint>();
                    List<TrackLine> _tlList = new List<TrackLine>();
                    List<Signal> _signalList = new List<Signal>();
                    if (containPoints_lv.Items.Count != 0)
                    {
                        foreach(ListViewItem lvi in containPoints_lv.Items)
                        {
                            TrackPoint _tp = new TrackPoint();
                            _tp = (TrackPoint)tPoint[int.Parse(lvi.SubItems[3].Text)].Clone();
                            if(lvi.SubItems[2] != null)
                            {
                                if (lvi.SubItems[2].Text.Contains("定"))
                                {
                                    _tp.switchDirection = 1;
                                }else if (lvi.SubItems[2].Text.Contains("反"))
                                {
                                    _tp.switchDirection = 2;
                                }
                            }
                            _tpList.Add(_tp);
                        }
                    }
                    if (containTracks_lv.Items.Count != 0)
                    {
                        foreach (ListViewItem lvi in containTracks_lv.Items)
                        {
                            TrackLine _tline = new TrackLine();
                            _tline = (TrackLine)tLine[int.Parse(lvi.SubItems[3].Text)].Clone();
                            if (lvi.SubItems[2].Text.Contains("全部"))
                            {
                                _tline.containsInPS = 0;
                            }else if (lvi.SubItems[2].Text.Contains("左"))
                            {
                                _tline.containsInPS = 1;
                            }else if (lvi.SubItems[2].Text.Contains("右"))
                            {
                                _tline.containsInPS = 2;
                            }
                            _tlList.Add(_tline);
                        }
                    }
                    if (containsFunctionalPoints_lv.Items.Count != 0)
                    {
                        foreach (ListViewItem lvi in containsFunctionalPoints_lv.Items)
                        {
                            Signal _s = new Signal();
                            _s = (Signal)signal[int.Parse(lvi.SubItems[2].Text)].Clone();
                            _signalList.Add(_s);
                        }
                    }
                    _psModel.containedTrackLine = _tlList;
                    _psModel.containedTrackPoint = _tpList;
                    _psModel.functionalTrackPoint = _signalList;
                    if(ps_lv.SelectedItems.Count  != 0)
                    {
                        psModel.RemoveAt(ps_lv.SelectedItems[0].Index);
                    }
                    psModel.Add(_psModel);
                    initUI(true);
                    removeText();
                
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.ToString().Split('。')[0] + "。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                

            }
            else
            {
                MessageBox.Show("请填写左边框内ID和名称","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void ps_lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ps_lv.SelectedItems.Count == 0)
            {
                refreshListViews(null);
                removeText();
            }
            else
            {
                id_tb.Text = ps_lv.SelectedItems[0].SubItems[0].Text;
                name_tb.Text = ps_lv.SelectedItems[0].SubItems[1].Text;
                psRange_tb.Text = ps_lv.SelectedItems[0].SubItems[2].Text;
                refreshListViews(psModel[ps_lv.SelectedItems[0].Index]);
            }
        }

        private void addTrack_btn_Click(object sender, EventArgs e)
        {
            if(otherTracks_lv.SelectedItems.Count != 0)
            {
                ListViewItem lvi = new ListViewItem(otherTracks_lv.SelectedItems[0].SubItems[0].Text);
                lvi.SubItems.Add(otherTracks_lv.SelectedItems[0].SubItems[1].Text);
                if (radioButton3.Checked)
                {
                    lvi.SubItems.Add("全部");
                }else if (radioButton4.Checked)
                {
                    lvi.SubItems.Add("左半");
                }else if (radioButton5.Checked)
                {
                    lvi.SubItems.Add("右半");
                }
                else
                {
                    lvi.SubItems.Add("");
                }
                lvi.SubItems.Add(otherTracks_lv.SelectedItems[0].Index.ToString());
                containTracks_lv.Items.Add(lvi);
                containTracks_lv.Update();
            }
        }

        private void addPoint_btn_Click(object sender, EventArgs e)
        {
            if(otherPoints_lv.SelectedItems.Count != 0)
            {
                ListViewItem lvi = new ListViewItem(otherPoints_lv.SelectedItems[0].SubItems[0].Text);
                lvi.SubItems.Add(otherPoints_lv.SelectedItems[0].SubItems[1].Text);
                if (radioButton1.Checked)
                {
                    lvi.SubItems.Add("定位");
                }else if (radioButton2.Checked)
                {
                    lvi.SubItems.Add("反位");
                }
                lvi.SubItems.Add(otherPoints_lv.SelectedItems[0].Index.ToString());
                containPoints_lv.Items.Add(lvi);
                containPoints_lv.Update();
            }
        }

        private void deleteTrack_btn_Click(object sender, EventArgs e)
        {

                if (containTracks_lv.SelectedItems.Count != 0)
                {
                    containTracks_lv.Items.RemoveAt(containTracks_lv.SelectedItems[0].Index);
                    containTracks_lv.Update();
                }
        }

        private void deletePoint_btn_Click(object sender, EventArgs e)
        {
            if (containPoints_lv.SelectedItems.Count != 0)
            {
                containPoints_lv.Items.RemoveAt(containPoints_lv.SelectedItems[0].Index);
                containPoints_lv.Update();
            }
        }

        private void modifyPoint_btn_Click(object sender, EventArgs e)
        {
            if (containTracks_lv.SelectedItems.Count != 0)
            {

            }
        }


        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (ps_lv.SelectedItems.Count != 0)
            {
                if (MessageBox.Show("是否删除?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                    psModel.RemoveAt(ps_lv.SelectedItems[0].Index);
                    removeText();
                    initUI(true);
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {//信号机的添加按钮
            if (otherFunctionalPoints_lv.SelectedItems.Count != 0)
            {
                ListViewItem lvi = new ListViewItem(otherFunctionalPoints_lv.SelectedItems[0].SubItems[0].Text);
                lvi.SubItems.Add(otherFunctionalPoints_lv.SelectedItems[0].SubItems[1].Text);
                lvi.SubItems.Add(otherFunctionalPoints_lv.SelectedItems[0].Index.ToString());
                containsFunctionalPoints_lv.Items.Add(lvi);
                containsFunctionalPoints_lv.Update();
            }
        }

        private void deleteSignal_btn_Click(object sender, EventArgs e)
        {
            if (containsFunctionalPoints_lv.SelectedItems.Count != 0)
            {
                containsFunctionalPoints_lv.Items.RemoveAt(containsFunctionalPoints_lv.SelectedItems[0].Index);
                containsFunctionalPoints_lv.Update();
            }
        }
    }
}
