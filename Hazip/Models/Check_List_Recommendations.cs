using Hazip.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Models
{
    public class Check_List_Recommendations
    {
        /*Check_List_Recommendations		[1]
	0		{6}
ID	:	empty
Check_List_Recommendation	:	
Check_List_Recommendation_Priority	:	null
Check_List_Recommendation_Responsible_Party	:	
Check_List_Recommendation_Status	:	null
Check_List_Recommendation_Comments	:*/
        public string ID { get; set; } = IdGenerator.GenerateId();
        public string ? Check_List_Recommendation { get; set; }
        public string ? Check_List_Recommendation_Priority { get; set; }
        public string ? Check_List_Recommendation_Responsible_Party { get; set; }
        public string ? Check_List_Recommendation_Status { get; set; }
        public string ? Check_List_Recommendation_Comments { get; set; }

    }
}
