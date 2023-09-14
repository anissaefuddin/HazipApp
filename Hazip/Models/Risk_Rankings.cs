using Hazip.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Models
{
    public class Risk_Rankings
    {
        /*ID	:	eg915bk7z7bdzc2tbxq107
RM_Description	:	High
Code	:	5
Color	:	hsv(0, 100%, 100%)
Priority	:	1
Required_Lopa_Credits	:	3*/
        public string ID { get; set; } = IdGenerator.GenerateId();
        public string ? RM_Description { get; set; }
        public string ? Code { get; set; }
        public string ? Color { get; set; }
        public string ? Priority { get; set; }
        public string ? Required_Lopa_Credits { get; set; }
    }
}
