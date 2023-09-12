using Hazip.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;
using Hazip.ViewModels.StudyData;
using Hazip.Services;
using System.Runtime.InteropServices;
using Hazip.Views.Pages;
using System.Windows.Controls;
using Hazip.ViewModels;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace Hazip
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

            NavigationVM vm = new NavigationVM();
            // loading file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    App.dataFile.FilePath = openFileDialog.FileName;
                    App.dataFile.Content = File.ReadAllText(App.dataFile.FilePath);
                    App.dataObject = JsonConvert.DeserializeObject<DataObjek>(App.dataFile.Content);
                    MessageBox.Show(App.dataFile.Content, "JSON Data", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private bool CanSave()
        {
            // Di sini Anda dapat menentukan apakah tindakan Save seharusnya diizinkan
            return true; // Izinkan selalu untuk contoh ini
        }
        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
       

    }
}
