using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTableAutoCompleteTool
{
    [Serializable()]
    class TrainProjectModel
    {
        /*1. 钩计划模型
        钩号（及先发现的重联单编车钩号）
        钩号B（后发现的重联单编车钩号）
        入库：{
        入库车次
        入库时间
        入库动车走行线
        }
        车型
        车号1
        车号2
        车辆状态（0短编 1长编 2重联）
        编组作业：0-不变，1-重联作业，2-解编作业，3-相同车
        相同车（重联车）钩号
        开始时间/结束时间
        前序钩
        后序钩
        List<作业模型>钩内作业
        出库：{
        出库车次
        出库时间
        出库动车走行线
        }
        
        备注
        原文信息
        */
        //第几钩
        public string projectIndex { get; set; }
        //钩号B
        public string secondProjectIndex { get; set; }
        //入库
        public string getInside_trainNum { get; set; }
        public string getInside_track { get; set; }
        public string getInside_time { get; set; }
        //车型
        public string trainModel { get; set; }
        //车号
        public string trainId { get; set; }
        public string secondTrainId { get; set; }
        //短-长-8+8（0,1,2）
        public int trainConnectType { get; set; }
        //编组作业 0不变 1短变长 2长变短 3有重复车
        public int trainWorkingMode { get; set; }
        //不仅仅是同车，也是单组车被包含的重联车所在钩
        public string sameTrain_ProjectIndex { get; set; }
        
        //该钩开始的时间和结束的时间
        public string startTime { get; set; }
        public string endTime { get; set; }

        //存储前序节点与后序节点
        public List<TrainProjectStruct> previousProject { get; set; }
        public List<TrainProjectStruct> nextProject { get; set; }

        //        public List<TrainProjectModel> connectedTrainProjectModels { get; set; }
        public List<TrainProjectWorking> trainProjectWorkingModel { get; set; }

        //出库
        public string getOutside_trainNum { get; set; }
        public string getOutside_track { get; set; }
        public string getOutside_time { get; set; }
        //出库日期
        public string getOutside_day { get; set; }

        public string originalText { get; set; }
        public string tips { get; set; }

        public TrainProjectModel()
        {
            this.projectIndex = "";
            this.secondProjectIndex = "";
            this.getInside_trainNum = "";
            this.getInside_track = "";
            this.getInside_time = "";

            this.trainModel = "";
            this.trainId = "";
            this.secondTrainId = "";
            this.trainConnectType = -1;
            this.trainWorkingMode = -1;

            this.sameTrain_ProjectIndex = "-1";
            this.startTime = "";
            this.endTime = "";
            //this.connectedTrainProjectModels = new List<TrainProjectModel>();
            this.previousProject = new List<TrainProjectStruct>();
            this.nextProject = new List<TrainProjectStruct>();
            this.trainProjectWorkingModel = new List<TrainProjectWorking>();
            this.getOutside_trainNum = "";
            this.getOutside_track = "";
            this.getOutside_time = "";
            this.getOutside_day = "";
            this.originalText = "";
            this.tips = "";
        }
        public object Clone()
        {
            TrainProjectModel _P = new TrainProjectModel();
            _P.projectIndex = this.projectIndex;
            _P.secondProjectIndex = this.secondProjectIndex;
            _P.getInside_trainNum = this.getInside_trainNum;
            _P.getInside_track = this.getInside_track;
            _P.getInside_time = this.getInside_time;

            _P.trainModel = this.trainModel;
            _P.trainId = this.trainId;
            _P.secondTrainId = this.secondTrainId;
            _P.trainConnectType = this.trainConnectType;
            _P.trainWorkingMode = this.trainWorkingMode;

            _P.sameTrain_ProjectIndex = this.sameTrain_ProjectIndex;
            _P.startTime = this.startTime;
            _P.endTime = this.endTime;
            _P.previousProject = new List<TrainProjectStruct>();
            _P.nextProject = new List<TrainProjectStruct>();
            //_P.connectedTrainProjectModels = this.connectedTrainProjectModels;
            _P.trainProjectWorkingModel = new List<TrainProjectWorking>();
            _P.getOutside_trainNum = this.getOutside_trainNum;
            _P.getOutside_track = this.getOutside_track;
            _P.getOutside_time = this.getOutside_time;
            _P.getOutside_day = this.getOutside_day;

            _P.originalText = this.originalText;
            _P.tips = this.tips;
            return _P as object;//深复制
        }
    }
}
