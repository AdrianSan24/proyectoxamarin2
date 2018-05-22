using App3000;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveAndLoad))]
namespace App3000
{
    public class SaveAndLoad 
        {
            public void SaveText(string filename, string text)
            {
                var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
         
                var filePath = Path.Combine(documentsPath, filename);
                System.IO.File.WriteAllText(filePath, text);
            }
            public string LoadText(string filename)
            {
                var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var filePath = Path.Combine(documentsPath, filename);
                return System.IO.File.ReadAllText(filePath);
            }
        }
    }


