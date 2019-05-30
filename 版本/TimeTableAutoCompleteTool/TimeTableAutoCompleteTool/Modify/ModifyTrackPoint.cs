using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DisplaySystem.Modify
{
    public partial class ModifyTrackPoint : Form
    {
        List<TrackPoint> tPoint;
        Display main;
        //暂存
        TrackPoint tempTP = new TrackPoint();
        public ModifyTrackPoint(Display _main)
        {
            tPoint = _main.tPoint;
            main = _main;
            InitializeComponent();
        }

        private void ModifyTrackPoint_Load(object sender, EventArgs e)
        {
            TrackPointListView.MultiSelect = false;
            deleteBtn.Enabled = false;
            initUI();
        }

        private void initUI()
        {
            TrackPointListView.Items.Clear();
            foreach(TrackPoint _tPoint in tPoint)
            {
                ListViewItem lvi = new ListViewItem(_tPoint.trackPointID.ToString());
                lvi.SubItems.Add(_tPoint.trackPoint.ToString());
                lvi.SubItems.Add(_tPoint.firstTrackLine.ToString());
                lvi.SubItems.Add(_tPoint.secondTrackLine.ToString());
                lvi.SubItems.Add(_tPoint.thirdTrackLine.ToString());
                TrackPointListView.Items.Add(lvi);
            }
            TrackPointListView.Update();

        }

        private void id_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        private void x_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void x_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            */
        }

        private void y_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            */
        }

        private void p1_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void p2_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void p3_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (id_tb.Text.Length != 0 &&
                x_tb.Text.Length != 0 &&
                y_tb.Text.Length != 0)
            {
                try
                {
                    if (TrackPointListView.SelectedItems.Count == 0)
                    {//新建
                        TrackPoint _tp = new TrackPoint();
                        _tp.trackPointID = int.Parse(id_tb.Text.ToString());
                        _tp.trackPoint = new Point(int.Parse(x_tb.Text), int.Parse(y_tb.Text));
                        _tp.firstTrackLine = int.Parse(p1_tb.Text.ToString());
                        _tp.secondTrackLine = int.Parse(p2_tb.Text.ToString());
                        _tp.thirdTrackLine = int.Parse(p3_tb.Text.ToString());
                        tPoint.Add(_tp);
                        initUI();

                    }
                    else
                    {//编辑
                        TrackPoint _tp = new TrackPoint();
                        _tp.trackPointID = int.Parse(id_tb.Text.ToString());
                        _tp.trackPoint = new Point(int.Parse(x_tb.Text), int.Parse(y_tb.Text));
                        _tp.firstTrackLine = int.Parse(p1_tb.Text.ToString());
                        _tp.secondTrackLine = int.Parse(p2_tb.Text.ToString());
                        _tp.thirdTrackLine = int.Parse(p3_tb.Text.ToString());
                        tPoint.RemoveAt(TrackPointListView.SelectedItems[0].Index);
                        tPoint.Add(_tp);
                        tPoint.Sort();
                        initUI();
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.ToString().Split('。')[0] + "。");
                }
                removeText();
            }
            else
            {
                MessageBox.Show("请填写全部内容", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            }

        private void saveTempData()
        {
            TrackPoint _tempTP = new TrackPoint();
            if (id_tb.Text.Length != 0)
            {
                _tempTP.trackPointID = int.Parse(id_tb.Text.ToString());
            }
            if (x_tb.Text.Length != 0 && y_tb.Text.Length != 0)
            {
                _tempTP.trackPoint = new Point(int.Parse(x_tb.Text.ToString()), int.Parse(y_tb.Text.ToString()) );
            }
            if(p1_tb.Text.Length != 0)
            {
                _tempTP.firstTrackLine = int.Parse(p1_tb.Text);
            }
            if (p2_tb.Text.Length != 0)
            {
                _tempTP.secondTrackLine = int.Parse(p2_tb.Text);
            }
            if (p3_tb.Text.Length != 0)
            {
                _tempTP.thirdTrackLine = int.Parse(p3_tb.Text);
            }
            tempTP = _tempTP;
        }

        private void loadTempData()
        {
            if (tempTP.trackPointID != null)
            {
                id_tb.Text = tempTP.trackPointID.ToString();
            }
            if (tempTP.trackPoint != null)
            {
                x_tb.Text = tempTP.trackPoint.X.ToString();
                y_tb.Text = tempTP.trackPoint.Y.ToString();
            }
            if (tempTP.firstTrackLine != 0)
            {
                p1_tb.Text = tempTP.firstTrackLine.ToString();
            }
            if (tempTP.secondTrackLine != 0)
            {
                p2_tb.Text = tempTP.secondTrackLine.ToString();
            }
            if (tempTP.thirdTrackLine != 0)
            {
                p3_tb.Text = tempTP.thirdTrackLine.ToString();
            }
        }

        private void removeText()
        {
            id_tb.Text = "";
            x_tb.Text = "";
            y_tb.Text = "";
            p1_tb.Text = "";
            p2_tb.Text = "";
            p3_tb.Text = "";
        }

        private void TrackPointListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TrackPointListView.SelectedItems.Count != 0)
            {
                deleteBtn.Enabled = true;
                saveTempData();
                TrackPoint _tp = tPoint[TrackPointListView.SelectedItems[0].Index];
                id_tb.Text = _tp.trackPointID.ToString();
                x_tb.Text = _tp.trackPoint.X.ToString();
                y_tb.Text = _tp.trackPoint.Y.ToString();
                p1_tb.Text = _tp.firstTrackLine.ToString();
                p2_tb.Text = _tp.secondTrackLine.ToString();
                p3_tb.Text = _tp.thirdTrackLine.ToString();
            }
            else
            {
                deleteBtn.Enabled = false;
                loadTempData();

            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if(TrackPointListView.SelectedItems.Count != 0)
            {
                tPoint.RemoveAt(TrackPointListView.SelectedItems[0].Index);
                tPoint.Sort();
                initUI();
                removeText();
            }
        }
        
        void ModifyTrackPoint_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.tPoint = this.tPoint;
            main.Refresh();
        }


    }
    }
    
