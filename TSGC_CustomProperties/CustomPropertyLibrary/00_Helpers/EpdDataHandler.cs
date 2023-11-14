using GC_CustomPropertyLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static GC_CustomPropertyLibrary._00_Helpers.EpdDataAccess;

namespace GC_CustomPropertyLibrary._00_Helpers
{
    public static class EpdDataHandler
    {
        private static string folderPath = AppDomain.CurrentDomain.BaseDirectory;
        private static string filename = @"CU_EPD_Data.csv";
        private static string fullPath = Path.Combine(folderPath,"01_InputData", filename);
        private static List<EpdDataModel> _data = ReadAllRecords(fullPath);

        public static string GetEpdNumber(this string elementType)
        {
            string output = "";
            output = _data.FilterByElementType(elementType).EpdNumber;
            return output;
        }

        public static DeclarationUnit GetDeclaredUnit(this string elementType)
        {
            DeclarationUnit output;
            output = _data.FilterByElementType(elementType).DeclaredUnit;
            return output;
        }

        public static double GetGwpValue(this string elementType)
        {
            double output = 0;
            output = _data.FilterByElementType(elementType).GwpA1_3;
            return output;
        }

        public static string GetCalculationFieldName(this string elementType)
        {
            string output = "";
            output = _data.FilterByElementType(elementType).CalculationFieldName;
            return output;
        }
        public static string GetEpdLink(this string elementType)
        {
            string output = "";
            output = _data.FilterByElementType(elementType).EpdLink;
            return output;
        }


        private static EpdDataModel FilterByElementType(
            this List<EpdDataModel> list,
            string typeString,
            string typePattern = @".*")
        {
            EpdDataModel output = new EpdDataModel();
            var result= _data.
                Where(x => x.ProductCode!= null &&
                Regex.IsMatch(typeString,@"^"+x.ProductCode+typePattern)).Distinct().ToList();

            output = result.Count > 0 ? result[0] : output;

            return output;
        }
    }
}
