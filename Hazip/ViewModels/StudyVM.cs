using Hazip.Models;
using Hazip.Utilities;
using Hazip.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hazip.ViewModels
{
    class StudyVM : ViewModelBase
    {
        private readonly PageModel _pageModel;

        public StudyVM()
        {
            _pageModel = new PageModel();
           VM_OverView vM_OverView = new VM_OverView();

        }

    }
}
