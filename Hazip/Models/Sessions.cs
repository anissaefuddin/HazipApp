using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Models
{
    public class Sessions
    {
        /*ID	:	td1ki31ho2o4mkdwnoonlm
Date	:	09/01/2023
Duration	:	2
Session	:	3
Facilitator_ID	:	do9xnm2r4rievgx9vcofpj
Scribe_ID	:	do9xnm2r4rievgx9vcofpj
Session_Comments	:	
*/
        public string ID { get; set; }
        public string Date { get; set; }
        public string Duration { get; set; }

        public string Session { get; set; }
        public string Facilitator_ID { get; set; }
        public string Scribe_ID { get; set; }
        public string Session_Comments { get; set; }
    }
}
