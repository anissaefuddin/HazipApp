using Hazip.Models;
using Hazip.ViewModels;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using System.Windows;

namespace Hazip
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
       
        public static DataFile dataFile {  get; set; }

        public static DataObjek dataObject { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            dataFile = new DataFile();
            dataObject = new DataObjek();
            /*App.dataFile.FilePath = "C:\\Users\\xabo\\Downloads\\Pabrik Limbah - Copy.json";
            App.dataFile.Content = File.ReadAllText(App.dataFile.FilePath);
            App.dataObject = JsonConvert.DeserializeObject<DataObjek>(App.dataFile.Content);*/
            
            
          
        }
    }
}
