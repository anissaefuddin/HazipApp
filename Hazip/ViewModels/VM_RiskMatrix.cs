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
using System.IO;
using CommunityToolkit.Mvvm.Input;
using Hazip.Utilities;
using RelayCommand = CommunityToolkit.Mvvm.Input.RelayCommand;

namespace Hazip.ViewModels
{
    public class VM_RiskMatrix : ObservableObject
    {
        #region Constructor
        public VM_RiskMatrix()
        {
            loadData();
            PrintCommand = new RelayCommand(PrintToExcel);
            ParameterTypes = new ObservableCollection<SaverityType>(
                Enum.GetValues(typeof(SaverityType)).Cast<SaverityType>()
            );
            SelectedParameterType = SaverityType.Safety;
        }
        #endregion

        #region Property


        public int WidthTable
        {
            get => _widthTable;
            set
            {
                SetProperty(ref _widthTable, value);
            }
        }
        private int _widthTable;
        public ObservableCollection<Intersections> ListData
        {
            get { return _listData; }
            set
            {
                _listData = value; OnPropertyChanged();
            }
        }
        private ObservableCollection<Intersections> _listData;
        public ObservableCollection<Likelihoods> ListDataLikelihoods
        {
            get { return _listDataLikelihoods; }
            set { _listDataLikelihoods = value; OnPropertyChanged();}
        }
        private ObservableCollection<Likelihoods> _listDataLikelihoods;
        public ObservableCollection<Risk_Rankings> ListDataRiskRankings
        {
            get { return _listDataRiskRankings; }
            set { _listDataRiskRankings = value; OnPropertyChanged(); }
        }
        private ObservableCollection<Risk_Rankings> _listDataRiskRankings;
        public ObservableCollection<Severitys> ListDataConsecuences
        {
            get { return _listDataConsecuences; }
            set { _listDataConsecuences = value; OnPropertyChanged(); }
        }
        private ObservableCollection<Severitys> _listDataConsecuences;


        public Deviations SelectedData
        {
            get { return _selectedData; }
            set
            {
                SetProperty(ref _selectedData, value);
            }
        }
        private Deviations _selectedData;


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
        }
        private SaverityType _selectedParameterType;
       

 
        public ICommand PrintCommand { get; private set; }


        #endregion


        #region Method

        private void loadData()
        {
            
            ListData = new ObservableCollection<Intersections>(App.dataObject.Risk_Criteria.intersections ?? new List<Intersections>());
            ListDataConsecuences = new ObservableCollection<Severitys>(App.dataObject.Risk_Criteria.severities);
            ListDataRiskRankings = new ObservableCollection<Risk_Rankings>(App.dataObject.Risk_Criteria.risk_Rankings ?? new List<Risk_Rankings>());
            ListDataLikelihoods = new ObservableCollection<Likelihoods>(App.dataObject.Risk_Criteria.likelihoods ?? new List<Likelihoods>());

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

        private void PrintToExcel()
        {
            // Membuat dialog Save File
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx|All Files|*.*",
                DefaultExt = ".xlsx",
                FileName = "Matrix - " + App.dataObject.Overview.Study_Name
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
                       /* worksheet.Cells[row, 1].Value = ListData[row - 1].Deviation;
                        worksheet.Cells[row, 2].Value = ListData[row - 1].Guide_Word;
                        worksheet.Cells[row, 3].Value = ListData[row - 1].Parameter;
                        worksheet.Cells[row, 4].Value = ListData[row - 1].Design_Intent;
                        worksheet.Cells[row, 5].Value = ListData[row - 1].Deviation_Comments;*/
                    }

                    // Menyimpan package Excel ke file
                    File.WriteAllBytes(filePath, package.GetAsByteArray());
                }
            }
        }


        #endregion
    }
}
