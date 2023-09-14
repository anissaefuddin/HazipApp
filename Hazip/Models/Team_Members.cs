using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Models
{
    public class Team_Members
    {
        /*ID	:	do9xnm2r4rievgx9vcofpj
Name	:	Ipung
Company	:	RDS
Title	:	SMKO
Department	:	RnD
Expertise	:	
Experience	:	
Phone_Number	:	
E__Mail_Address	:	
Team_Member_Comments	:	
*/
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string ? Name { get; set; }
        public string ? Company { get; set; }
        public string ? Title { get; set; }
        public string ? Department { get; set; }
        public string ? Expertise { get; set; }
        public string ? Experience { get; set; }
        public string ? Phone_Number { get; set; }
        public string ? E__Mail_Address { get; set; }
        public string ? Team_Member_Comments { get; set; }

    }
}
