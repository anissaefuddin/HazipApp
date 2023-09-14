using Hazip.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Models
{
    public class CheckList
    {
        public string ID { get; set; } = IdGenerator.GenerateId();
        public string ? CheckList_Description { get; set; }
        public string ? CheckList_Comments { get; set; }
        public List<Check_List_Questions> Check_List_Questions { get; set; }
    }
}
