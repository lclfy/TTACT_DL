using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTableAutoCompleteTool
{
    class TrainProjectStruct
    {
        //第几钩
        public string projectIndex { get; set; }
        //车号
        public string trainId { get; set; }
        public string secondTrainId { get; set; }
        //短-长-8+8（0,1,2）
        public int trainConnectType { get; set; }
        //用于存储前序钩结束/后序钩开始的时间
        public string relatedMovingTime { get; set; }

        public TrainProjectStruct()
        {
            this.projectIndex = "";
            this.trainId = "";
            this.secondTrainId = "";
            this.trainConnectType = -1;
            this.relatedMovingTime = "";

        }
        public object Clone()
        {
            TrainProjectStruct _P = new TrainProjectStruct();
            _P.projectIndex = this.projectIndex;
            _P.trainId = this.trainId;
            _P.secondTrainId = this.secondTrainId;
            _P.trainConnectType = this.trainConnectType;
            _P.relatedMovingTime = this.relatedMovingTime;
            return _P as object;//深复制
        }
    }
}
