using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Hazip.Services
{
    public class JsonFileService
    {
        private static readonly string FilePath = "students.json";

        /*public static ObservableCollection<Student> LoadStudents()
        {
            if (File.Exists(FilePath))
            {
                string jsonContent = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<ObservableCollection<Student>>(jsonContent);
            }
            return new ObservableCollection<Student>();
        }

        public static void SaveStudents(ObservableCollection<Student> students)
        {
            string jsonContent = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(FilePath, jsonContent);
        }*/
    }
}
