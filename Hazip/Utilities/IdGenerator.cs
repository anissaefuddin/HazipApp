using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazip.Utilities
{
    
    public class IdGenerator
    {
        public static string GenerateId()
        {
            // Generate GUID
            Guid guid = Guid.NewGuid();

            // Ubah GUID menjadi string tanpa tanda '-' dan ubah ke huruf kecil
            string id = guid.ToString("N").ToLower();

            // Hilangkan karakter yang tidak diperlukan
            id = RemoveUnwantedCharacters(id);

            return id;
        }

        private static string RemoveUnwantedCharacters(string input)
        {
            // Hapus karakter yang tidak diperlukan
            char[] unwantedChars = { '-', '{', '}', ' ' };
            foreach (char unwantedChar in unwantedChars)
            {
                input = input.Replace(unwantedChar.ToString(), "");
            }
            return input;
        }
    }
}
