using Hazip.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;
using Hazip.ViewModels;
using Hazip.Services;
using System.Runtime.InteropServices;
using Hazip.Views.Pages;
using System.Windows.Controls;
using Hazip.ViewModels;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.Diagnostics;

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

        }
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            
            if (App.dataObject.Overview == null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    try
                    {
                        App.dataFile.FilePath = openFileDialog.FileName;
                        App.dataFile.Content = File.ReadAllText(App.dataFile.FilePath);
                        App.dataObject = JsonConvert.DeserializeObject<DataObjek>(App.dataFile.Content);
                        MessageBox.Show("Data successfully load!", "JSON Data", MessageBoxButton.OK, MessageBoxImage.Information);
                        MainWindow windowKedua = new MainWindow();
                        this.Close();
                        windowKedua.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBoxResult Result = MessageBox.Show("Are you sure to close this project?", "Close project", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (Result == MessageBoxResult.Yes)
                {

                    new OpenWindow();

                    this.Close();
                }
                else if (Result == MessageBoxResult.No)
                {
                }
            }

        }

      
        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
       

    }
}
