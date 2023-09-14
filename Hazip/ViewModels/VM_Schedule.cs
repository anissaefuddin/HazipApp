using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hazip.Models;
using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.IO;
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
            loadData();
            WidthTable = 600;
            AddCommand = new RelayCommand(AddMember);
            RemoveCommand = new RelayCommand(RemoveData);
            PrintCommand = new RelayCommand(PrintToExcel);
            MoveUpCommand = new RelayCommand(MoveUp);
            MoveDownCommand = new RelayCommand(MoveDown);
            ZoomInCommand = new RelayCommand(ZoomIn);
            ZoomOutCommand = new RelayCommand(ZoomOut);
            if (listData != null)
            {
                _collectionView = CollectionViewSource.GetDefaultView(listData);
                _collectionView.Filter = FilterData;
            }
        }


        #region Property

        public ICommand AddCommand { get; private set; }
        public ICommand ZoomInCommand { get; private set; }
        public ICommand ZoomOutCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }
        public ICommand PrintCommand { get; private set; }
        public ICommand MoveUpCommand { get; }
        public ICommand MoveDownCommand { get; }



        
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
        public ObservableCollection<Sessions> ListData
        {
            get { return listData; }
            set { listData = value; OnPropertyChanged(); App.dataObject.Sessions = ListData.ToList(); }
        }
        
        private ObservableCollection<Sessions> listData;
        public ObservableCollection<Team_Members> ListDataMembers
        {
            get { return _listDataMembers ; }
            set { _listDataMembers = value;  }
        }
        private ObservableCollection<Team_Members> _listDataMembers;
        
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

        #endregion



        #region Method

        
        private void loadData()
        {
            var appData = App.dataObject.Sessions;
            if (appData != null)
            {
                ListData = new ObservableCollection<Sessions>(appData);
                ListDataMembers = new ObservableCollection<Team_Members>(App.dataObject.Team_Members);
            }
        }

        private void AddMember()
        {
            Sessions newData = new Sessions();
            listData.Add(newData);
            App.dataObject.Sessions.Add(listData.Last());
            SelectedData = newData;
        }

        private void RemoveData()
        {
            if (SelectedData != null)
            {
                Sessions selectedTemp = SelectedData;
                ListData.Remove(selectedTemp);
                App.dataObject.Sessions.Remove(selectedTemp);
                SelectedData = new Sessions();
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
                        worksheet.Cells[row, 1].Value = ListData[row - 1].Date;
                        worksheet.Cells[row, 2].Value = ListData[row - 1].Duration;
                        worksheet.Cells[row, 3].Value = ListData[row - 1].Session;
                        worksheet.Cells[row, 4].Value = ListData[row - 1].Facilitator_ID;
                        worksheet.Cells[row, 5].Value = ListData[row - 1].Scribe_ID;
                        worksheet.Cells[row, 6].Value = ListData[row - 1].Session_Comments;
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
                int currentIndex = ListData.IndexOf(SelectedData);
                int currentIndexGlobal = App.dataObject.Sessions.IndexOf(SelectedData);
                Sessions movedObject = App.dataObject.Sessions[currentIndexGlobal];

                if (currentIndex > 0)
                {
                    ListData.Move(currentIndex, currentIndex - 1);
                    App.dataObject.Sessions.RemoveAt(currentIndexGlobal);
                    App.dataObject.Sessions.Insert(currentIndexGlobal - 1, movedObject);
                }
            }
            else
            {
                MessageBox.Show("Please select data first!");
            }
        }

        private void MoveDown()
        {
            if (SelectedData != null)
            {
                int currentIndex = listData.IndexOf(SelectedData);
                int currentIndexGlobal = App.dataObject.Sessions.IndexOf(SelectedData);
                Sessions movedObject = App.dataObject.Sessions[currentIndexGlobal];
                if (currentIndex < listData.Count - 1)
                {
                    listData.Move(currentIndex, currentIndex + 1);
                    App.dataObject.Sessions.RemoveAt(currentIndexGlobal);
                    App.dataObject.Sessions.Insert(currentIndexGlobal + 1, movedObject);
                }
            }
            else
            {
                MessageBox.Show("Please select data first!");
            }
        }
        private bool FilterData(object obj)
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                // Tampilkan semua siswa jika kotak pencarian kosong
                return true;
            }

            if (obj is Sessions data)
            {
                return data.Date.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       data.Session.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       data.Session_Comments.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       data.Duration.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       data.Facilitator_ID.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
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

        #endregion

    }
}