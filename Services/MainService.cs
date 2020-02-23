using Domain;
using Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class MainService
    {
        FileReaderService service;
        IFileReaderServices excelReaderServices;

        public MainService()
        { 
         service = new FileReaderService();
         excelReaderServices = new ExcelReaderServices();
        }

        public void Run(ApplicationSettings appConfig)
        {
         
            IList<MyFileInfo> fileList = service.GetAllFilesFromDirectory(appConfig.Directory, appConfig.Statement);

            foreach (var f in fileList)
            {
                var data = excelReaderServices.Read(f.FilePath);
                f.FileData = data;
            }
        }
    }
}
