using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Models
{
    public class Risk_Criteria
    {
        public Likelihoods likelihoods {  get; set; }
        public Severitys severitys { get; set; }
        public Intersections intersections { get; set; }
        public Risk_Rankings risk_Rankings { get; set; }

    }
}
