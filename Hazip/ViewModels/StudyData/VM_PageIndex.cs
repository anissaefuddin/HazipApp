using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hazip.ViewModels.StudyData
{
    public class VM_PageIndex
    {
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl tabControl)
            {
               /* if (tabControl.SelectedItem is TabItem selectedTab)
                {
                    if (selectedTab == TabOverview) // Ganti TabOverview dengan nama TabItem Anda
                    {
                        // Reload frame dengan source yang sama untuk memuat ulang halaman
                        OverView.Source = new Uri("./OverView.xaml", UriKind.Relative);
                    }
                }*/
            }
        }
    }
}
