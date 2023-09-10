using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hazip.Models;
using Hazip.Screen.Pages.StudyDataMenu;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Input;
using Hazip.Models;

namespace Hazip.Screen.ViewModels.StudyData
{

    public class VM_OverView : ObservableObject
    {
        //public  DataFile dataFile { get; set; }

        //public  Models.DataObject dataObject { get; set; }

        #region Constructor
        public VM_OverView()
        {
            SaveDataOverview = new RelayCommand(saveOverView);
            //if(App.dataObject != null)
                //loadDataOverview(App.dataObject.Overview);
        }
        #endregion Constructor

        #region Property

        public ICommand SaveDataOverview { get; }
       

        /// <summary>
        /// Study_Name
        /// </summary>
        public string StudyName
        {
            get => _studyName;
            set
            {
                SetProperty(ref _studyName, value);
            }
        }
        private string _studyName = string.Empty;

        /// <summary>
        /// Study_Coordinator
        /// </summary>
        public string StudyCoordinator
        {
            get => _studyCoordinator;
            set
            {
                SetProperty(ref _studyCoordinator, value);
            }
        }
        private string _studyCoordinator = string.Empty;

        /// <summary>
        /// Study_Coordinator_Contact_Info
        /// </summary>
        public string StudyCoordinatorContactInfo
        {
            get => _studyCoordinatorContactInfo;
            set
            {
                SetProperty(ref _studyCoordinatorContactInfo, value);
            }
        }
        private string _studyCoordinatorContactInfo = string.Empty;

        /// <summary>
        /// Facility
        /// </summary>
        public string Facility
        {
            get => _facility;
            set
            {
                SetProperty(ref _facility, value);
            }
        }
        private string _facility = string.Empty;

        /// <summary>
        /// Facility_Location
        /// </summary>
        public string FacilityLocation
        {
            get => _facilityLocation;
            set
            {
                SetProperty(ref _facilityLocation, value);
            }
        }
        private string _facilityLocation = string.Empty;

        /// <summary>
        /// Facility_Owner
        /// </summary>
        public string FacilityOwner
        {
            get => _facilityOwner;
            set
            {
                SetProperty(ref _facilityOwner, value);
            }
        }
        private string _facilityOwner = string.Empty;

        /// <summary>
        /// Overview_Company
        /// </summary>
        public string OverviewCompany
        {
            get => _OverviewCompany;
            set
            {
                SetProperty(ref _OverviewCompany, value);
            }
        }
        private string _OverviewCompany = string.Empty;

        /// <summary>
        /// Site
        /// </summary>
        public string Site
        {
            get => _site;
            set
            {
                SetProperty(ref _site, value);
            }
        }
        private string _site = string.Empty;

        /// <summary>
        /// Plant
        /// </summary>
        public string Plant
        {
            get => _plant;
            set
            {
                SetProperty(ref _plant, value);
            }
        }
        private string _plant = string.Empty;

        /// <summary>
        /// Unit__Group
        /// </summary>
        public string UnitGroup
        {
            get => _unitGroup;
            set
            {
                SetProperty(ref _unitGroup, value);
            }
        }
        private string _unitGroup = string.Empty;

        /// <summary>
        /// Unit
        /// </summary>
        public string Unit
        {
            get => _unit;
            set
            {
                SetProperty(ref _unit, value);
            }
        }
        private string _unit = string.Empty;

        /// <summary>
        /// Sub__Unit
        /// </summary>
        public string SubUnit
        {
            get => _subUnit;
            set
            {
                SetProperty(ref _subUnit, value);
            }
        }
        private string _subUnit = string.Empty;

        /// <summary>
        /// Report_Number
        /// </summary>
        public string ReportNumber
        {
            get => _reportNumber;
            set
            {
                SetProperty(ref _reportNumber, value);
            }
        }
        private string _reportNumber = string.Empty;

        /// <summary>
        /// Project_Number
        /// </summary>
        public string ProjectNumber
        {
            get => _projectNumber;
            set
            {
                SetProperty(ref _projectNumber, value);
            }
        }
        private string _projectNumber = string.Empty;

        /// <summary>
        /// Project_Description
        /// </summary>
        public string ProjectDescription
        {
            get => _projectDescription;
            set
            {
                SetProperty(ref _projectDescription, value);
            }
        }
        private string _projectDescription = string.Empty;

        /// <summary>
        /// General_Notes
        /// </summary>
        public string GeneralNotes
        {
            get => _generalNotes;
            set
            {
                SetProperty(ref _generalNotes, value);
            }
        }
        private string _generalNotes = string.Empty;

        #endregion Property

        #region Method 

        private void saveOverView()
        {
            Overview overview = new Overview(); 
            overview.Study_Name = _studyName;
            overview.Study_Coordinator = _studyCoordinator;

            App.dataObject.Overview = overview;
            App.dataFile.Content = JsonConvert.SerializeObject(App.dataObject);
            //jsonFilePath = "path_to_your_json_file.json"; // Gantilah dengan path file JSON Anda
            File.WriteAllText(App.dataFile.FilePath, App.dataFile.Content);

        }

        public void loadDataOverview(Overview overview)
        {
            if (overview != null)
            {
                StudyName = overview.Study_Name;
                StudyCoordinator = overview.Study_Coordinator;

            }
            
        }

        #endregion Method

    }
}
