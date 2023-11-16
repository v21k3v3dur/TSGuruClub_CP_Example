using GC_CustomPropertyLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GC_CustomPropertyLibrary._00_Helpers
{
    public static class EpdDataAccess
    {
        private static string assemblyFullPath = Assembly.GetExecutingAssembly().Location;
        private static string assemblyFolderPath=Path.GetDirectoryName(assemblyFullPath);
        private static string filename = @"CU_EPD_Data.csv";
        private static string fullPath = Path.Combine(assemblyFolderPath,"01_InputData", filename);


        public static List<EpdDataModel> GetData()
        {
            return ReadAllRecords(fullPath, ';');
        }

        public static List<EpdDataModel> ReadAllRecords(string textFile, char separator=';')
        {
            if (File.Exists(textFile)==false)
            {
                return new List<EpdDataModel>();
            }
            var lines = File.ReadAllLines(textFile).ToList();
            lines.RemoveAt(0);

            List<EpdDataModel> output=new List<EpdDataModel>();

            foreach (var line in lines)
            {
                EpdDataModel c = new EpdDataModel();
                var vals = line.Split(separator);

                if (vals.Length!=6)
                {
                    //throw new Exception($"Invalid row of data: {line}");
                    continue;
                }
                else if (vals[0].StartsWith("//"))
                {
                    continue;
                }

                c.ProductCode=vals[0];
                c.EpdNumber=vals[1];
                DeclarationUnit unit=new DeclarationUnit();
                    Enum.TryParse(vals[2].ToLower(), out unit);
                c.DeclaredUnit = unit;
                c.GwpA1_3 = Double.Parse( vals[3]);
                c.CalculationFieldName=vals[4];
                c.EpdLink = vals[5];

                output.Add(c);  

            }

            return output;
        }

        

    }
}
