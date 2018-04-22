using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FFRKApi.Data.Api
{
    public interface IAltemaCharacterRatingRepository
    {
        Stream GetAltemaCharacterRatingStream();

        string GetAltemaCharacterRatingString();
    }

    //just for testing
    public class AltemaCharacterRatingFileRepository : IAltemaCharacterRatingRepository
    {        
        private const string fileName = "Altema_Charyoka_JP_20180418.html";

        public Stream GetAltemaCharacterRatingStream()
        {
            string directory = Directory.GetCurrentDirectory();

            Stream fileStream = null;

            string filePath = $"{directory}\\{fileName}";

            fileStream = new StreamReader(filePath).BaseStream;

            return fileStream;
        }

        public string GetAltemaCharacterRatingString()
        {
            string directory = Directory.GetCurrentDirectory();

            string filePath = $"{directory}\\{fileName}";

            string text = File.ReadAllText(filePath);

            return text;
        }
    }
}
