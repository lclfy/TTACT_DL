using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTableAutoCompleteTool
{
    [Serializable()]
    class TrainProjectWorking
    {//作业模型
        /*1.1 作业模型：
        停放位置（股道）
        途径股道
        到达时间
        作业内容
        重联车号A
        重联车号B
        原文信息
        */
         public string track { get; set; }
        public string throughTrack { get; set; }
         public string time { get; set; }
         public string workingInformation { get; set; }
        public string trainNumA { get; set; }
        public string trainNumB { get; set; }
        public string originalText { get; set; }
        public string tips { get; set; }

        public TrainProjectWorking()
        {
            this.track = "";
            this.throughTrack = "";
            this.time = "";
            this.workingInformation = "";
            this.trainNumA = "";

            this.trainNumB = "";
            this.originalText = "";
            this.tips = "";
        }

        public object Clone()
        {
            TrainProjectWorking _w = new TrainProjectWorking();
            _w.track = this.track;
            _w.throughTrack = this.throughTrack;
            _w.time = this.time;
            _w.workingInformation = this.workingInformation;
            _w.trainNumA = this.trainNumA;
            _w.trainNumB = this.trainNumB;
            _w.originalText = this.originalText;
            _w.tips = this.tips;
            return _w as object;//深复制
        }
    }
}
