using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTableAutoCompleteTool.Models
{
    class TrainProjectSortModel : IComparable<TrainProjectSortModel>, ICloneable
    {
        //作业模型
        /*1.1 作业模型：
         * 编号
         * 入库车次
         * 出库车次
         * 车型
        停放位置（股道）
        排序需要用到的白班夜班参数
        钩号
        途径股道
        到达时间
        作业内容
        重联车号A
        重联车号B
        原文信息
        */
        public int id { get; set; }
        public string getInside_trainNum { get; set; }
        public string getOutside_trainNum { get; set; }
        public string trainModel { get; set; }
        public string track { get; set; }
        public int morningOrNight { get; set; }
        public string projectIndex { get; set; }
        public string throughTrack { get; set; }
        public string time { get; set; }
        public string workingInformation { get; set; }
        public string trainNumA { get; set; }
        public string trainNumB { get; set; }
        public string originalText { get; set; }
        public string tips { get; set; }

        public TrainProjectSortModel()
        {
            this.id = -1;
            this.getInside_trainNum = "";
            this.getOutside_trainNum = "";
            this.trainModel = "";
            this.track = "";
            this.throughTrack = "";
            this.time = "";
            this.workingInformation = "";
            this.trainNumA = "";
            this.morningOrNight = -1;
            this.trainNumB = "";
            this.originalText = "";
            this.tips = "";
        }

        public object Clone()
        {
            TrainProjectSortModel _w = new TrainProjectSortModel();
            _w.id = this.id;
            _w.getInside_trainNum = this.getInside_trainNum;
            _w.getOutside_trainNum = this.getOutside_trainNum;
            _w.trainModel = this.trainModel;
            _w.track = this.track;
            _w.throughTrack = this.throughTrack;
            _w.projectIndex = this.projectIndex;
        _w.time = this.time;
            _w.morningOrNight = this.morningOrNight;
            _w.workingInformation = this.workingInformation;
            _w.trainNumA = this.trainNumA;
            _w.trainNumB = this.trainNumB;
            _w.originalText = this.originalText;
            _w.tips = this.tips;
            return _w as object;//深复制
        }

        public int CompareTo(TrainProjectSortModel other)
        {
            if (other == null)
            {
                return 0;
            }
            string thisStartedTime = "";
            string otherStartedTime = "";
            if (time.Length == 0 || time == null)
            {
                thisStartedTime = "-1";
            }
            else
            {
                thisStartedTime = time.Replace(":", "");
            }

            if (other.time.Length == 0 || other.time == null)
            {
                otherStartedTime = "-1";
            }
            else
            {
                otherStartedTime = other.time.Replace(":", "");
            }
            int StartedTimeInt = -1;
            int OtherStartedTimeInt = -1;
            int.TryParse(thisStartedTime, out StartedTimeInt);
            int.TryParse(otherStartedTime, out OtherStartedTimeInt);
            if (this.morningOrNight == 0)
            {//白班 8点开始
                if (StartedTimeInt != -1 &&
                    StartedTimeInt < 800)
                {
                    StartedTimeInt = StartedTimeInt + 2400;
                    thisStartedTime = StartedTimeInt.ToString();
                }

                if (OtherStartedTimeInt != -1 &&
                    OtherStartedTimeInt < 800)
                {
                    OtherStartedTimeInt = OtherStartedTimeInt + 2400;
                    otherStartedTime = OtherStartedTimeInt.ToString();
                }
            }
            else if(this.morningOrNight == 1)
            {
                if (StartedTimeInt != -1 &&
                     StartedTimeInt < 1600)
                {
                    StartedTimeInt = StartedTimeInt + 2400;
                    thisStartedTime = StartedTimeInt.ToString();
                }
                if (OtherStartedTimeInt != -1 &&
                    OtherStartedTimeInt < 1600)
                {
                    OtherStartedTimeInt = OtherStartedTimeInt + 2400;
                    otherStartedTime = OtherStartedTimeInt.ToString();
                }
            }

            char[] arr1 = thisStartedTime.ToCharArray();
            char[] arr2 = otherStartedTime.ToCharArray();
            int i = 0, j = 0;
            while (i < arr1.Length && j < arr2.Length)
            {
                if (char.IsDigit(arr1[i]) && char.IsDigit(arr2[j]))
                {
                    string s1 = "", s2 = "";
                    while (i < arr1.Length && char.IsDigit(arr1[i]))
                    {
                        s1 += arr1[i];
                        i++;
                    }
                    while (j < arr2.Length && char.IsDigit(arr2[j]))
                    {
                        s2 += arr2[j];
                        j++;
                    }
                    if (int.Parse(s1) > int.Parse(s2))
                    {
                        return 1;
                    }
                    if (int.Parse(s1) < int.Parse(s2))
                    {
                        return -1;
                    }
                }
                else
                {
                    if (arr1[i] > arr2[j])
                    {
                        return 1;
                    }
                    if (arr1[i] < arr2[j])
                    {
                        return -1;
                    }
                    i++;
                    j++;
                }
            }
            if (arr1.Length == arr2.Length)
            {
                return 0;
            }
            else
            {
                return arr1.Length > arr2.Length ? 1 : -1;
            }
            throw new NotImplementedException();
        }
    }
}
