using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using RelayCommand = CommunityToolkit.Mvvm.Input.RelayCommand;

namespace Hazip.ViewModels
{
    public class VM_Concequence : ObservableObject
    {
        #region Constructor
        public VM_Concequence()
        {

            loadData();
            AddCommand1 = new RelayCommand(AddData);
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
            ParameterTypes = new ObservableCollection<SaverityType>(
                Enum.GetValues(typeof(SaverityType)).Cast<SaverityType>()
            );
            SelectedParameterType = SaverityType.Safety;
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

        public ObservableCollection<SaverityType> ParameterTypes { get; set; }
        public SaverityType SelectedParameterType
        {
            get { return _selectedParameterType; }
            set
            {
                if (_selectedParameterType != value)
                {
                    _selectedParameterType = value;
                    ApplyFilter(); // Terapkan filter saat SelectedParameterType berubah
                    OnPropertyChanged(nameof(SelectedParameterType));
                }
            }
        }private SaverityType _selectedParameterType;
        public ObservableCollection<Severitys> ListData
        {
            get { return _listData; }
            set
            {
                _listData = value; OnPropertyChanged();
                //SelectedDataNodes.Deviations = ListData.ToList();
                App.dataObject.Risk_Criteria.severities = ListData.ToList();
            }
        }
        private ObservableCollection<Severitys> _listData;

        public Severitys SelectedData
        {
            get { return _selectedData; }
            set
            {
                SetProperty(ref _selectedData, value);
            }
        }
        private Severitys _selectedData;


        public ICommand AddCommand1 { get; private set; }
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
            var appData = App.dataObject.Risk_Criteria.severities;
            if (appData != null)
            {
                _listData = new ObservableCollection<Severitys>(appData);
            }
            else
            {
                _listData = new ObservableCollection<Severitys>();
            }

            WidthTable = 400;
        }
        private void ApplyFilter()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(ListData);

           
                // Terapkan filter berdasarkan SelectedParameterType
                view.Filter = item =>
                {
                    if (item is Severitys severity)
                    {
                        return severity.Severity_Type == SelectedParameterType;
                    }
                    return false;
                };
            
        }


        private void AddData()
        {
            Severitys newData = new Severitys();
            ListData.Add(newData);
            App.dataObject.Risk_Criteria.severities.Add(ListData.Last());
            SelectedData = newData;
        }

        private void RemoveData()
        {
            if (SelectedData != null)
            {
                Severitys selectedTemp = SelectedData;
                ListData.Remove(selectedTemp);
                App.dataObject.Risk_Criteria.severities.Remove(selectedTemp);
                SelectedData = new Severitys();
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
                FileName = "Consequence Categories - " + App.dataObject.Overview.Study_Name
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                // Membuat package Excel dan worksheet
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Consequence Categories");
                    worksheet.Cells[1, 1].Value = "Code";
                    worksheet.Cells[1, 2].Value = "Description";
                    worksheet.Cells[1, 3].Value = "TMEL";
                    for (int row = 2; row <= ListData.Count; row++)
                    {
                        worksheet.Cells[row, 1].Value = ListData[row - 1].Code;
                        worksheet.Cells[row, 2].Value = ListData[row - 1].RM_Description;
                        worksheet.Cells[row, 3].Value = ListData[row - 1].RM_Tmel;
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
                int currentIndexGlobal = App.dataObject.Risk_Criteria.severities.IndexOf(SelectedData);
                Severitys movedObject = App.dataObject.Risk_Criteria.severities[currentIndexGlobal];

                if (currentIndex > 0)
                {
                    ListData.Move(currentIndex, currentIndex - 1);
                    App.dataObject.Risk_Criteria.severities.RemoveAt(currentIndexGlobal);
                    App.dataObject.Risk_Criteria.severities.Insert(currentIndexGlobal - 1, movedObject);
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
                int currentIndexGlobal = App.dataObject.Risk_Criteria.severities.IndexOf(SelectedData);
                Severitys movedObject = App.dataObject.Risk_Criteria.severities[currentIndexGlobal];
                if (currentIndex < ListData.Count - 1)
                {
                    ListData.Move(currentIndex, currentIndex + 1);
                    App.dataObject.Risk_Criteria.severities.RemoveAt(currentIndexGlobal);
                    App.dataObject.Risk_Criteria.severities.Insert(currentIndexGlobal + 1, movedObject);
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

            if (obj is Severitys data)
            {
                return data.Code.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       data.RM_Description.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       data.RM_Tmel.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
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
