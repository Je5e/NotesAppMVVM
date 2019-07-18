using Java.Nio.FileNio;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp
{
   public class FileAccessHelper
    {
        public static string GetLocalFilePath(string fileName)
        {
            return System.IO.Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.LocalApplicationData), fileName);
        }
    }
}
