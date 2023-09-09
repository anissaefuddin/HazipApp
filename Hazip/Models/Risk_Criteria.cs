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
        public List<Likelihoods> likelihoods {  get; set; }
        public List<Severitys> severitys { get; set; }
        public List<Intersections> intersections { get; set; }
        public List<Risk_Rankings> risk_Rankings { get; set; }

    }
}
