using Hazip.ViewModels;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hazip.Views
{
    /// <summary>
    /// Interaction logic for Study_Attendance.xaml
    /// </summary>
    public partial class Study_Attendance : UserControl
    {
        public Study_Attendance()
        {
            InitializeComponent();
        }

        private void UpdatedCommand(object sender, DataTransferEventArgs e)
        {
            if (DataContext is VM_Attendance viewModel)
            {
                // Dapatkan ComboBox yang dipicu oleh event
                ComboBox comboBox = (ComboBox)sender;

                // Dapatkan item yang dipilih dari ComboBox
                ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;

                // Ubah nilai ViewModel sesuai dengan item yang dipilih
                if (selectedItem != null)
                {
                    viewModel.SelectedData.Value = selectedItem.Content.ToString();

                    // Sekarang Anda dapat menyimpan perubahan ke ViewModel sesuai kebutuhan Anda
                    //viewModel.SaveData(); // Anda perlu membuat metode SaveData() di ViewModel Anda
                }
            }
        }
    }
}
