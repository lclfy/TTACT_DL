using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTableAutoCompleteTool
{
    class basicTrainGraphTitle
    {
        public List<int> titleRow { get; set; }
        public int idColumn { get; set; }
        public int trainNumColumn { get; set; }
        public int startStationColumn { get; set; }
        public int stopStationColumn { get; set; }
        public int stopTimeColumn { get; set; }
        public int startTimeColumn { get; set; }
        public int stopToStartTimeCountColumn { get; set; }
        public int trackNumColumn { get; set; }
        public int trainConnectTypeColumn { get; set; }
        public int trainModelColumn { get; set; }
        public int trainBelongsToColumn { get; set; }
        public int ratedSeatsColumn { get; set; }
        public int extraTextColumn { get; set; }
        public int tipsColumn { get; set; }
    }
}
