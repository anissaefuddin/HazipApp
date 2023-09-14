using Hazip.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Models
{
    public class Deviations
    {
        /*ID	:	7ezl5qer74q2dcxd7zzlr
Deviation	:	Change in Composition/Reaction
Guide_Word	:	
Parameter	:	
Design_Intent	:	
Deviation_Comments	
        Causes*/
        public string ID { get; set; } = IdGenerator.GenerateId();
        public string Deviation { get; set; }
        public string Guide_Word { get; set; }
        public string Parameter { get; set; }
        public string Design_Intent { get; set; }
        public string Deviation_Comments { get; set; }


    }
}
