using GC_CustomPropertyLibrary._00_Helpers;
using GC_CustomPropertyLibrary._02_GeneralProperties;
using System.ComponentModel.Composition;
using Tekla.Structures.CustomPropertyPlugin;

namespace GC_CustomPropertyLibrary._03_EPDProperties
{
    [Export(typeof(ICustomPropertyPlugin))]
    [ExportMetadata("CustomProperty","CUSTOM.GC_EPD_LINK")]
    public class EpdLinkCustomProperty : ICustomPropertyPlugin
    {
        public double GetDoubleProperty(int objectId) => 0;

        public int GetIntegerProperty(int objectId) => 0;

        public string GetStringProperty(int objectId)
        {
            string output = @"https://betoonelement.ee/sertifikaadid/";
            var assemblableObject= StaticHelpers.SelectModelObjectByID(objectId);
            var CastUnit = assemblableObject.GetAssembly(true);
            var MainPart=CastUnit.GetMainPart();

            string elementType = new ElementTypeCustomProperty().GetStringProperty(objectId);

            if (elementType != "")
            {
                string result = EpdDataHandler.GetEpdLink(elementType);
                output = result != "" ? result : output;//use default value if no result

                if (output.Length <= 89)
                {
                    return output;
                }
                output = output.Substring(0, 86) + "...";

                return output;
            }
            else
            {
                output = "";
            }

            return output;
        }
    }
}
