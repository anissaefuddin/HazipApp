using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hazip.Utilities;
using Hazip.ViewModels;
using System.Windows.Input;

namespace Hazip.ViewModels
{
    class NavigationVM : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand NodesCommand { get; set; }
        public ICommand ProductsCommand { get; set; }
        public ICommand GuideWordCommand { get; set; }
        public ICommand OrdersCommand { get; set; }
        public ICommand TransactionsCommand { get; set; }
        public ICommand ShipmentsCommand { get; set; }
        public ICommand RiskCriteriaCommand { get; set; }

        private void Home(object obj) => CurrentView = new StudyVM();
        private void Nodes(object obj) => CurrentView = new VM_Nodes();
        private void Product(object obj) => CurrentView = new ProductVM();
        private void GuideWord(object obj) => CurrentView = new VM_GuideWord();
        private void Order(object obj) => CurrentView = new OrderVM();
        private void Transaction(object obj) => CurrentView = new TransactionVM();
        private void Shipment(object obj) => CurrentView = new ShipmentVM();
        private void RiskCriteria(object obj) => CurrentView = new RiskCriteriaVM();

        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            NodesCommand = new RelayCommand(Nodes);
            GuideWordCommand = new RelayCommand(GuideWord);
            ProductsCommand = new RelayCommand(Product);
            OrdersCommand = new RelayCommand(Order);
            TransactionsCommand = new RelayCommand(Transaction);
            ShipmentsCommand = new RelayCommand(Shipment);
            RiskCriteriaCommand = new RelayCommand(RiskCriteria);

            // Startup Page
            CurrentView = new StudyVM();
        }
    }
}
