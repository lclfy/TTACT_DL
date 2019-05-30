using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTableAutoCompleteTool
{
    public class CommandModel
    {
        //第几行
        public string trainIndex { get; set; }
        //车次号，停运状态(0停开，1开行，2次日)，高峰临客
        public string trainNumber { get; set; }
        public string secondTrainNumber { get; set; }
        public int streamStatus { get; set; }
        //0为普通-1为高峰-2为临客-3为周末-有的再加
        public int trainType { get; set; }
        //车型
        public string trainModel { get; set; }
        //车号
        public string trainId { get; set; }
        //短-长-8+8（0,1,2）
        public int trainConnectType { get; set; }
        //上0-下行1
        public int upOrDown { get; set; }
        //判断是否匹配上时刻表车次
        public bool MatchedWithTimeTable { get; set; }
        //列车类型-1旅客列车-0其他列车
        public bool psngerTrain { get; set; }

        public CommandModel()
        {
            upOrDown = -1;
        }
        
    }
}
