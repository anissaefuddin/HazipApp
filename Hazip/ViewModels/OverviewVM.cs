using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hazip.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hazip.ViewModels
{
    class OverviewVM : ObservableObject
    {
        #region Constructor
        public ICommand LoadDataCommandOverview { get; private set; }
        public Overview Overview { get;  set; }
        public OverviewVM(Overview overview)
        {
            SaveDataOverview = new RelayCommand(saveOverView);
            //LoadDataCommandOverview = new RelayCommand(loadDataMethod);
            Overview = overview;
        }


      /*  private void loadDataMethod()
        {
            if (App.dataObject.Overview is not null)
            {
                StudyName = App.dataObject.Overview.Study_Name;
                StudyCoordinator = App.dataObject.Overview.Study_Coordinator;
                StudyCoordinatorContactInfo = App.dataObject.Overview.Study_Coordinator_Contact_Info;
                Facility = App.dataObject.Overview.Facility;
                FacilityLocation = App.dataObject.Overview.Facility_Location;
                FacilityOwner = App.dataObject.Overview.Facility_Owner;
                OverviewCompany = App.dataObject.Overview.Overview_Company;
                Site = App.dataObject.Overview.Site;
                Plant = App.dataObject.Overview.Plant;
                UnitGroup = App.dataObject.Overview.Unit__Group;
                Unit = App.dataObject.Overview.Unit;
                SubUnit = App.dataObject.Overview.Sub__Unit;
                ReportNumber = App.dataObject.Overview.Report_Number;
                ProjectNumber = App.dataObject.Overview.Project_Number;
                ProjectDescription = App.dataObject.Overview.Project_Description;
                GeneralNotes = App.dataObject.Overview.General_Notes;
                
            }
        }*/
        #endregion Constructor

        #region Property

        public ICommand SaveDataOverview { get; }

        /// <summary>
        /// Study_Name
        /// </summary>
        public string StudyName
        {
            get
            {
                return _studyName;
            }
            set
            {
                SetProperty(ref _studyName, value);
                if (App.dataObject.Overview != null) App.dataObject.Overview.Study_Name = value;
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
                if (App.dataObject.Overview != null) App.dataObject.Overview.Study_Coordinator = value;
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
                if (App.dataObject.Overview != null) App.dataObject.Overview.Study_Coordinator_Contact_Info = value;
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
                if (App.dataObject.Overview != null) App.dataObject.Overview.Facility = value;
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
                if (App.dataObject.Overview != null) App.dataObject.Overview.Facility_Location = value;
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
                if (App.dataObject.Overview != null) App.dataObject.Overview.Facility_Owner = value;
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
                if (App.dataObject.Overview != null) App.dataObject.Overview.Overview_Company = value;
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
                if (App.dataObject.Overview != null) App.dataObject.Overview.Site = value;
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
                if (App.dataObject.Overview != null) App.dataObject.Overview.Plant = value;
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
                if (App.dataObject.Overview != null) App.dataObject.Overview.Unit__Group = value;
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
                if (App.dataObject.Overview != null) App.dataObject.Overview.Unit = value;
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
                if (App.dataObject.Overview != null) App.dataObject.Overview.Sub__Unit = value;
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
                if (App.dataObject.Overview != null) App.dataObject.Overview.Report_Number = value;
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
                if (App.dataObject.Overview != null) App.dataObject.Overview.Project_Number = value;
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
                if (App.dataObject.Overview != null) App.dataObject.Overview.Project_Description = value;
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
                if (App.dataObject.Overview != null) App.dataObject.Overview.General_Notes = value;
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

            //App.dataObject.Overview = overview;
            App.dataFile.Content = JsonConvert.SerializeObject(App.dataObject);
            //jsonFilePath = "path_to_your_json_file.json"; // Gantilah dengan path file JSON Anda
            //File.WriteAllText(App.dataFile.FilePath, App.dataFile.Content);

            //Overview overview = new Overview();

        }

        public void loadDataOverview(object parameter)
        {

            if (parameter != null)
            {
                Overview overview = (Overview)parameter;
            }

        }

        #endregion Method

    }
}
