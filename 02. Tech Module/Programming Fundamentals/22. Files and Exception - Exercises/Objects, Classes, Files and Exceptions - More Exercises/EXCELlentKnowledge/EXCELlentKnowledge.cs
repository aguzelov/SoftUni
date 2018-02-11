using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace EXCELlentKnowledge
{
    class EXCELlentKnowledge
    {
        static void Main(string[] args)
        {

            Excel.Application xlsxApp = new Excel.Application();

            Excel.Workbook xlsxWorkbook = xlsxApp.Workbooks.Open(@"C:\Users\Aleksandur\Desktop\Homeworks\Objects, Classes, Files and Exceptions - More Exercises\EXCELlentKnowledge\sample_table.xlsx");

            Excel._Worksheet xlsxWorksheet = xlsxWorkbook.Sheets[1];

            Excel.Range xlsxRange = xlsxWorksheet.UsedRange;

            int rowCount = xlsxRange.Rows.Count;

            int colCount = xlsxRange.Columns.Count;

            string text = "";

            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    string currentValue = "";

                    if (xlsxRange.Cells[i, j] != null &&
                        xlsxRange.Cells[i, j].Value2 != null )
                    {
                       currentValue = xlsxRange.Cells[i, j].Value2.ToString() + "|";
                    }
                    if (currentValue != "")
                    {
                        Console.WriteLine("currentValue:  " + currentValue);
                        text += currentValue;
                    }
                }
                text += "\n";
                
            }

            string path = @"C:\Users\Aleksandur\Desktop\Homeworks\Objects, Classes, Files and Exceptions - More Exercises\EXCELlentKnowledge\sample_output_table.txt";

            File.WriteAllText(path, text);

            Console.WriteLine(text);

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.ReleaseComObject(xlsxRange);
            Marshal.ReleaseComObject(xlsxWorksheet);

            xlsxWorkbook.Close();
            Marshal.ReleaseComObject(xlsxWorkbook);

            xlsxApp.Quit();
            Marshal.ReleaseComObject(xlsxApp);
        }
    }
}
