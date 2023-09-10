using Hazip.Models;
using Hazip.Screen.ViewModels.StudyData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using System.Windows;
using DataObject = Hazip.Models.DataObject;

namespace Hazip
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
       
        public static DataFile dataFile {  get; set; }

        public static DataObject dataObject { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Inisialisasi variabel global di sini
            //var mainWindow = new MainWindow();
            //var vm_Overview = new VM_OverView();

            dataFile = new DataFile();
            dataObject = new DataObject();
            
           // vm_Overview.dataFile = dataFile;
           // vm_Overview.dataObject = dataObject;

            //mainWindow.DataContext = new { Overview_VM = vm_Overview };
            //mainWindow.Show();
        }
    }
}
