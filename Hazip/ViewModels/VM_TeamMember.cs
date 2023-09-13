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
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Data;
using System.Linq;
using System.Windows.Controls;
using System.Windows;

namespace Hazip.ViewModels
{
    public class VM_TeamMember : ObservableObject
    {
        #region Constructor
        public VM_TeamMember()
        {
            loadDataTeamMember();
            WidthTable = 500;
            AddCommand = new RelayCommand(AddMember);
            RemoveCommand = new RelayCommand(RemoveMember, () => SelectedMember != null);
            PrintCommand = new RelayCommand(PrintToExcel);
            MoveUpCommand = new RelayCommand(MoveUp, () => SelectedMember != null);
            MoveDownCommand = new RelayCommand(MoveDown, () => SelectedMember != null);
            ZoomInCommand = new RelayCommand(ZoomIn);
            ZoomOutCommand = new RelayCommand(ZoomOut);

            _collectionView = CollectionViewSource.GetDefaultView(listTeamMember);
            _collectionView.Filter = FilterData;
        }
        #endregion

        #region Property

        private Team_Members selectedMember;
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
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                _collectionView.Refresh();
            }
        }
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
        public ICommand ZoomInCommand { get; private set; }
        public ICommand ZoomOutCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }
        public ICommand PrintCommand { get; private set; }
        public ICommand MoveUpCommand { get; }
        public ICommand MoveDownCommand { get; }

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
                    for (int row = 2; row <= ListTeamMember.Count; row++)
                    {
                        worksheet.Cells[row, 1].Value = ListTeamMember[row - 1].Name;
                        worksheet.Cells[row, 2].Value = ListTeamMember[row - 1].Company;
                        worksheet.Cells[row, 3].Value = ListTeamMember[row - 1].Title;
                        worksheet.Cells[row, 4].Value = ListTeamMember[row - 1].Department;
                        worksheet.Cells[row, 5].Value = ListTeamMember[row - 1].Phone_Number;
                        worksheet.Cells[row, 6].Value = ListTeamMember[row - 1].E__Mail_Address;
                    }

                    // Menyimpan package Excel ke file
                    File.WriteAllBytes(filePath, package.GetAsByteArray());
                }
            }
        }

        private void MoveUp()
        {
            int currentIndex = listTeamMember.IndexOf(selectedMember);
            int currentIndexGlobal = App.dataObject.Team_Members.IndexOf(selectedMember);
            Team_Members movedObject = App.dataObject.Team_Members[currentIndexGlobal];
            
            if (currentIndex > 0)
            {
                listTeamMember.Move(currentIndex, currentIndex - 1);
                App.dataObject.Team_Members.RemoveAt(currentIndexGlobal);
                App.dataObject.Team_Members.Insert(currentIndexGlobal - 1, movedObject);
            }
        }

        private void MoveDown()
        {
            int currentIndex = listTeamMember.IndexOf(selectedMember);
            int currentIndexGlobal = App.dataObject.Team_Members.IndexOf(selectedMember);
            Team_Members movedObject = App.dataObject.Team_Members[currentIndexGlobal];
            if (currentIndex < listTeamMember.Count - 1)
            {
                listTeamMember.Move(currentIndex, currentIndex + 1);
                App.dataObject.Team_Members.RemoveAt(currentIndexGlobal);
                App.dataObject.Team_Members.Insert(currentIndexGlobal + 1, movedObject);
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

            WidthTable = WidthTable + 50;

        }

        private void ZoomOut()
        {

            WidthTable = WidthTable - 50;

        }



    }
}
