using Hazip.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Models
{
    public class Safeguards
    {
        /*ID	:	m4spoc8ek1tizj3c007q0c
Safeguard	:	Standby PRS System
Safeguard_Type	:	
Safeguard_Independent	:	null
Safeguard_Auditable	:	null
Safeguard_Effective	:	null
Safeguard_Hackable	:	
Is_Safeguard	:	true
Is_Ipl	:	null
Ipl_Tag	:	
Safety_Critical	:	null
Selected_Sil	:	
Required_Response_Time	:	
Test_Interval	:	
Safeguard_Library_Id	:	null
Ipl_Credit	:	
Safeguard_Category	:	
Safeguard_Comments	:	
*/
        public string ID { get; set; } = IdGenerator.GenerateId();
        public string ? Safeguard { get; set; }
        public string ? Safeguard_Type { get; set; }
        public string ? Safeguard_Independent { get; set; }
        public string ? Safeguard_Auditable { get; set; }
        public string ? Safeguard_Effective { get; set; }
        public string ? Safeguard_Hackable { get; set; }
        public string ? Is_Safeguard { get; set; }
        public string ? Is_Ipl { get; set; }
        public string ? Ipl_Tag { get; set; }
        public string ? Safety_Critical { get; set; }
        public string ? Selected_Sil { get; set; }
        public string ? Required_Response_Time { get; set; }
        public string ? Test_Interval { get; set; }
        public string ? Safeguard_Library_Id { get; set; }
        public string ? Ipl_Credit { get; set; }
        public string ? Safeguard_Category { get; set; }
        public string ? Safeguard_Comments { get; set; }
    }
}
