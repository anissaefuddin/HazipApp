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
    public class VM_Safeguard : ObservableObject
    {
        #region Constructor
        public VM_Safeguard()
        {
            loadData();
            if (listData is null || App.dataObject.Safeguards is null)
            {
                listData = new ObservableCollection<Safeguards>();
                App.dataObject.Safeguards = new List<Safeguards>();
            }
            WidthTable = 800;
            AddCommand = new RelayCommand(AddMember);
            RemoveCommand = new RelayCommand(RemoveMember);
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
        #endregion

        #region Property

        private Safeguards _selectedData;
        private int _widthTable;
        private ObservableCollection<Safeguards> listData;
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
        public ObservableCollection<Safeguards> ListData
        {
            get { return listData; }
            set { listData = value; OnPropertyChanged(); App.dataObject.Safeguards = listData.ToList(); }
        }

        public Safeguards SelectedData
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
            var appData = App.dataObject.Safeguards;
            if (appData != null)
            {
                listData = new ObservableCollection<Safeguards>(appData);
            }

        }
        private void AddMember()
        {
            Safeguards newData = new Safeguards();
            listData.Add(newData);
            App.dataObject.Safeguards.Add(listData.Last());
            SelectedData = newData;
        }

        private void RemoveMember()
        {
            if (SelectedData != null)
            {
                Safeguards selectedTemp = SelectedData;
                listData.Remove(selectedTemp);
                /*App.dataObject.Team_Members_Sessions.RemoveAll(item => item.Team_Member_ID == selectedTempMember.ID);*/
                App.dataObject.Safeguards.Remove(selectedTemp);
                SelectedData = new Safeguards();
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
                       /* worksheet.Cells[row, 1].Value = listData[row - 1].Name;
                        worksheet.Cells[row, 2].Value = listData[row - 1].Company;
                        worksheet.Cells[row, 3].Value = listData[row - 1].Title;
                        worksheet.Cells[row, 4].Value = listData[row - 1].Department;
                        worksheet.Cells[row, 5].Value = listData[row - 1].Phone_Number;
                        worksheet.Cells[row, 6].Value = listData[row - 1].E__Mail_Address;*/
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
                    int currentIndexGlobal = App.dataObject.Safeguards.IndexOf(SelectedData);
                    Safeguards movedObject = App.dataObject.Safeguards[currentIndexGlobal];

                    if (currentIndex > 0)
                    {
                        listData.Move(currentIndex, currentIndex - 1);
                        App.dataObject.Safeguards.RemoveAt(currentIndexGlobal);
                        App.dataObject.Safeguards.Insert(currentIndexGlobal - 1, movedObject);
                    }
                }
                catch { MessageBox.Show("Please select data first!"); }
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
                int currentIndexGlobal = App.dataObject.Safeguards.IndexOf(SelectedData);
                Safeguards movedObject = App.dataObject.Safeguards[currentIndexGlobal];
                if (currentIndex < listData.Count - 1)
                {
                    listData.Move(currentIndex, currentIndex + 1);
                    App.dataObject.Safeguards.RemoveAt(currentIndexGlobal);
                    App.dataObject.Safeguards.Insert(currentIndexGlobal + 1, movedObject);
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

            if (obj is Safeguards data)
            {
                return data.Safeguard.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                       data.Ipl_Credit.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
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
