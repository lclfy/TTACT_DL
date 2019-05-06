using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CCWin;
using System.Windows.Forms;

namespace TimeTableAutoCompleteTool
{
    public partial class DataAnalyse : Skin_Mac
    {
        public  List<CommandModel> allCommandModels;
        public DataAnalyse(List<CommandModel>_allCm)
        {
            if(_allCm != null)
            {
                allCommandModels = _allCm;
            }
            InitializeComponent();
        }

        private void DataAnalyse_Load(object sender, EventArgs e)
        {
            init();
        }

        private void init()
        {
            search_tb.Visible = false;
            secondListTitle_lbl.Visible = false;
            up_cb.Checked = true;
            down_cb.Checked = true;
            psngerTrain_cb.Checked = true;
            nonPsngerTrain_cb.Checked = true;
            up_cb.Checked = true;
            checked_cb.Checked = true;
            nonChecked_cb.Checked = true;

            AllTrainsInCommand_lbl.Text = allCommandModels.Count.ToString();

            refreshList(up_cb.Checked, down_cb.Checked, psngerTrain_cb.Checked, nonPsngerTrain_cb.Checked, checked_cb.Checked, nonChecked_cb.Checked);
        }

        private void refreshList(bool up,bool down,bool psnger,bool nonPsnger,bool hasChecked,bool nonChecked)
        {
            List<CommandModel> _tempCM = new List<CommandModel>();
            //条件筛选
            for (int i = 0; i < allCommandModels.Count; i++)
            {
                //先确定最外层-筛选-未筛选
                if((allCommandModels[i].MatchedWithTimeTable == true &&
                    hasChecked == true))
                {//再确定上下行
                    if((allCommandModels[i].upOrDown == 0 && up == true) ||
                    (allCommandModels[i].upOrDown == 1 && down == true))
                    {//最后确定列车类型
                        if((allCommandModels[i].psngerTrain == true && psnger == true) ||
                    (allCommandModels[i].psngerTrain == false && nonPsnger == true)){
                            _tempCM.Add(allCommandModels[i]);
                        }
                    }
                    else if (allCommandModels[i].upOrDown == -1)
                    {
                        if ((allCommandModels[i].psngerTrain == true && psnger == true) ||
                            (allCommandModels[i].psngerTrain == false && nonPsnger == true))
                        {
                            _tempCM.Add(allCommandModels[i]);
                        }
                    }
                }
                else if (allCommandModels[i].MatchedWithTimeTable == false &&
                    nonChecked == true)
                {//未筛选的可能有上下行未知的情况
                    if ((allCommandModels[i].upOrDown == 0 && up == true) ||
                    (allCommandModels[i].upOrDown == 1 && down == true))
                    {
                        if ((allCommandModels[i].psngerTrain == true && psnger == true) ||
                            (allCommandModels[i].psngerTrain == false && nonPsnger == true))
                        {
                            _tempCM.Add(allCommandModels[i]);
                        }
                    }
                    else if(allCommandModels[i].upOrDown == -1)
                    {
                        if ((allCommandModels[i].psngerTrain == true && psnger == true) ||
                        (allCommandModels[i].psngerTrain == false && nonPsnger == true))
                        {
                            _tempCM.Add(allCommandModels[i]);
                        }
                    }
                }

            }
            currentShow_lbl.Text = _tempCM.Count.ToString();
            data_lv.Items.Clear();
            data_lv.BeginUpdate();
            for (int j = 0; j < _tempCM.Count; j++)
            {
                ListViewItem _lvi;
                if(_tempCM[j].trainIndex != null && _tempCM[j].trainIndex.Length != 0)
                {
                    _lvi = new ListViewItem(_tempCM[j].trainIndex);
                }
                else
                {
                    _lvi = new ListViewItem("—");
                }
                if (_tempCM[j].MatchedWithTimeTable)
                {
                    _lvi.SubItems.Add("√是");
                }
                else
                {
                    _lvi.SubItems.Add("×否");
                }
                if (_tempCM[j].trainNumber != null && _tempCM[j].trainNumber.Length != 0)
                {
                    _lvi.SubItems.Add(_tempCM[j].trainNumber);
                }
                else
                {
                    _lvi.SubItems.Add("—");
                }

                if (_tempCM[j].secondTrainNumber != null && _tempCM[j].secondTrainNumber.Length != 0)
                {
                    if (_tempCM[j].secondTrainNumber.Trim().Contains("null"))
                    {
                        _lvi.SubItems.Add("无");
                    }
                    else
                    {
                        _lvi.SubItems.Add(_tempCM[j].secondTrainNumber);
                    }
                }
                else
                {
                    _lvi.SubItems.Add(" ");
                }

                if(_tempCM[j].upOrDown == 0)
                {
                    _lvi.SubItems.Add("上行");
                }
                else if(_tempCM[j].upOrDown == 1)
                {
                    _lvi.SubItems.Add("下行");
                }
                else
                {
                    _lvi.SubItems.Add(" ");
                }

                if (_tempCM[j].psngerTrain)
                {
                    _lvi.SubItems.Add("载客");
                }
                else
                {
                    _lvi.SubItems.Add("其他");
                }

                if (_tempCM[j].trainModel != null && _tempCM[j].trainModel.Length != 0)
                {
                    _lvi.SubItems.Add(_tempCM[j].trainModel);
                }
                else
                {
                    _lvi.SubItems.Add(" ");
                }

                if (_tempCM[j].trainId != null && _tempCM[j].trainId.Length != 0)
                {
                    _lvi.SubItems.Add(_tempCM[j].trainId);
                }
                else
                {
                    _lvi.SubItems.Add(" ");
                }

                data_lv.Items.Add(_lvi);

            }
            data_lv.EndUpdate();
        }

        private void up_cb_CheckedChanged(object sender, EventArgs e)
        {
            refreshList(up_cb.Checked, down_cb.Checked, psngerTrain_cb.Checked, nonPsngerTrain_cb.Checked, checked_cb.Checked, nonChecked_cb.Checked);
        }

        private void down_cb_CheckedChanged(object sender, EventArgs e)
        {
            refreshList(up_cb.Checked, down_cb.Checked, psngerTrain_cb.Checked, nonPsngerTrain_cb.Checked, checked_cb.Checked, nonChecked_cb.Checked);
        }

        private void psngerTrain_cb_CheckedChanged(object sender, EventArgs e)
        {
            refreshList(up_cb.Checked, down_cb.Checked, psngerTrain_cb.Checked, nonPsngerTrain_cb.Checked, checked_cb.Checked, nonChecked_cb.Checked);
        }

        private void nonPsngerTrain_cb_CheckedChanged(object sender, EventArgs e)
        {
            refreshList(up_cb.Checked, down_cb.Checked, psngerTrain_cb.Checked, nonPsngerTrain_cb.Checked, checked_cb.Checked, nonChecked_cb.Checked);
        }

        private void checked_cb_CheckedChanged(object sender, EventArgs e)
        {
            refreshList(up_cb.Checked, down_cb.Checked, psngerTrain_cb.Checked, nonPsngerTrain_cb.Checked, checked_cb.Checked, nonChecked_cb.Checked);
        }

        private void nonChecked_cb_CheckedChanged(object sender, EventArgs e)
        {
            refreshList(up_cb.Checked, down_cb.Checked, psngerTrain_cb.Checked, nonPsngerTrain_cb.Checked, checked_cb.Checked, nonChecked_cb.Checked);
        }
    }
}
