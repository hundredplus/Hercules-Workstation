using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hercules_Workstation
{
    class Production
    {
        String prodCode = null;
        int serialNo;
        String prodMarkingCode = null;
        String tableNo = null;
        String projectCode = null;
        int current_loc_number;
        int processNo;
        int status;
        int workType;

        /*
        public static readonly int NEW = 1; //WHEN LOAD
        public static readonly int IN_PROGRESS = 2; //IN PROGESS AT STATION
        public static readonly int WAITING_STATION = 3; //WAITING TO MOVE AT STATION
        public static readonly int INSPECTING = 4;  //WAITING TO INSPECT
        public static readonly int STORAGE = 5; //IN STORAGE
        public static readonly int COMPLETE = 6; //DONE ALL
        public static readonly int MANUAL = 7; //MANUAL PROCESS
        public static readonly int INSPECTING_AREA = 8; //IN INSPECTING AREA
        public static readonly int INSPECTING_DONE = 9; //DONE INSPECTING
        public static readonly int IN_TRANSIT = 10; // MOVING WITH AGV
        */
        public static readonly int NEW = 1; //When loaded
        public static readonly int COMPLETE = 2; //Production done
        public static readonly int MANUAL = 3; //Manual process
        public static readonly int IN_PROGRESS = 4; //in progress at station
        public static readonly int IN_TRANSIT = 5; //moving with AGV
        public static readonly int STORAGE = 6; //in storage area
        public static readonly int INSPECTED = 7; //inspecting done and at inspect area
        public static readonly int WAIT_STATION = 8; //in station and wait to move
        public static readonly int INSPECT_REQ = 9; //happen when worker press INSPECT button
        public static readonly int INSPECT_STATION = 10; //in station and wait to inspect
        public static readonly int INSPECT_STORAGE = 11; //in inspect area and wait to inspect
        public static readonly int INSPECTING_STATION = 12; //Calling inspector for inspecting at station
        public static readonly int INSPECTING_STORAGE = 13; //Calling inspector for inspecting at storage




        public int SerialNo { get => serialNo; set => serialNo = value; }
        public string ProdMarkingCode { get => prodMarkingCode; set => prodMarkingCode = value; }
        public string TableNo { get => tableNo; set => tableNo = value; }
        public string ProjectCode { get => projectCode; set => projectCode = value; }
        public string ProdCode { get => prodCode; set => prodCode = value; }
        public int Current_loc_number { get => current_loc_number; set => current_loc_number = value; }
        public int ProcessNo { get => processNo; set => processNo = value; }
        public int Status { get => status; set => status = value; }
        public int WorkType { get => workType; set => workType = value; }
    }
}
