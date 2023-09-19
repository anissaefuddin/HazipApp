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
using Microsoft.Win32;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Information;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows;

namespace Hazip.ViewModels
{
    public class VM_TeamMember : ObservableObject
    {
        #region Constructor
        public VM_TeamMember()
        {
            loadData();
            if (listData is null || App.dataObject.Team_Members is null)
            {
                listData = new ObservableCollection<Team_Members>();
                App.dataObject.Team_Members = new List<Team_Members>();
            }
            WidthTable = 800;
            AddCommand = new RelayCommand(AddMember);
            RemoveCommand = new RelayCommand(RemoveMember);
            PrintCommand = new RelayCommand(PrintToExcel);
            MoveUpCommand = new RelayCommand(MoveUp);
            MoveDownCommand = new RelayCommand(MoveDown);
            ZoomInCommand = new RelayCommand(ZoomIn);
            ZoomOutCommand = new RelayCommand(ZoomOut);
            if(listData!= null) { 
                _collectionView = CollectionViewSource.GetDefaultView(listData);
                _collectionView.Filter = FilterData;
            }
        }
        #endregion

        #region Property

        private Team_Members _selectedData;
        private int _widthTable;
        private ObservableCollection<Team_Members> listData;
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
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                _collectionView.Refresh();
            }
        }
        public ObservableCollection<Team_Members> ListData
        {
            get { return listData; }
            set { listData = value; OnPropertyChanged(); App.dataObject.Team_Members = listData.ToList(); }
        }

        public Team_Members SelectedData
        {
            get { return _selectedData; }
            set
            {
                SetProperty(ref _selectedData, value);
            }
        }

        public ICommand AddCommand { get; private set; }
        public ICommand ZoomInCommand { get; private set; }
        public ICommand ZoomOutCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }
        public ICommand PrintCommand { get; private set; }
        public ICommand MoveUpCommand { get; }
        public ICommand MoveDownCommand { get; }

        #endregion


        #region Method

        private void loadData()
        {
            var appData = App.dataObject.Team_Members;
            if (appData != null)
            {
                listData = new ObservableCollection<Team_Members>(appData);
            }

        }
        private void AddMember()
        {
            Team_Members newData = new Team_Members();
            listData.Add(newData);
            App.dataObject.Team_Members.Add(listData.Last());
            List<Sessions> listSession = App.dataObject.Sessions;
            for (int i = 0; i < listSession.Count; i++)
            {
                if (listSession[0].ID != "empty")
                {
                    Team_Members_Sessions newsData = new Team_Members_Sessions { Team_Member_ID = newData.ID, Session_ID = listSession[i].ID };
                    App.dataObject.Team_Members_Sessions.Add(newsData);
                }
            }
            SelectedData = newData;
        }

        private void RemoveMember()
        {
            if (SelectedData != null)
            {
                Team_Members selectedTempMember = SelectedData;
                listData.Remove(selectedTempMember);
                App.dataObject.Team_Members_Sessions.RemoveAll(item => item.Team_Member_ID == selectedTempMember.ID);
                App.dataObject.Team_Members.Remove(selectedTempMember);
                SelectedData = new Team_Members();
            }
            else
            {
                MessageBox.Show("Please select data first!");
            }
        }

        private void PrintToExcel()
        {
            // Membuat dialog Save File
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx|All Files|*.*",
                DefaultExt = ".xlsx",
                FileName = "Team Member - " + App.dataObject.Overview.Study_Name
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                // Membuat package Excel dan worksheet
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Data Member");
                    worksheet.Cells[1, 1].Value = "Name";
                    worksheet.Cells[1, 2].Value = "Company";
                    worksheet.Cells[1, 3].Value = "Title";
                    worksheet.Cells[1, 4].Value = "Department";
                    worksheet.Cells[1, 5].Value = "Phone Number";
                    worksheet.Cells[1, 6].Value = "EMail Address";
                    // Menulis data dari DataList ke worksheet
                    for (int row = 2; row <= listData.Count; row++)
                    {
                        worksheet.Cells[row, 1].Value = listData[row - 1].Name;
                        worksheet.Cells[row, 2].Value = listData[row - 1].Company;
                        worksheet.Cells[row, 3].Value = listData[row - 1].Title;
                        worksheet.Cells[row, 4].Value = listData[row - 1].Department;
                        worksheet.Cells[row, 5].Value = listData[row - 1].Phone_Number;
                        worksheet.Cells[row, 6].Value = listData[row - 1].E__Mail_Address;
                    }

                    // Menyimpan package Excel ke file
                    File.WriteAllBytes(filePath, package.GetAsByteArray());
                }
            }
        }

        private void MoveUp()
        {
            if (SelectedData != null)
            {
                try
                {
                    int currentIndex = listData.IndexOf(SelectedData);
                    int currentIndexGlobal = App.dataObject.Team_Members.IndexOf(SelectedData);
                    Team_Members movedObject = App.dataObject.Team_Members[currentIndexGlobal];

                    if (currentIndex > 0)
                    {
                        listData.Move(currentIndex, currentIndex - 1);
                        App.dataObject.Team_Members.RemoveAt(currentIndexGlobal);
                        App.dataObject.Team_Members.Insert(currentIndexGlobal - 1, movedObject);
                    }
                }
                catch { MessageBox.Show("Please select data first!"); }
            }else
            {
                MessageBox.Show("Please select data first!");
            }
        }

        private void MoveDown()
        {
            if (SelectedData != null)
            {
                int currentIndex = listData.IndexOf(SelectedData);
                int currentIndexGlobal = App.dataObject.Team_Members.IndexOf(SelectedData);
                Team_Members movedObject = App.dataObject.Team_Members[currentIndexGlobal];
                if (currentIndex < listData.Count - 1)
                {
                    listData.Move(currentIndex, currentIndex + 1);
                    App.dataObject.Team_Members.RemoveAt(currentIndexGlobal);
                    App.dataObject.Team_Members.Insert(currentIndexGlobal + 1, movedObject);
                }
            }
            else
            {
                MessageBox.Show("Please select data first!");
            }
        }
        #endregion

        private bool FilterData(object obj)
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                // Tampilkan semua siswa jika kotak pencarian kosong
                return true;
            }

            if (obj is Team_Members member)
            {
                return member.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       member.Company.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       member.Department.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       member.Experience.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       member.Expertise.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       member.E__Mail_Address.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       member.Phone_Number.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       member.Team_Member_Comments.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }

        private void ZoomIn()
        {

            WidthTable = WidthTable + 60;

        }

        private void ZoomOut()
        {

            WidthTable = WidthTable - 60;

        }



    }
}
