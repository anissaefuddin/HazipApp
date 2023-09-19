using CommunityToolkit.Mvvm.ComponentModel;
using Hazip.Models;
using Hazip.Utilities;
using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Hazip.ViewModels
{
    class VM_Attendance : ObservableObject
    {
        public VM_Attendance()
        {
            loadData();
            WidthTable = 600;
            PrintCommand = new RelayCommand(PrintToExcel);
            
        }


        #region Property
        public ICommand PrintCommand { get; private set; }

        private int _widthTable;
        private string _searchText;
        private ICollectionView _collectionView;
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                _collectionView.Refresh();
            }
        }
        public ObservableCollection<Attendances> ListData
        {
            get { return listData; }
            set { listData = value; OnPropertyChanged();  }
        }

        private ObservableCollection<Attendances> listData;
        public ObservableCollection<Team_Members_Sessions> ListDataTeamMemberSession
        {
            get { return _listDataTeamMemberSession; }
            set { _listDataTeamMemberSession = value; OnPropertyChanged(); App.dataObject.Team_Members_Sessions = ListDataTeamMemberSession.ToList(); }
        }

        private ObservableCollection<Team_Members_Sessions> _listDataTeamMemberSession;
        public ObservableCollection<Team_Members> ListDataMembers
        {
            get { return _listDataMembers; }
            set { _listDataMembers = value; }
        }
        private ObservableCollection<Team_Members> _listDataMembers;

        public ObservableCollection<Sessions> ListDataSessions
        {
            get { return _listDataSessions; }
            set { _listDataSessions = value; }
        }
        private ObservableCollection<Sessions> _listDataSessions;

        public int WidthTable
        {
            get => _widthTable;
            set
            {
                SetProperty(ref _widthTable, value);
            }
        }

        public Sessions SelectedData
        {
            get { return _selectedData; }
            set
            {
                SetProperty(ref _selectedData, value);
            }
        }
        private Sessions _selectedData;
        public ObservableCollection<SaverityType> ParameterTypes { get; set; }
        public SaverityType SelectedParameterType
        {
            get { return _selectedParameterType; }
            set
            {
                if (_selectedParameterType != value)
                {
                    _selectedParameterType = value;
                    OnPropertyChanged(nameof(SelectedParameterType));
                }
            }
        }
        private SaverityType _selectedParameterType;

        #endregion



        #region Method


        private void loadData()
        {
            var appData = App.dataObject.Team_Members_Sessions;
            if (appData != null)
            {
                ListDataTeamMemberSession = new ObservableCollection<Team_Members_Sessions>(appData);
                ListDataMembers = new ObservableCollection<Team_Members>(App.dataObject.Team_Members);
                ListDataSessions = new ObservableCollection<Sessions>(App.dataObject.Sessions);
                ListData = new ObservableCollection<Attendances>(ListDataTeamMemberSession.Select(data =>
                {
                    var member = ListDataMembers.FirstOrDefault(s => s.ID == data.Team_Member_ID);
                    var session = ListDataSessions.FirstOrDefault(l => l.ID == data.Session_ID);

                    return new Attendances
                    {
                        ID = data.ID,
                        Session_ID = data.Session_ID,
                        Team_Member_ID = data.Team_Member_ID,
                        team_Members = member,
                        sessions = session
                    };
                }));
            }
        }


        private void PrintToExcel()
        {
            // Membuat dialog Save File
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx|All Files|*.*",
                DefaultExt = ".xlsx",
                FileName = "Schedules - " + App.dataObject.Overview.Study_Name
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                // Membuat package Excel dan worksheet
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Schedules");
                    worksheet.Cells[1, 1].Value = "Date";
                    worksheet.Cells[1, 2].Value = "Duration";
                    worksheet.Cells[1, 3].Value = "Session";
                    worksheet.Cells[1, 4].Value = "Facilitator";
                    worksheet.Cells[1, 5].Value = "Scribe";
                    worksheet.Cells[1, 6].Value = "Comments";
                    // Menulis data dari DataList ke worksheet
                    for (int row = 2; row <= ListData.Count; row++)
                    {
                       /* worksheet.Cells[row, 1].Value = ListData[row - 1].Date;
                        worksheet.Cells[row, 2].Value = ListData[row - 1].Duration;
                        worksheet.Cells[row, 3].Value = ListData[row - 1].Session;
                        worksheet.Cells[row, 4].Value = ListData[row - 1].Facilitator_ID;
                        worksheet.Cells[row, 5].Value = ListData[row - 1].Scribe_ID;
                        worksheet.Cells[row, 6].Value = ListData[row - 1].Session_Comments;*/
                    }

                    // Menyimpan package Excel ke file
                    File.WriteAllBytes(filePath, package.GetAsByteArray());
                }
            }
        }

     

        private void ZoomIn()
        {

            WidthTable = WidthTable + 60;

        }

        private void ZoomOut()
        {

            WidthTable = WidthTable - 60;

        }

        #endregion

    }
}
