using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Models
{
    public class Nodes
    {
        /*ID	:	ci6ecne74w102qniwvay9
Node_Description	:	Facility
Intention	:	
Boundary	:	Gas Transport Module\nHigh Pressure Gas Filter\nBuffer Tank
Design_Conditions	:	Mobile GTM\nFlowrate: 4000Nm3/hr\n\nBuffer Tank\nDesign pressure: 21 Barg\nDesign temperature: 150degF
Operating_Conditions	:	Mobile GTM &amp; High Pressure Gas Filter\nFlowrate: 4000Nm3/hr\nOpt.Pressure: 250barg\nOpt.Temperature: 85degF\n\nBuffer Tank\nOpt. Pressure: 2 (min)/10 barg (max)\nOpt. Temperature: 66.5degF
Node_Color	:		RED
Hazardous_Materials	:	
Equipment_Tags	:	
Location	:	
Node_Comments	:	
*/
        public string ID { get; set; }
        public string Node_Description { get; set; }
        public string Intention { get; set; }
        public string Boundary { get; set; }
        public string Design_Conditions { get; set; }
        public string Operating_Conditions { get; set; }
        public string Node_Color { get; set; }
        public string Hazardous_Materials { get; set; }
        public string Equipment_Tags { get; set; }
        public string Location { get; set; }
        public string Node_Comments { get; set; }
    }
}
