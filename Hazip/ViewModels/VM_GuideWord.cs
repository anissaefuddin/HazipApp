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
using Newtonsoft.Json;

namespace Hazip.ViewModels
{
    public class VM_GuideWord : ObservableObject
    {
        #region Constructor
        public VM_GuideWord()
        {
            loadData();
            if (_listDataNodes is null)
            {
                _listDataNodes = new ObservableCollection<Nodes>();
                App.dataObject.Nodes = new List<Nodes>();
            }
            CheckDataCommand = new RelayCommand(checkData);
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
        public ObservableCollection<Deviations> ListData
        {
            get { return _listData; }
            set { _listData = value; OnPropertyChanged();  
                SelectedDataNodes.Deviations =ListData.ToList(); 
                App.dataObject.Nodes = ListDataNodes.ToList();}
        }
        private ObservableCollection<Deviations> _listData;
        public ObservableCollection<Nodes> ListDataNodes
        {
            get { return _listDataNodes; }
            set { _listDataNodes = value; OnPropertyChanged(); App.dataObject.Nodes = ListDataNodes.ToList(); }
        }
        private ObservableCollection<Nodes> _listDataNodes;


        public Deviations SelectedData
        {
            get { return _selectedData; }
            set
            {
                SetProperty(ref _selectedData, value);
            }
        }
        private Deviations _selectedData;

        public Nodes SelectedDataNodes
        {
            get { return _selectedDataNodes; }
            set
            {   
                _selectedDataNodes = value;
                if (SelectedDataNodes != null && SelectedDataNodes.Deviations != null)
                {
                    _listData = new ObservableCollection<Deviations>(_selectedDataNodes?.Deviations);
                    OnPropertyChanged(nameof(SelectedDataNodes));
                }
                else
                {
                    // Handle case where SelectedDataNodes or Drawing_IDs is null
                    _listData = new ObservableCollection<Deviations>();
                }
                if (_selectedDataNodes != value)
                {
                    _selectedDataNodes = value;
                    OnPropertyChanged(nameof(SelectedDataNodes));
                }
                OnPropertyChanged(nameof(ListData));
            }
        }
        private Nodes _selectedDataNodes;


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
        private void checkData()
        {
            var a = App.dataObject.Nodes;
            var b = _listDataNodes;
            var c = SelectedDataNodes;
            var d = _listData;
            var e = SelectedData;
            //SelectedDataNodes = ListDataNodes[0];
        }
        private void loadData()
        {
            var appData = App.dataObject.Nodes;
            if (appData != null)
            {
                ListDataNodes = new ObservableCollection<Nodes>(appData);
                if(_listDataNodes != null) SelectedDataNodes = ListDataNodes[0];
                if (_selectedDataNodes.Deviations != null)
                { _listData = new ObservableCollection<Deviations>(_selectedDataNodes.Deviations); ; }
                else _listData = new ObservableCollection<Deviations>();
            }
            WidthTable = 800;
        }
        

        private void AddData()
        {
            Deviations newData = new Deviations();
            ListData.Add(newData);
            SelectedData = newData;
        }

        private void RemoveData()
        {
            if (SelectedData != null)
            {
                Deviations selectedTemp = SelectedData;
                ListData.Remove(selectedTemp);
                SelectedDataNodes.Deviations = ListData.ToList();
                App.dataObject.Nodes = ListDataNodes.ToList();
                SelectedData = new Deviations();
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
                FileName = "Guide Word - "+ SelectedDataNodes?.Node_Description + App.dataObject.Overview.Study_Name
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                // Membuat package Excel dan worksheet
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Guide Word");
                    worksheet.Cells[1, 1].Value = "Deviation";
                    worksheet.Cells[1, 2].Value = "Guide Word";
                    worksheet.Cells[1, 3].Value = "Parameter";
                    worksheet.Cells[1, 4].Value = "Design Intent";
                    worksheet.Cells[1, 5].Value = "Comment";
                    for (int row = 2; row <= ListData.Count; row++)
                    {
                        worksheet.Cells[row, 1].Value = ListData[row - 1].Deviation;
                        worksheet.Cells[row, 2].Value = ListData[row - 1].Guide_Word;
                        worksheet.Cells[row, 3].Value = ListData[row - 1].Parameter;
                        worksheet.Cells[row, 4].Value = ListData[row - 1].Design_Intent;
                        worksheet.Cells[row, 5].Value = ListData[row - 1].Deviation_Comments;
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
                if (currentIndex > 0)
                {
                    ListData.Move(currentIndex, currentIndex - 1);
                    SelectedDataNodes.Deviations = ListData.ToList();
                    App.dataObject.Nodes = ListDataNodes.ToList();
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
              
                if (currentIndex < ListData.Count - 1)
                {
                    ListData.Move(currentIndex, currentIndex + 1);
                    SelectedDataNodes.Deviations = ListData.ToList();
                    App.dataObject.Nodes = ListDataNodes.ToList();
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

            if (obj is Deviations data)
            {
                return data.Deviation.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       data.Deviation_Comments.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       data.Design_Intent.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       data.Parameter.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       data.Guide_Word.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
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