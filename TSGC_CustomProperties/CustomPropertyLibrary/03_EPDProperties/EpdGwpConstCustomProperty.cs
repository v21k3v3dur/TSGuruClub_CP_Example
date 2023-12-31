﻿using GC_CustomPropertyLibrary._00_Helpers;
using GC_CustomPropertyLibrary._02_GeneralProperties;
using System.ComponentModel.Composition;
using Tekla.Structures.CustomPropertyPlugin;

namespace GC_CustomPropertyLibrary._03_EPDProperties
{
    [Export(typeof(ICustomPropertyPlugin))]
    [ExportMetadata("CustomProperty", "CUSTOM.GC_EPD_GWP_CONST")]
    public class EpdGwpConstCustomProperty : ICustomPropertyPlugin
    {
        public double GetDoubleProperty(int objectId)
        {
            double output =0;
            var assemblableObject= StaticHelpers.SelectModelObjectByID(objectId);
            var CastUnit = assemblableObject.GetAssembly(true);
            var MainPart=CastUnit.GetMainPart();

            string elementType = new ElementTypeCustomProperty().GetStringProperty(objectId);

            if (elementType!="")
            {
                output = EpdDataHandler.GetGwpValue(elementType);
            }
            return output;
        }

        public int GetIntegerProperty(int objectId) => 0;

        public string GetStringProperty(int objectId)=>GetDoubleProperty(objectId).ToString();
    }
}
