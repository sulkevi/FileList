using Domain;
using Services;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Excel = Microsoft.Office.Interop.Excel;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using OfficeOpenXml;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Quartz;

namespace FileList
{
    public class FileSearch
    {
        
        static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",false,true);
            var config = builder.Build();
            var appConfig = config.GetSection("ApplicationSettings").Get<ApplicationSettings>();

            var mainService = new MainService();
                mainService.Run(appConfig);

             Console.ReadLine();
        }

      
    }
  

}


