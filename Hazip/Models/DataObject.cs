using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Models
{
    public class DataObject
    {
        public Overview Overview { get; set; }
        public Settings Settings { get; set; }
        public List<Team_Members> TeamMembers { get; set; }
        public List<Sessions> Sessions { get; set; }
        public List<Team_Members_Sessions> TeamMembers_Sessions { get; set; }

        public List<Revalidation_History> Revalidation_History { get; set; }
        public List<Nodes> Nodes { get; set; }
        public List<Safeguards> Safeguards { get; set; }
        public List<Pha_Recommendations> Pha_Recommendations { get; set;}
        public List<Pha_Comments> Pha_Comments { get; set; }
        public List<Lopa_Recommendations> lopa_Recommendations { get; set; }
        public  List<Lopa_Comments> Lopa_Comments { get; set; }
        public  List<Parking_Lot> Parking_Lot { get; set; }

        public List<Drawings> Drawings { get; set; }  
        public Risk_Criteria Risk_Criteria { get; set; }
        public List<Risk_Rankings> Risk_Rankings { get; set;}
        public List<CheckList> CheckList { get; set; }
        public List<Check_List_Recommendations> CheckList_Recommendations { get; set;}

    }
}
