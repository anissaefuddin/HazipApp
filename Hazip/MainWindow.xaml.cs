using Hazip.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;
using DataObject = Hazip.Models.DataObject;
using Hazip.Screen.ViewModels.StudyData;
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
            VM_OverView vM_OverView = new VM_OverView();
        }

        

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    App.dataFile.FilePath = openFileDialog.FileName;
                    App.dataFile.Content = File.ReadAllText(App.dataFile.FilePath);
                    App.dataObject = JsonConvert.DeserializeObject<DataObject>(App.dataFile.Content);
                    //VM_OverView.loadDataOverview(App.dataObject.Overview);
                    SetDataOverView();
                    MessageBox.Show(App.dataFile.Content, "JSON Data", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    WriteLogException.LogException(ex);
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SetDataOverView()
        {
            VM_OverView vM_OverView = new VM_OverView();
            vM_OverView.StudyName = App.dataObject.Overview.Study_Name;
            string a = "";
        }
    }
}
