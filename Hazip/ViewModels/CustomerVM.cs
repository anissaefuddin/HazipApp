using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hazip.Models;
using Hazip.Utilities;

namespace Hazip.ViewModels
{
    class CustomerVM : ViewModelBase
    {
        private readonly PageModel _pageModel;
        public int CustomerID
        {
            get { return _pageModel.CustomerCount; }
            set { _pageModel.CustomerCount = value; OnPropertyChanged(); }
        }

        public string StudyName
        {
            get
            {
                if (!string.IsNullOrEmpty(App.dataObject.Overview.Study_Name))
                {
                    _studyName = App.dataObject.Overview.Study_Name;
                }
                return _studyName;
            }
            set 
            { 
                _studyName = value; 
                OnPropertyChanged();
            }
        }
        private string _studyName = string.Empty;
        public ICommand LoadDataCommandOverview { get; private set; }
        public CustomerVM()
        {
            int i = 1;
            _pageModel = new PageModel();
            CustomerID = 100528;
            //loadDataMethod();
        }

        private void loadDataMethod()
        {
            if (App.dataObject.Overview is not null)
            {
                StudyName = App.dataObject.Overview.Study_Name;
            }
        }
    }
}
