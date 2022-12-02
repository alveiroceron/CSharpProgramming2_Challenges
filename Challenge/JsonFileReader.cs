using System.Collections.Generic;
using System.IO;

namespace Challenge
{
    public delegate void Notify<T>(List<T> students);

    public class JsonFileReader<T>
    {
        public event Notify<T> OnFileRead;
        public void ReadJsonFile(string filePath)
        {

            using (StreamReader stReader = new StreamReader(filePath))
            {
                var json = stReader.ReadToEnd();
                List<T> elements = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(json);
                OnFileRead?.Invoke(elements);

            }
        }
    }
}
