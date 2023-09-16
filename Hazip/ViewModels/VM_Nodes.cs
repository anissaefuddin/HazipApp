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
    public class VM_Nodes : ObservableObject
    {
        #region Constructor
        public VM_Nodes()
        {
            loadData();
            if (listData is null || App.dataObject.Team_Members is null)
            {
                listData = new ObservableCollection<Nodes>();
                App.dataObject.Nodes = new List<Nodes>();
            }
            WidthTable = 800;
            AddCommand = new RelayCommand(AddData);
            RemoveCommand = new RelayCommand(RemoveData);
            PrintCommand = new RelayCommand(PrintToExcel);
            MoveUpCommand = new RelayCommand(MoveUp);
            MoveDownCommand = new RelayCommand(MoveDown);
            ZoomInCommand = new RelayCommand(ZoomIn);
            ZoomOutCommand = new RelayCommand(ZoomOut);
            if (listData != null)
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
        public ObservableCollection<Nodes> ListData
        {
            get { return listData; }
            set { listData = value; OnPropertyChanged(); App.dataObject.Nodes = ListData.ToList(); }
        }
        private ObservableCollection<Nodes> listData;
        public ObservableCollection<Sessions> ListDataSessions
        {
            get { return listDataSessions; }
            set { listDataSessions = value; OnPropertyChanged(); App.dataObject.Sessions = listDataSessions.ToList(); }
        }
        private ObservableCollection<Sessions> listDataSessions;

        public Nodes SelectedData
        {
            get { return _selectedData; }
            set
            {
                SetProperty(ref _selectedData, value);
            }
        }
        private Nodes _selectedData;

        public string SelectedSession_IDs
        {
            get { return _selectedSession_IDs; }
            set
            {
                _selectedSession_IDs = value;
               /* Session_IDs var = new Session_IDs();
                var.ID = value;
                SelectedData.Session_IDs.Add(var);*/
                OnPropertyChanged();
            }
        }
        private string _selectedSession_IDs = string.Empty;

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
            var appData = App.dataObject.Nodes;
            if (appData != null)
            {
                ListData = new ObservableCollection<Nodes>(appData);
                if(App.dataObject.Sessions != null)
                    listDataSessions = new ObservableCollection<Sessions>(App.dataObject.Sessions);
            }

        }
        private void AddData()
        {
            Nodes newData = new Nodes();
            ListData.Add(newData);
            App.dataObject.Nodes.Add(ListData.Last());
            SelectedData = newData;
        }

        private void RemoveData()
        {
            if (SelectedData != null)
            {
                Nodes selectedTemp = SelectedData;
                ListData.Remove(selectedTemp);
                App.dataObject.Nodes.Remove(selectedTemp);
                SelectedData = new Nodes();
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
                FileName = "Hazard Type - " + App.dataObject.Overview.Study_Name
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                // Membuat package Excel dan worksheet
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Hazard Type");
                    worksheet.Cells[1, 1].Value = "Description";
                    worksheet.Cells[1, 2].Value = "Intention";
                    worksheet.Cells[1, 3].Value = "Boundary";
                    worksheet.Cells[1, 4].Value = "Design Conditions";
                    worksheet.Cells[1, 5].Value = "Operating Conditions";
                    worksheet.Cells[1, 6].Value = "Color";
                    worksheet.Cells[1, 7].Value = "Comments";
                    // Menulis data dari DataList ke worksheet
                    for (int row = 2; row <= ListData.Count; row++)
                    {
                        worksheet.Cells[row, 1].Value = ListData[row - 1].Node_Description;
                        worksheet.Cells[row, 2].Value = ListData[row - 1].Intention;
                        worksheet.Cells[row, 3].Value = ListData[row - 1].Boundary;
                        worksheet.Cells[row, 4].Value = ListData[row - 1].Design_Conditions;
                        worksheet.Cells[row, 5].Value = ListData[row - 1].Operating_Conditions;
                        worksheet.Cells[row, 6].Value = ListData[row - 1].Node_Color;
                        worksheet.Cells[row, 7].Value = ListData[row - 1].Node_Comments;
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
                int currentIndexGlobal = App.dataObject.Nodes.IndexOf(SelectedData);
                Nodes movedObject = App.dataObject.Nodes[currentIndexGlobal];

                if (currentIndex > 0)
                {
                    ListData.Move(currentIndex, currentIndex - 1);
                    App.dataObject.Nodes.RemoveAt(currentIndexGlobal);
                    App.dataObject.Nodes.Insert(currentIndexGlobal - 1, movedObject);
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
                int currentIndexGlobal = App.dataObject.Nodes.IndexOf(SelectedData);
                Nodes movedObject = App.dataObject.Nodes[currentIndexGlobal];
                if (currentIndex < listData.Count - 1)
                {
                    listData.Move(currentIndex, currentIndex + 1);
                    App.dataObject.Nodes.RemoveAt(currentIndexGlobal);
                    App.dataObject.Nodes.Insert(currentIndexGlobal + 1, movedObject);
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

            if (obj is Nodes data)
            {
                return data.Node_Description.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       data.Hazardous_Materials.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       data.Operating_Conditions.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       data.Design_Conditions.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       data.Intention.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       data.Location.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       data.Node_Color.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       data.Boundary.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
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
