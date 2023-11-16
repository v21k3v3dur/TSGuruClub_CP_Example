using System.ComponentModel.Composition;
using Tekla.Structures.CustomPropertyPlugin;
using GC_CustomPropertyLibrary._00_Helpers;
using GC_CustomPropertyLibrary._02_GeneralProperties;
using GC_CustomPropertyLibrary.Models;

namespace GC_CustomPropertyLibrary._03_EPDProperties
{
    [Export(typeof(ICustomPropertyPlugin))]
    [ExportMetadata("CustomProperty", "CUSTOM.GC_EPD_GWP_A1-A3")]
    public class EpdResultCustomProperty:ICustomPropertyPlugin
    {
        public double GetDoubleProperty(int objectId)
        {
            double output = 0;
            var assemblableObject= StaticHelpers.SelectModelObjectByID(objectId);
            var CastUnit = assemblableObject.GetAssembly(true);
            var MainPart=CastUnit.GetMainPart();

            string elementType = new ElementTypeCustomProperty().GetStringProperty(objectId);

            if (elementType == "")
            {
                return output;
            }

            DeclarationUnit declarationUnit =EpdDataHandler.GetDeclaredUnit(elementType);
            double gwpConst= EpdDataHandler.GetGwpValue(elementType);
            string calcPropName= EpdDataHandler.GetCalculationFieldName(elementType);
            double calcPropValue=0;
            CastUnit.GetReportProperty(calcPropName,ref calcPropValue);

            switch (declarationUnit)
            {
                case DeclarationUnit.kg:
                    output = gwpConst * calcPropValue;
                    break;
                case DeclarationUnit.t:
                    output = gwpConst * calcPropValue * 1e-3;
                    break;
                case DeclarationUnit.m:
                    output = gwpConst * calcPropValue * 1e-3;
                    break;
                case DeclarationUnit.m2:
                    output = gwpConst * calcPropValue * 1e-6;
                    break;
                case DeclarationUnit.m3:
                    output = gwpConst * calcPropValue * 1e-9;
                    break;
                case DeclarationUnit.pcs:
                    output = gwpConst * calcPropValue;
                    break;
                default:
                    break;
            }

            return output;
        }

        public int GetIntegerProperty(int objectId) => 0;

        public string GetStringProperty(int objectId)=>GetDoubleProperty(objectId).ToString();
    }
}
