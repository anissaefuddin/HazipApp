using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Models
{
    public class Lopa_Recommendations
    {
        /*Lopa_Recommendations		[1]
	0		{6}
ID	:	empty
Lopa_Recommendation	:	
Lopa_Recommendation_Priority	:	null
Lopa_Recommendation_Responsible_Party	:	
Lopa_Recommendation_Status	:	null
Lopa_Recommendation_Comments	:	*/
        public string ID { get; set; }
        public string Lopa_Recommendation { get; set; }
        public string Lopa_Recommendation_Priority { get; set; }
        public string Lopa_Recommendation_Responsible_Party { get; set; }
        public string Lopa_Recommendation_Status { get; set; }
        public string Lopa_Recommendation_Comments { get; set; }

    }
}
