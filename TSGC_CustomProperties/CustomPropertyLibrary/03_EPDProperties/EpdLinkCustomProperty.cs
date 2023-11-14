﻿using GC_CustomPropertyLibrary._00_Helpers;
using GC_CustomPropertyLibrary._02_GeneralProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                output=result!=""?result:output;//use default value if no result
            }
            else
            {
                output = "";
            }

            return output;
        }
    }
}
