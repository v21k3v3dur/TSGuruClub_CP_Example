using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC_CustomPropertyTests
{
    internal static class StaticHelpers
    {

        public static void LogCPtoTestConsole(Type type, string stringResult, int intResult, double doubleResult)
        {
            string CpName=type.Name;
            var exportMetadataAttributes = type.GetCustomAttributes(typeof(ExportMetadataAttribute), true);
            foreach (var attribute in exportMetadataAttributes)
            {
                if (attribute is ExportMetadataAttribute exportMetadata)
                {
                    CpName = exportMetadata.Name == "CustomProperty" ? exportMetadata.Value.ToString() : CpName;
                }
            }

            string message = $"{CpName}: str='{stringResult}', int='{intResult}', double='{doubleResult}'";

            Log.Information(message);
        }

    }
}
