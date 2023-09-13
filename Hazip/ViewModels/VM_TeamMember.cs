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
            AddCommand = new RelayCommand(AddMember);
            RemoveCommand = new RelayCommand(RemoveMember);
            EditCommand = new RelayCommand(EditSiswa);
        }
        #endregion

        #region Property
        private Team_Members selectedMember;
        private ObservableCollection<Team_Members> listTeamMember;
       /* public ObservableCollection<Team_Members> listTeamMember
        {
            get => _ListTeamMember;
            set => SetProperty(ref _ListTeamMember, value);
        }
        private ObservableCollection<Team_Members> _ListTeamMember = new ObservableCollection<Team_Members>();
*/
        public ObservableCollection<Team_Members> ListTeamMember
        {
            get { return listTeamMember; }
            set { listTeamMember = value; OnPropertyChanged(); App.dataObject.Team_Members = listTeamMember.ToList(); }
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
        private void AddMember()
        {
            Team_Members newMember = new Team_Members();
            listTeamMember.Add(newMember);
            App.dataObject.Team_Members.Add(listTeamMember.Last());
            SelectedMember = newMember;
        }

        private void RemoveMember()
        {
            if (SelectedMember != null)
            {
                Team_Members selectedTempMember = SelectedMember;
                ListTeamMember.Remove(selectedTempMember);
                App.dataObject.Team_Members.Remove(selectedTempMember);
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
