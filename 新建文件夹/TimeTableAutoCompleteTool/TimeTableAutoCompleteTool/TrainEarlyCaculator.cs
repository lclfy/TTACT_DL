using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TimeTableAutoCompleteTool
{
    public partial class TrainEarlyCaculator : Form
    {
        List<CaculatorModel> caculatorModelList;
        public TrainEarlyCaculator(List<CaculatorModel> _caculatorModel)
        {
            InitializeComponent();
            caculatorModelList = _caculatorModel;
        }

        private void TrainEarlyCaculator_Load(object sender, EventArgs e)
        {
            trainsInformation_lv.View = View.Details;
            string[] informationTitle = new string[] { "序号", "车次", "图定到", "实际到", "图定发", "实际发", "赶点" };
            this.trainsInformation_lv.BeginUpdate();
            for (int i = 0; i < informationTitle.Length; i++)
            {
                ColumnHeader ch = new ColumnHeader();
                ch.Text = informationTitle[i];   //设置列标题 
                if (i == 0)
                {
                    ch.Width = 40;
                }
                else
                {
                    ch.Width = 50;
                }
                
                this.trainsInformation_lv.Columns.Add(ch);    //将列头添加到ListView控件。
            }
            int counter = 1;
            foreach(CaculatorModel model in caculatorModelList)
            {
                if(counter == 1)
                {
                    CurrentTrainNumber_lbl.Text = model.trainNumber;
                    ShouldArriveTime_lbl.Text = model.shouldArriveTime;
                    ShouldStartTime_lbl.Text = model.shouldStartTime;
                }
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems[0].Text = counter.ToString();
                counter++;
                lvi.SubItems.Add(model.trainNumber);
                lvi.SubItems.Add(model.shouldArriveTime);
                lvi.SubItems.Add("");
                lvi.SubItems.Add(model.shouldStartTime);
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");
                this.trainsInformation_lv.Items.Add(lvi);
            }
            this.trainsInformation_lv.EndUpdate();

            
        }

        private void trainsInformation_lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (trainsInformation_lv.SelectedItems.Count != 0)
            {
                CurrentTrainNumber_lbl.Text = trainsInformation_lv.SelectedItems[0].SubItems[1].Text;
                ShouldArriveTime_lbl.Text = trainsInformation_lv.SelectedItems[0].SubItems[2].Text;
                ShouldStartTime_lbl.Text = trainsInformation_lv.SelectedItems[0].SubItems[4].Text;
            }

        }

        private void ActuallyArriveTime_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ActuallyArriveTime_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }

        private void ActuallyStartTime_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ActuallyStartTime_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }

        private void ActuallyArriveTime_tb_Click(object sender, EventArgs e)
        {
            if (ActuallyArriveTime_tb.Text.Equals("0000"))
            {
                ActuallyArriveTime_tb.Text = "";
            }
        }

        private void ActuallyStartTime_tb_Click(object sender, EventArgs e)
        {
            if (ActuallyStartTime_tb.Text.Equals("0000"))
            {
                ActuallyStartTime_tb.Text = "";
            }
        }

        private void ActuallyArriveTime_tb_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
