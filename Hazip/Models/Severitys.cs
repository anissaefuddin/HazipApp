using Hazip.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Models
{
   public class Severitys
    {
        /*Severities		[25]
	0		{5}
ID	:	0dup8drel3dsidu4k76f7x
Severity_Type	:	Safety
RM_Description	:	Catastrophic
RM_Tmel	:	1E-5
Code	:	5
*/
        public string ID { get; set; } = IdGenerator.GenerateId();
        public SaverityType? Severity_Type { get; set; }
        public string ? RM_Description { get; set; }
        public string ? RM_Tmel { get; set; }
        public string ? Code { get; set; }


    }
}
