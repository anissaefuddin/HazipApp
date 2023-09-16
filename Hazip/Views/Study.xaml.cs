using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hazip.Views
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Study : UserControl
    {
        public Study()
        {
            InitializeComponent();
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.S)
            {
                // Simulasi penyimpanan data (Anda dapat menggantinya dengan logika penyimpanan sesungguhnya)
                SimulateSaveData();
                ShowToast("Data berhasil disimpan!");
                e.Handled = true;
            }
        }

        // Simulasikan penyimpanan data
        private async void SimulateSaveData()
        {
            // Serialisasi data kembali ke JSON
            App.dataFile.Content = JsonConvert.SerializeObject(App.dataObject);
            if (App.dataFile.FilePath is null)
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                    DefaultExt = ".json",
                    FileName = "New File "
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    App.dataFile.FilePath = saveFileDialog.FileName;
                    File.WriteAllText(App.dataFile.FilePath, App.dataFile.Content);
                    App.dataFile.Content = File.ReadAllText(App.dataFile.FilePath);
                }
            }
            File.WriteAllText(App.dataFile.FilePath, App.dataFile.Content);
            await Task.Delay(TimeSpan.FromSeconds(2));
        }

        // Menampilkan pesan toast
        private void ShowToast(string message)
        {
            ToastGrid.Visibility = Visibility.Visible;
            ToastGrid.Height = 40;

            // Sembunyikan pesan toast setelah 3 detik
            Task.Delay(TimeSpan.FromSeconds(3)).ContinueWith(_ =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    ToastGrid.Visibility = Visibility.Collapsed;
                    ToastGrid.Height = 0;
                });
            });
        }
    }
}
