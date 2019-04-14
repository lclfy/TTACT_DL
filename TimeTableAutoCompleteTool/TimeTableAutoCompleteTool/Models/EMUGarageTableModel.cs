using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTableAutoCompleteTool
{
    class EMUGarageTableModel
    {
        //第几行
        public int id { get; set; }
        //车次号，停运状态(0停开，1开行，2次日)，高峰临客
        public string trainNumber { get; set; }
        //入库车1 出库车0
        public int isGettingInGarage { get; set; }
        //动车走行线
        public int trackLine { get; set; }
    }
}
