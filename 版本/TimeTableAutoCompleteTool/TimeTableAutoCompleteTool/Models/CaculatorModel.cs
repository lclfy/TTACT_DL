using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTableAutoCompleteTool
{
    public class CaculatorModel
    {
        public string trainNumber { get; set; }
        public string shouldArriveTime { get; set; }
        public string actuallyArriveTime { get; set; }
        public string shouldStartTime { get; set; }
        public string actuallyStartTime { get; set; }
        public int earlyTime { get; set; }
    }
}
