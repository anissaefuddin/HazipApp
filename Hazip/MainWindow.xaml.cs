using Hazip.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;
using DataObject = Hazip.Models.DataObject;
using Hazip.Services;
using System.Runtime.InteropServices;

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
            
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    App.AppData.dataFile.FilePath = openFileDialog.FileName;
                    App.AppData.dataFile.Content = File.ReadAllText(App.AppData.dataFile.FilePath);
                    DataObject dataObject = JsonConvert.DeserializeObject<DataObject>(App.AppData.dataFile.Content);
                    MessageBox.Show(App.AppData.dataFile.Content, "JSON Data", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    WriteLogException.LogException(ex);
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
