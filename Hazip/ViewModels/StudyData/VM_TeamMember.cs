using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hazip.Models;
using System.Collections.ObjectModel;

namespace Hazip.ViewModels.StudyData
{
    public class VM_TeamMember : ObservableObject
    {
        #region Constructor
        public VM_TeamMember() 
        {
            loadDataTeamMember();
        }
        #endregion

        #region Property

        public ObservableCollection<Team_Members> ListTeamMeber
        {
            get => _ListTeamMember;
            set => SetProperty(ref _ListTeamMember, value);
        } 
        private ObservableCollection<Team_Members> _ListTeamMember = new ObservableCollection<Team_Members>();

        #endregion


        #region Method
        private void loadDataTeamMember()
        {

        }
        #endregion

    }
}
