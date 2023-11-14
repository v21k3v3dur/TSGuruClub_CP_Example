using GC_CustomPropertyLibrary._02_GeneralProperties;
using GC_CustomPropertyLibrary._03_EPDProperties;
using NUnit.Framework;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;
using TSMUI=Tekla.Structures.Model.UI;
using static GC_CustomPropertyTests.StaticHelpers;

namespace GC_CustomPropertyTests
{
    [TestFixture]
    [Explicit]
    public class ExplicitTests
    {
        Model model;
        int objectID;
        ModelObject modelObject;


        [SetUp]
        public void Initialize()
        {
            model = new Model();
            TSMUI.ModelObjectSelector objectSelector=new TSMUI.ModelObjectSelector();
            ModelObjectEnumerator objectEnumerator= objectSelector.GetSelectedObjects();
            while (objectEnumerator.MoveNext())
            {
                modelObject = objectEnumerator.Current;
            }
            objectID = modelObject.Identifier.ID;
        }

        [Test]
        public void ElementTypeCPTest() 
        {
            var cp = new ElementTypeCustomProperty();
            string stringResult= cp.GetStringProperty(objectID);
            int intResult=cp.GetIntegerProperty(objectID);
            double doubleReslut=cp.GetDoubleProperty(objectID);

            LogCPtoTestConsole(
                cp.GetType(),
                stringResult,
                intResult,
                doubleReslut);
        }

        [Test]
        public void EpdGwpConstCPTest() 
        {
            var cp = new EpdGwpConstCustomProperty();
            string stringResult= cp.GetStringProperty(objectID);
            int intResult=cp.GetIntegerProperty(objectID);
            double doubleReslut=cp.GetDoubleProperty(objectID);

            LogCPtoTestConsole(
                cp.GetType(),
                stringResult,
                intResult,
                doubleReslut);
        }


        [Test]
        public void EpdLinkCPTest() 
        {
            var cp = new EpdLinkCustomProperty();
            string stringResult= cp.GetStringProperty(objectID);
            int intResult=cp.GetIntegerProperty(objectID);
            double doubleReslut=cp.GetDoubleProperty(objectID);

            LogCPtoTestConsole(
                cp.GetType(),
                stringResult,
                intResult,
                doubleReslut);
        }

        [Test]
        public void EpdNumberCPTest() 
        {
            var cp = new EpdNumberCustomProperty();
            string stringResult= cp.GetStringProperty(objectID);
            int intResult=cp.GetIntegerProperty(objectID);
            double doubleReslut=cp.GetDoubleProperty(objectID);

            LogCPtoTestConsole(
                cp.GetType(),
                stringResult,
                intResult,
                doubleReslut);
        }

        [Test]
        public void EpdResultCPTest() 
        {
            var cp = new EpdResultCustomProperty();
            string stringResult= cp.GetStringProperty(objectID);
            int intResult=cp.GetIntegerProperty(objectID);
            double doubleReslut=cp.GetDoubleProperty(objectID);

            LogCPtoTestConsole(
                cp.GetType(),
                stringResult,
                intResult,
                doubleReslut);
        }

        [Test]
        public void EpdUnitCPTest() 
        {
            var cp = new EpdUnitCustomProperty();
            string stringResult= cp.GetStringProperty(objectID);
            int intResult=cp.GetIntegerProperty(objectID);
            double doubleReslut=cp.GetDoubleProperty(objectID);

            LogCPtoTestConsole(
                cp.GetType(),
                stringResult,
                intResult,
                doubleReslut);
        }

    }
}
