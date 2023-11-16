using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;
using Tekla.Structures;

namespace GC_CustomPropertyLibrary._00_Helpers
{
    public static class StaticHelpers
    {
        public static ModelObject SelectModelObjectByID(int objectID)
        {
            Identifier identifier = new Identifier(objectID);
            ModelObject output = new Model().SelectModelObject(identifier);
            return output;
        }

        public static Assembly GetAssembly(this ModelObject assemblableObject, bool getMainAssembly = true)
        {
            Assembly output = null;

            if (assemblableObject is Assembly)
            {
                output= assemblableObject as Assembly;
            }
            else
            {
                output=assemblableObject.GetAssembly();
            }

            bool isMainAsembly = output.GetAssembly() == null ? true : false;

            while (isMainAsembly == false && getMainAssembly)
            {
                output = output.GetAssembly();
                isMainAsembly = output.GetAssembly() == null ? true : false;
            }
            return output;
        }

    }
}
