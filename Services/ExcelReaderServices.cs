using Domain;
using Interfaces;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Services
{
    public class ExcelReaderServices : IFileReaderServices
    {
        public IList<FileData> Read(string path)
        {
            IList<FileData> result = new List<FileData>();

            FileInfo existingFile = new FileInfo(path);

            using (ExcelPackage package = new ExcelPackage(existingFile))
            {

                
                for (int w = 0; w < package.Workbook.Worksheets.Count; w++)
                {
                    //get the first worksheet in the workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[w];
                    int colCount = worksheet.Dimension.End.Column;  //get Column Count
                    int rowCount = worksheet.Dimension.End.Row;

                    //get row count
                    for (int row = 1; row <= rowCount; row++)
                    {
                        FileData temp = new FileData();
                        temp.DocumnetNumber = worksheet.Cells[row, 1].Text;
                        temp.WorkShetName = worksheet.Name;
                        result.Add(temp);
                    }
                }
            }

            return result;
        }

       
    }
}
