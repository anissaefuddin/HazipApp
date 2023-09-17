using CommunityToolkit.Mvvm.ComponentModel;
using Hazip.Models;
using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using System.IO;

namespace Hazip.ViewModels
{
    public  class VM_RiskRanking : ObservableObject
    {
        #region Constructor
        public VM_RiskRanking()
        {

            loadData();
            AddCommand = new RelayCommand(AddData);
            RemoveCommand = new RelayCommand(RemoveData);
            PrintCommand = new RelayCommand(PrintToExcel);
            MoveUpCommand = new RelayCommand(MoveUp);
            MoveDownCommand = new RelayCommand(MoveDown);
            ZoomInCommand = new RelayCommand(ZoomIn);
            ZoomOutCommand = new RelayCommand(ZoomOut);
            if (_listData != null)
            {
                _collectionView = CollectionViewSource.GetDefaultView(ListData);
                _collectionView.Filter = FilterData;
            }
        }
        #endregion

        #region Property

        private ICollectionView _collectionView;

        public int WidthTable
        {
            get => _widthTable;
            set
            {
                SetProperty(ref _widthTable, value);
            }
        }
        private int _widthTable;
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                _collectionView.Refresh();
            }
        }
        private string _searchText;
        public ObservableCollection<Risk_Rankings> ListData
        {
            get { return _listData; }
            set
            {
                _listData = value; OnPropertyChanged();
                //SelectedDataNodes.Deviations = ListData.ToList();
                App.dataObject.Risk_Criteria.risk_Rankings = ListData.ToList();
            }
        }
        private ObservableCollection<Risk_Rankings> _listData;

        public Risk_Rankings SelectedData
        {
            get { return _selectedData; }
            set
            {
                SetProperty(ref _selectedData, value);
            }
        }
        private Risk_Rankings _selectedData;


        public ICommand AddCommand { get; private set; }
        public ICommand CheckDataCommand { get; private set; }
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
            var appData = App.dataObject.Risk_Criteria.risk_Rankings;
            if (appData != null)
            {
                _listData = new ObservableCollection<Risk_Rankings>(appData);
            }
            else
            {
                _listData = new ObservableCollection<Risk_Rankings>();
            }

            WidthTable = 400;
        }


        private void AddData()
        {
            Risk_Rankings newData = new Risk_Rankings();
            ListData.Add(newData);
            App.dataObject.Risk_Criteria.risk_Rankings.Add(ListData.Last());
            SelectedData = newData;
        }

        private void RemoveData()
        {
            if (SelectedData != null)
            {
                Risk_Rankings selectedTemp = SelectedData;
                ListData.Remove(selectedTemp);
                App.dataObject.Risk_Criteria.risk_Rankings.Remove(selectedTemp);
                SelectedData = new Risk_Rankings();
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
                FileName = "Risk Ranking Categories - " + App.dataObject.Overview.Study_Name
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                // Membuat package Excel dan worksheet
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Risk Ranking Categories");
                    worksheet.Cells[1, 1].Value = "Code";
                    worksheet.Cells[1, 2].Value = "Description";
                    worksheet.Cells[1, 3].Value = "Color";
                    worksheet.Cells[1, 4].Value = "Priority";
                    for (int row = 2; row <= ListData.Count; row++)
                    {
                        worksheet.Cells[row, 1].Value = ListData[row - 1].Code;
                        worksheet.Cells[row, 2].Value = ListData[row - 1].RM_Description;
                        worksheet.Cells[row, 3].Value = ListData[row - 1].Color;
                        worksheet.Cells[row, 4].Value = ListData[row - 1].Priority;
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
                int currentIndexGlobal = App.dataObject.Risk_Criteria.risk_Rankings.IndexOf(SelectedData);
                Risk_Rankings movedObject = App.dataObject.Risk_Criteria.risk_Rankings[currentIndexGlobal];

                if (currentIndex > 0)
                {
                    ListData.Move(currentIndex, currentIndex - 1);
                    App.dataObject.Risk_Criteria.risk_Rankings.RemoveAt(currentIndexGlobal);
                    App.dataObject.Risk_Criteria.risk_Rankings.Insert(currentIndexGlobal - 1, movedObject);
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
                int currentIndex = ListData.IndexOf(SelectedData);
                int currentIndexGlobal = App.dataObject.Risk_Criteria.risk_Rankings.IndexOf(SelectedData);
                Risk_Rankings movedObject = App.dataObject.Risk_Criteria.risk_Rankings[currentIndexGlobal];
                if (currentIndex < ListData.Count - 1)
                {
                    ListData.Move(currentIndex, currentIndex + 1);
                    App.dataObject.Risk_Criteria.risk_Rankings.RemoveAt(currentIndexGlobal);
                    App.dataObject.Risk_Criteria.risk_Rankings.Insert(currentIndexGlobal + 1, movedObject);
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

            if (obj is Risk_Rankings data)
            {
                return data.Code.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       data.RM_Description.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       data.Color.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       data.Priority.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
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
