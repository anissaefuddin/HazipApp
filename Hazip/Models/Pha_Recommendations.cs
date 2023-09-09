using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Models
{
    public class Pha_Recommendations
    {
        /*Pha_Recommendations		[6]
	0		{6}
ID	:	wugatq6yoe8xws6yy165ah
Pha_Recommendation	:	Install venting line on downstream High Pressure Gas Filter
Pha_Recommendation_Priority	:	High
Pha_Recommendation_Responsible_Party	:	
Pha_Recommendation_Status	:	null
Pha_Recommendation_Comments	:	*/

        public string ID {  get; set; }
        public string Pha_Recommendation { get; set; }
        public string Pha_Recommendation_Priority { get; set; }
        public string Pha_Recommendation_Responsible_Party { get; set; }
        public string Pha_Recommendation_Status { get; set; }
        public string Pha_Recommendation_Comments { get; set; }
    }
}
