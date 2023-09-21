using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Utilities
{
    public class StatusList : List<String>
    {
        public StatusList() {
            this.Add("true");
            this.Add("false");
        }
    }
}
