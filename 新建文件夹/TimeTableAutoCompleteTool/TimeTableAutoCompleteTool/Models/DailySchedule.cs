using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TimeTableAutoCompleteTool
{
    class DailySchedule : IComparable<DailySchedule>, ICloneable
    {
        public int id { get; set; }
        public string trainNumber { get; set; }
        public int streamStatus { get; set; }
        public string startStation { get; set; }
        public string stopStation { get; set; }
        public string stopTime { get; set; }
        public string startTime { get; set; }
        //0为普通-1为高峰-2为临客-3为周末-有的再加
        public int trainType { get; set; }
        //1始发 2终到
        public int stopStartStatus { get; set; }
        public string stopToStartTime { get; set; }
        public string trainBelongsTo { get; set; }
        public string trackNum { get; set; }
        //编组
        public string trainConnectType { get; set; }
        //定员
        public string ratedSeats { get; set; }
        public string trainModel { get; set; }
        //备注
        public string extraText { get; set; }
        //新旧交替
        public string tipsText { get; set; }
        public bool hasDifferentPart = false;
        //列车预售时间
        public int presaleTime { get; set; }
        //南1-北0
        public int upOrDown { get; set; }

        //备注里的部分信息
        public bool extraHasDifference { get; set; }
        //1南2北
        public int extra_stoppingPlace { get; set; }
        //始发
        public bool extra_original { get; set; }
        public bool extra_terminal { get; set; }
        //重联
        public bool extra_doubleConnected { get; set; }
        //高峰
        public bool extra_rushHourTrain { get; set; }
        //周末
        public bool extra_weekendTrain { get; set; }
        //反编
        public bool extra_reversedTrain { get; set; }
        //上水
        public bool extra_plugingWater { get; set; }
        //吸污
        public bool extra_unloading { get; set; }



        public DailySchedule()
        {
            id = -1;
            trainNumber = "";
            streamStatus = -1;
            startStation = "";
            stopStartStatus = -1;
            stopStation = "";
            startTime = "";
            stopTime = "";
            trainType = -1;
            stopToStartTime = "";
            trainBelongsTo = "";
            trackNum = "";
            trainConnectType = "";
            ratedSeats = "";
            trainModel = "";
            extraText = "";
            tipsText = "";
            hasDifferentPart = false;
            presaleTime = -1;
            upOrDown = -1;
            extra_stoppingPlace = -1;
        }

        public object Clone()
        {
            DailySchedule _ds = new DailySchedule();
            _ds.id =id;
            _ds.trainNumber = trainNumber;
            _ds.streamStatus = streamStatus;
            _ds.startStation = startStation;
            _ds.stopStartStatus = stopStartStatus;
            _ds.stopStation = stopStation;
            _ds.startTime = startTime;
            _ds.stopTime = stopTime;
            _ds.trainType = trainType;
            _ds.stopToStartTime = stopToStartTime;
            _ds.trainBelongsTo = trainBelongsTo;
            _ds.trackNum = trackNum;
            _ds.trainConnectType = trainConnectType;
            _ds.ratedSeats = ratedSeats;
            _ds.trainModel = trainModel;
            _ds.extraText = extraText;
            _ds.tipsText = tipsText;
            _ds.hasDifferentPart = hasDifferentPart;
            _ds.presaleTime = presaleTime;
            _ds.upOrDown = upOrDown;

            _ds.extraHasDifference = extraHasDifference;
            _ds.extra_doubleConnected = extra_doubleConnected;
            _ds.extra_original = extra_original;
            _ds.extra_plugingWater = extra_plugingWater;
            _ds.extra_reversedTrain = extra_reversedTrain;
            _ds.extra_rushHourTrain = extra_rushHourTrain;
            _ds.extra_stoppingPlace = extra_stoppingPlace;
            _ds.extra_unloading = extra_unloading;
            _ds.extra_weekendTrain = extra_weekendTrain;

            return _ds as object;//深复制
        }

        public int CompareTo(DailySchedule other)
        {
            if (other == null)
            {
                return 0;
            }
            string thisStartedTime = "";
            string otherStartedTime = "";
            if(startTime == null||startTime.Length==0)
            {
                if (stopTime != null||stopTime.Length==0)
                    thisStartedTime = stopTime.Replace(":", "");
            }
            else
            {
                thisStartedTime = startTime.Replace(":", "");
            }

            if (other.startTime == null||other.startTime.Length==0)
            {
                if(other.stopTime != null||other.stopTime.Length==0)
                otherStartedTime = other.stopTime.Replace(":", "");
            }
            else
            {
                otherStartedTime = other.startTime.Replace(":", "");
            }
            int StartedTimeInt = 0;
            int.TryParse(thisStartedTime, out StartedTimeInt);
            if(StartedTimeInt != 0 &&
                StartedTimeInt < 500)
            {
                StartedTimeInt = StartedTimeInt + 2400;
                thisStartedTime = StartedTimeInt.ToString();
            }
            int.TryParse(otherStartedTime, out StartedTimeInt);
            if (StartedTimeInt != 0 &&
                StartedTimeInt < 500)
            {
                StartedTimeInt = StartedTimeInt + 2400;
                otherStartedTime = StartedTimeInt.ToString();
            }
            if(streamStatus == 0)
            {
                thisStartedTime = "0";
            }
            if(other.streamStatus == 0)
            {
                otherStartedTime = "0";
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
