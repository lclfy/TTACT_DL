using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTableAutoCompleteTool
{
    class EMUCheckModel : IComparable<EMUCheckModel>
    {//动检车模型
        public int id { get; set; }
        public string extra { get; set; }
        public string startStation { get; set; }
        public string trainNumber { get; set; }
        public string stopTime { get; set; }
        public string trackNum { get; set; }
        public string startTime { get; set; }
        public string destination { get; set; }
        public int streamStatus { get; set; }

        public int CompareTo(EMUCheckModel other)
        {
            if (other == null || id == other.id)
            {
                return 0;
            }
            if(id > other.id)
            {
                return 1;
            }
            else
            {
                return -1;
            }
            throw new NotImplementedException();
        }
    }



}
