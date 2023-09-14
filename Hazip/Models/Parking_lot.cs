using Hazip.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Models
{
    public class Parking_Lot
    {
        /*Parking_Lot		[1]
	0		{6}
ID	:	empty
Parking_Lot_Issue	:	
Response	:	
Responsible_Party	:	
Start_Date	:	
End_Date	:	
*/
        public string ? ID {  get; set; } = IdGenerator.GenerateId();
        public string ? Parking_Lot_Issue { get; set; }
        public string ? Response { get; set; }
        public string ? Responsible_Party { get; set; }
        public string ? Start_Date { get; set; }
        public string ? End_Date { get; set; }


    }
}
