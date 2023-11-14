using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using GC_CustomPropertyLibrary._00_Helpers;
using Tekla.Structures.CustomPropertyPlugin;
using GC_CustomPropertyLibrary._02_GeneralProperties;

namespace GC_CustomPropertyLibrary._03_EPDProperties
{
    [Export(typeof(ICustomPropertyPlugin))]
    [ExportMetadata("CustomProperty", "CUSTOM.GC_EPD_DECLARED_UNIT")]
    public class EpdUnitCustomProperty : ICustomPropertyPlugin
    {
        public double GetDoubleProperty(int objectId) => 0;


        public int GetIntegerProperty(int objectId) => 0;

        public string GetStringProperty(int objectId)
        {
            string output = "";
            var assemblableObject= StaticHelpers.SelectModelObjectByID(objectId);
            var CastUnit = assemblableObject.GetAssembly(true);
            var MainPart=CastUnit.GetMainPart();

            string elementType = new ElementTypeCustomProperty().GetStringProperty(objectId);

            if (elementType!="")
            {
                output = EpdDataHandler.GetDeclaredUnit(elementType).ToString();
            }
            return output;
        }
    }
}
