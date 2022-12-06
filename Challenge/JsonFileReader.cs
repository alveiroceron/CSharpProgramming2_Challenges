using Challenge.Models;
using System.Collections.Generic;
using System.IO;

namespace Challenge
{
    public class FileReadEventArgs<T> : EventArgs
    {
        public  List<T> Students { get; set; }

        public FileReadEventArgs(List<T> students)
        {
            Students = students;
        }
    }

    public class JsonFileReader<T>
    {
        public event EventHandler<FileReadEventArgs<T>> FileRead;

        protected virtual void OnFileRead(FileReadEventArgs<T> e)
        {
            FileRead?.Invoke(this, e);
        }

        public void ReadJsonFile(string filePath)
        {

            using (StreamReader stReader = new StreamReader(filePath))
            {
                var json = stReader.ReadToEnd();
                List<T> elements = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(json);
                OnFileRead(new FileReadEventArgs<T>(elements));

            }
        }
    }
}
