using Hazip.Models;
using Hazip.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.ViewModels
{
    class RiskCriteriaVM : ViewModelBase
    {
        private readonly PageModel _pageModel;

        public RiskCriteriaVM()
        {
            _pageModel = new PageModel();
            VM_RiskMatrix vM_OverView = new VM_RiskMatrix();
        }

    }
}
