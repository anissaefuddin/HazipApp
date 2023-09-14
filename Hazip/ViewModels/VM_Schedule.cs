using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hazip.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Hazip.ViewModels
{
    public class VM_Schedule : ObservableObject
    {



        public VM_Schedule() 
        {
            //loadDataTeamMember();
            WidthTable = 600;
            //AddCommand = new RelayCommand(AddMember);
            //RemoveCommand = new RelayCommand(RemoveMember);
            //PrintCommand = new RelayCommand(PrintToExcel);
            //MoveUpCommand = new RelayCommand(MoveUp);
            //MoveDownCommand = new RelayCommand(MoveDown);
            //ZoomInCommand = new RelayCommand(ZoomIn);
            //ZoomOutCommand = new RelayCommand(ZoomOut);

            _collectionView = CollectionViewSource.GetDefaultView(listTeamMember);
            //_collectionView.Filter = FilterData;
        }


        #region Property

        public ICommand AddCommand { get; private set; }
        public ICommand ZoomInCommand { get; private set; }
        public ICommand ZoomOutCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }
        public ICommand PrintCommand { get; private set; }
        public ICommand MoveUpCommand { get; }
        public ICommand MoveDownCommand { get; }



        private Team_Members _selectedData;
        private int _widthTable;
        private ObservableCollection<Team_Members> listTeamMember;
        private string _searchText;
        private ICollectionView _collectionView;

        public int WidthTable
        {
            get => _widthTable;
            set
            {
                SetProperty(ref _widthTable, value);
            }
        }

        #endregion



        #region Method

        /*
        private void loadDataTeamMember()
        {
            var appData = App.dataObject.Team_Members;
            if (appData != null)
            {
                ListTeamMember = new ObservableCollection<Team_Members>(appData);
            }
        }

        private void AddMember()
        {
            Team_Members newMember = new Team_Members();
            listTeamMember.Add(newMember);
            App.dataObject.Team_Members.Add(listTeamMember.Last());
            SelectedData = newMember;
        }

        private void RemoveMember()
        {
            if (SelectedData != null)
            {
                Team_Members selectedTempMember = SelectedData;
                ListTeamMember.Remove(selectedTempMember);
                App.dataObject.Team_Members.Remove(selectedTempMember);
                SelectedData = new Team_Members();
            }
            else
            {
                MessageBox.Show("Please select data first!");
            }
        }
        */

        #endregion

    }
}
