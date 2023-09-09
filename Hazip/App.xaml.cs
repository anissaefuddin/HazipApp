using Hazip.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
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
        public static class AppData
        {
            public static DataFile dataFile {  get; set; }

            public static DataObject dataObject { get; set; }
            public static string GlobalString { get; set; }
            public static int GlobalInt { get; set; }
            // Tambahkan properti lain yang Anda perlukan di sini
        }
    }
}
