using Hazip.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Models
{
    public class Team_Members_Sessions
    {
        /*Team_Members_Sessions		[18]
	0		{4}
ID	:	sr4eza7416mwhttrswhgfl
Team_Member_ID	:	3512t4obhi95jbhlmususm
Session_ID	:	v6bo7zfvkd8ndn65pf3kwk
Value	:	Present
*/

        public string ID { get; set; } = IdGenerator.GenerateId();
        public string ? Team_Member_ID { get; set; }
        public string ? Session_ID { get; set; }
        public string ? Value { get; set;}
    }
}
