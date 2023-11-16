using GC_CustomPropertyLibrary._00_Helpers;
using System.ComponentModel.Composition;
using Tekla.Structures.CustomPropertyPlugin;
using Tekla.Structures.Model;

namespace GC_CustomPropertyLibrary._02_GeneralProperties
{
    [Export(typeof(ICustomPropertyPlugin))]
    [ExportMetadata("CustomProperty", "CUSTOM.GC_ELEMENT_TYPE")]
    public class ElementTypeCustomProperty : ICustomPropertyPlugin
    {
        Model model = new Model();

        public double GetDoubleProperty(int objectId) => 0;
        public int GetIntegerProperty(int objectId) => 0;
        public string GetStringProperty(int objectId)
        {
            string output = "";
            var assemblableObject= StaticHelpers.SelectModelObjectByID(objectId);
            var CastUnit = assemblableObject.GetAssembly(true);
            var MainPart=CastUnit.GetMainPart();

            string udaName = "PRODUCT_CODE";
            string cuUdaValue = "";
            string mainPartUdaValue = "";

            CastUnit.GetUserProperty(udaName,ref cuUdaValue);
            MainPart.GetUserProperty(udaName,ref mainPartUdaValue); 

            output= cuUdaValue!=""?cuUdaValue:mainPartUdaValue;

            if (output=="")
            {
                output=CastUnit.AssemblyNumber.Prefix;
            }

            return output;
        }
    }
}
