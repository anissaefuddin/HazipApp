using Hazip.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Models
{
    public class Pha_Comments
    {
        /*ID	:	9ta9y5uioyuxwsj194aat
Pha_Comment	:	Siloxane study still on going
*/
        public string ID { get; set; } = IdGenerator.GenerateId();
        public string ? Pha_Comment { get; set; }
    }
}
