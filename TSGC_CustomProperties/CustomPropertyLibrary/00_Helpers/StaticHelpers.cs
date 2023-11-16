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

        public static Assembly GetAssembly(this ModelObject modelObject, bool getMainAssembly = true)
        {
            Assembly output = null;

            if (modelObject is Assembly)
            {
                Assembly currentAssembly= modelObject as Assembly;
                Assembly nextLevelAssembly=currentAssembly.GetAssembly();
                output = nextLevelAssembly == null ? currentAssembly : nextLevelAssembly;
            }
            else
            {
                IAssemblable assemblable= modelObject as IAssemblable;
                output=assemblable.GetAssembly();
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
