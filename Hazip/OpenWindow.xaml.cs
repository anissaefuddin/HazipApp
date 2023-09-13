using Hazip.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hazip
{
    /// <summary>
    /// Interaction logic for OpenWindow.xaml
    /// </summary>
    public partial class OpenWindow : Window
    {
        public OpenWindow()
        {
            InitializeComponent();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

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
    }
}
