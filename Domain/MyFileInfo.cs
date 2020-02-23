using System;
using System.Collections.Generic;

namespace Domain
{
    public class MyFileInfo
    {
        public long Id { get; set; }
        public string FilePath { get; set; }

        public string FileName { get; set; }

        public DateTime LastModData { get; set; }
        public DateTime CreateData { get; set; }

        public IList<FileData> FileData { get; set; }
    }
}
