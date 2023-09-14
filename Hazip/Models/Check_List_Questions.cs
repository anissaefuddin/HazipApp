using Hazip.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Models
{
    public class Check_List_Questions
    {
        /*ID	:	empty
Check_List_Question	:	
Check_List_Answer	:	null
Check_List_Justification	:	
	Check_List_Recommendation_IDs		[1]
	0		{1}
ID	:	empty
	Safeguard_IDs		[1]
	0		{1}
ID	:	empty
*/
        public string ID { get; set; } = IdGenerator.GenerateId();
        public string ? Check_List_Question { get; set; }

        public string ? Check_List_Answer { get; set; }
        public string ? Check_List_Justification { get; set; }
        public string ? Check_List_Recommendation_IDs { get; set; }

        public List<Recommendation> ? CheckList_Recommendation_IDs { get; set; }
        public List<Safeguard> ? Safeguard_IDs { get; set; }
    }
    public class Recommendation
    {
        public string ID { get; set; } = IdGenerator.GenerateId();
    }

    public class Safeguard
    {
        public string ID { get; set; } = IdGenerator.GenerateId();
    }
}
