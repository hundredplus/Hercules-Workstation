using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hercules_Workstation
{
    class Station
    {
        String number = null;
        int location_number = 0;
        int process_number = 0;
        int status = 0;
        String project_code = null;

        public static readonly int FREE = 1;
        public static readonly int OCCUPIED = 2;
        public static readonly int NOT_USED = 3;
        public static readonly int RESERVED = 4;

        public string Number { get => number; set => number = value; }
        public int Location_number { get => location_number; set => location_number = value; }
        public int Process_number { get => process_number; set => process_number = value; }
        public int Status { get => status; set => status = value; }
        public string Project_code { get => project_code; set => project_code = value; }
    }
}
