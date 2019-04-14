using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DisplaySystem
{
    public partial class ModifyTrackLine : Form
    {
        List<TrackLine> tLine;
        List<TrackPoint> tPoint;
        TrackPoint tempLPoint = new TrackPoint();
        TrackPoint tempRPoint = new TrackPoint();

        Display main;
        public ModifyTrackLine(Display _main)
        {
            tLine = _main.tLine;
            tPoint = _main.tPoint;
            main = _main;
            InitializeComponent();
        }

        private void ModifyTrackLine_Load(object sender, EventArgs e)
        {
            initUI();
        }

        private void initUI()
        {
            TrackLine_lv.Items.Clear();
            foreach (TrackLine _tLine in tLine)
            {
                ListViewItem lvi = new ListViewItem(_tLine.trackLineID.ToString());
                lvi.SubItems.Add(_tLine.trackText.ToString());
                lvi.SubItems.Add(_tLine.selfLeftPoint.ToString());
                lvi.SubItems.Add(_tLine.selfRightPoint.ToString());
                if(_tLine.leftTrackPoint != null)
                {
                    lvi.SubItems.Add(_tLine.leftTrackPoint.trackPointID.ToString());
                    tempLPoint = _tLine.leftTrackPoint;
                }
                if (_tLine.rightTrackPoint != null)
                {
                    lvi.SubItems.Add(_tLine.rightTrackPoint.trackPointID.ToString());
                    tempRPoint = _tLine.rightTrackPoint;
                }
                if (_tLine.leftWayTo == null)
                {
                    _tLine.leftWayTo = "";
                }
                if (_tLine.rightWayTo == null)
                {
                    _tLine.rightWayTo = "";
                }
                TrackLine_lv.Items.Add(lvi);
            }
            TrackLine_lv.Update();

            Point_lv.Items.Clear();
            foreach (TrackPoint _tPoint in tPoint)
            {
                ListViewItem lvi = new ListViewItem(_tPoint.trackPointID.ToString());
                lvi.SubItems.Add(_tPoint.firstTrackLine.ToString());
                lvi.SubItems.Add(_tPoint.secondTrackLine.ToString());
                lvi.SubItems.Add(_tPoint.thirdTrackLine.ToString());
                Point_lv.Items.Add(lvi);
            }
            Point_lv.Update();
        }

        private void id_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void leftX_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            */
        }

        private void leftY_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            */
        }

        private void rightX_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            */
        }

        private void rightY_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            */
        }

        private void lPoint_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void rPoint_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                TrackLine _tl = new TrackLine();
                if ((id_tb.Text.Length != 0 &&
                    describe_tb.Text.Length != 0 &&
                    leftX_tb.Text.Length != 0 &&
                    leftY_tb.Text.Length != 0 &&
                    rightX_tb.Text.Length != 0 &&
                    rightY_tb.Text.Length != 0)
                    )
                {
                    _tl.trackLineID = int.Parse(id_tb.Text);
                    _tl.trackText = describe_tb.Text;
                    _tl.selfLeftPoint = new Point(int.Parse(leftX_tb.Text), int.Parse(leftY_tb.Text));
                    _tl.selfRightPoint = new Point(int.Parse(rightX_tb.Text), int.Parse(rightY_tb.Text));
                    if (lPoint_tb.Text.Length != 0 &&
                        tempLPoint != null)
                    {
                        _tl.leftTrackPoint = tempLPoint;
                    }
                    if (rPoint_tb.Text.Length != 0 &&
                        tempRPoint != null)
                    {
                        _tl.rightTrackPoint = tempRPoint;
                    }
                    if (TrackLine_lv.SelectedItems.Count != 0)
                    {
                        tLine.RemoveAt(TrackLine_lv.SelectedItems[0].Index);
                    }
                    if(leftWayTo_tb.Text.Length != 0)
                    {
                        _tl.leftWayTo = leftWayTo_tb.Text;
                    }
                    if (rightWayTo_tb.Text.Length != 0)
                    {
                        _tl.rightWayTo = rightWayTo_tb.Text;
                    }
                    tLine.Add(_tl);
                    tLine.Sort();
                    removeText();
                    initUI();
                }
                else
                {
                    MessageBox.Show("请填写可填写内容", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString().Split('。')[0] + "。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void removeText()
        {
            id_tb.Text = "";
            describe_tb.Text = "";
            leftX_tb.Text = "";
            leftY_tb.Text = "";
            rightX_tb.Text = "";
            rightY_tb.Text = "";
            lPoint_tb.Text = "";
            rPoint_tb.Text = "";
            leftWayTo_tb.Text = "";
            rightWayTo_tb.Text = "";
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if(TrackLine_lv.SelectedItems.Count != 0)
            {
                removeText();
                tLine.RemoveAt(TrackLine_lv.SelectedItems[0].Index);
                tLine.Sort();
                initUI();
            }
        }

        private void TrackLine_lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TrackLine_lv.SelectedItems.Count != 0)
            {
                deleteBtn.Enabled = true;
                TrackLine _tl = tLine[TrackLine_lv.SelectedItems[0].Index];
                id_tb.Text = _tl.trackLineID.ToString();
                describe_tb.Text = _tl.trackText.ToString();
                leftX_tb.Text = _tl.selfLeftPoint.X.ToString();
                leftY_tb.Text = _tl.selfLeftPoint.Y.ToString();
                rightX_tb.Text = _tl.selfRightPoint.X.ToString();
                rightY_tb.Text = _tl.selfRightPoint.Y.ToString();
                leftWayTo_tb.Text = _tl.leftWayTo;
                rightWayTo_tb.Text = _tl.rightWayTo;
                if(_tl.leftTrackPoint != null)
                {
                    lPoint_tb.Text = _tl.leftTrackPoint.trackPointID.ToString();
                }
                if(_tl.rightTrackPoint != null)
                {
                    rPoint_tb.Text = _tl.rightTrackPoint.trackPointID.ToString();
                }
            }
            else
            {
                deleteBtn.Enabled = false;
            }
        }

        private void lPoint_tb_TextChanged(object sender, EventArgs e)
        {
            if(lPoint_tb.Text.Length == 0)
            {
                tempLPoint = new TrackPoint();
            }
        }

        private void rPoint_tb_TextChanged(object sender, EventArgs e)
        {
            if (rPoint_tb.Text.Length == 0)
            {
                tempRPoint = new TrackPoint();
            }
        }

        private void Point_lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Point_lv.SelectedItems.Count == 0)
            {

            }
            else
            {

            }
        }

        private void leftPlus_btn_Click(object sender, EventArgs e)
        {
            if(Point_lv.SelectedItems.Count != 0)
            {
                tempLPoint = tPoint[Point_lv.SelectedItems[0].Index];
                lPoint_tb.Text = tempLPoint.trackPointID.ToString();
            }
        }

        private void leftMinus_btn_Click(object sender, EventArgs e)
        {
            if (Point_lv.SelectedItems.Count != 0)
            {
                tempLPoint = new TrackPoint();
            }
        }

        private void rightPlus_btn_Click(object sender, EventArgs e)
        {
            if (Point_lv.SelectedItems.Count != 0)
            {
                if (Point_lv.SelectedItems.Count != 0)
                {
                    tempRPoint = tPoint[Point_lv.SelectedItems[0].Index];
                    rPoint_tb.Text = tempRPoint.trackPointID.ToString();
                }
            }
        }

        private void rightMinus_btn_Click(object sender, EventArgs e)
        {
            if (Point_lv.SelectedItems.Count != 0)
            {
                tempRPoint = new TrackPoint();
            }
        }

        void ModifyTrackLine_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.tLine = this.tLine;
            main.selfPaint();
            main.Refresh();
        }

        private void leftWayTo_tb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
