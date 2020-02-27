using Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Services
{
    public class FileReaderService
    {
 

        public IList<MyFileInfo> GetAllFilesFromDirectory(string Dir, string patern)
        {
            Regex rgx = new Regex(patern);
            IList<MyFileInfo> result = new List<MyFileInfo>();
           
            //tablica sciezek dostepu do kolejnych plikow z tego folderu
            var listFiles = Directory.GetFiles(Dir);

            foreach (var path in listFiles)
            {
                if (rgx.IsMatch(path))
                {
                    MyFileInfo myFileInfo = new MyFileInfo();
                    myFileInfo.FilePath = path;
                    myFileInfo.FileName = Path.GetFileName(path);

                    myFileInfo.CreateData = File.GetCreationTime(path);
                    myFileInfo.LastModData = File.GetLastWriteTime(path);
                    
                    result.Add(myFileInfo);
                }
            }
           
         return result;
        }
    }
}
