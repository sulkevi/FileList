using Domain;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IFileReaderServices
    {
        IList<FileData> Read(string path);
    }
}
