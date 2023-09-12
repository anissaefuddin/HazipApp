using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hazip.ViewModels.StudyData
{
    public class VM_Main : INotifyPropertyChanged
    {
        private DataObject _dataObject;
        public DataObject DataObject
        {
            get { return _dataObject; }
            set
            {
                if (_dataObject != value)
                {
                    _dataObject = value;
                    OnPropertyChanged(nameof(DataObject));
                }
            }
        }

        public VM_Main(DataObject dataObject)
        {
            // Inisialisasi properti GlobalData dengan nilai variabel global
            DataObject = dataObject;
        }

        // Implementasikan INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void ChangeOverview(DataObject dataObject)
        {
            //dataObject = "Nilai dari Halaman 1";
        }
    }

}
