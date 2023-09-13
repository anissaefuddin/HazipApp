using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hazip.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace Hazip.ViewModels
{
    public class VM_TeamMember : ObservableObject
    {
        #region Constructor
        public VM_TeamMember()
        {
            loadDataTeamMember();
            //new RelayCommand<string>(ExecuteMyCommand);
            AddCommand = new RelayCommand<Team_Members>(AddMember);
            RemoveCommand = new RelayCommand<Team_Members>(RemoveMember);
            EditCommand = new RelayCommand(EditSiswa);
        }
        #endregion

        #region Property
        private Team_Members selectedMember;
        private ObservableCollection<Team_Members> listTeamMeber;
       /* public ObservableCollection<Team_Members> ListTeamMeber
        {
            get => _ListTeamMember;
            set => SetProperty(ref _ListTeamMember, value);
        }
        private ObservableCollection<Team_Members> _ListTeamMember = new ObservableCollection<Team_Members>();
*/
        public ObservableCollection<Team_Members> ListTeamMember
        {
            get { return listTeamMeber; }
            set { listTeamMeber = value; OnPropertyChanged(); }
        }

        public Team_Members SelectedMember
        {
            get { return selectedMember; }
            set { selectedMember = value; OnPropertyChanged(); }
        }

        public ICommand AddCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }
        public ICommand EditCommand { get; private set; }


        #endregion


        #region Method
        private void loadDataTeamMember()
        {
            var appData = App.dataObject.Team_Members;
            if (appData != null)
            {
                ListTeamMember = new ObservableCollection<Team_Members>(appData);
            }

        }
        private void AddMember(object parameter)
        {
            Team_Members newMember = new Team_Members();
            listTeamMeber.Add(newMember);
            SelectedMember = newMember;
        }

        private void RemoveMember(object parameter)
        {
            if (SelectedMember != null)
            {
                ListTeamMember.Remove(SelectedMember);
                SelectedMember = null;
            }
        }

        private void EditSiswa()
        {
            // Implement edit logic here
        }

        #endregion

    }
}
