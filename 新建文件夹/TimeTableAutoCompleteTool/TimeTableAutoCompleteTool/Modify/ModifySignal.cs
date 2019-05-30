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
    public partial class ModifySignal : Form
    {
        List<Signal> signal;
        Display main;
        public ModifySignal(Display _main)
        {
            signal = _main.signal;
            main = _main;
            InitializeComponent();
        }

        private void ModifySignal_Load(object sender, EventArgs e)
        {
            TrackPointListView.MultiSelect = false;
            deleteBtn.Enabled = false;
            radioButton1.Checked = true;
            initUI();
        }

        private void initUI()
        {
            TrackPointListView.Items.Clear();
            foreach (Signal _s in signal)
            {
                ListViewItem lvi = new ListViewItem(_s.signalID.ToString());
                lvi.SubItems.Add(_s.signalPoint.ToString());
                lvi.SubItems.Add(_s.signalDir.ToString());
                TrackPointListView.Items.Add(lvi);
            }
            TrackPointListView.Update();

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
                        Signal _tp = new Signal();
                        _tp.signalID = id_tb.Text.ToString();
                        _tp.signalPoint = new Point(int.Parse(x_tb.Text), int.Parse(y_tb.Text));
                        if(tips_tb.Text.Length != 0)
                        {
                            _tp.tip = tips_tb.Text.ToString();
                        }
                        if (radioButton1.Checked)
                        {
                            _tp.signalDir = 0;
                        }else if (radioButton2.Checked)
                        {
                            _tp.signalDir = 1;
                        }
                        signal.Add(_tp);
                        initUI();
                    }
                    else
                    {//编辑
                        Signal _tp = new Signal();
                        _tp.signalID = id_tb.Text.ToString();
                        _tp.signalPoint = new Point(int.Parse(x_tb.Text), int.Parse(y_tb.Text));
                        _tp.tip = tips_tb.Text.ToString();
                        if (radioButton1.Checked)
                        {
                            _tp.signalDir = 0;
                        }
                        else if (radioButton2.Checked)
                        {
                            _tp.signalDir = 1;
                        }
                        signal.Add(_tp);
                        signal.RemoveAt(TrackPointListView.SelectedItems[0].Index);
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

        private void removeText()
        {
            id_tb.Text = "";
            x_tb.Text = "";
            y_tb.Text = "";
            tips_tb.Text = "";
        }

        private void TrackPointListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TrackPointListView.SelectedItems.Count != 0)
            {
                deleteBtn.Enabled = true;
                Signal _tp = signal[TrackPointListView.SelectedItems[0].Index];
                id_tb.Text = _tp.signalID.ToString();
                x_tb.Text = _tp.signalPoint.X.ToString();
                y_tb.Text = _tp.signalPoint.Y.ToString();
                tips_tb.Text = _tp.tip.ToString();
            }
            else
            {
                deleteBtn.Enabled = false;
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (TrackPointListView.SelectedItems.Count != 0)
            {
                signal.RemoveAt(TrackPointListView.SelectedItems[0].Index);
                initUI();
                removeText();
            }
        }

        void ModifySignal_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.signal = this.signal;
            main.Refresh();
        }

        private void x_tb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
