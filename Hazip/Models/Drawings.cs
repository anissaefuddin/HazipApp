using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Models
{
    public class Drawings
    {
        /*Drawings		[5]
	0		{6}
ID	:	up45o0ly08snso6yfgvqvg
Drawing	:	IJPGD-DET-04-PS-DG-004 SHEET 01 OF 02
Revision	:	0
Document_Type	:	DRAWING P&amp;ID
Drawing_Description	:	PIPING &amp; INSTRUMENTATION DIAGRAM PROCESS
Link	:*/
        public string ID { get; set; }
        public string Name { get; set; }
        public string Drawing { get; set; }
        public string Document_Type { get; set; }
        public string Drawing_Description { get; set; }
        public string Link { get; set; }

    }
}
