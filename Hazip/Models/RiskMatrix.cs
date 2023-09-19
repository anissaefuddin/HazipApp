using Hazip.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Models
{
    public class RiskMatrix
    {
        public string ID { get; set; } 
        public string Severity_ID { get; set; }
        public string Likelihood_ID { get; set; }
        public string Risk_Rank_ID { get; set; }
        public Risk_Rankings Risk_Ranking { get; set;}
        public Severitys Severity { get; set; }
        public Likelihoods Likelihood { get; set; }
    }
}
