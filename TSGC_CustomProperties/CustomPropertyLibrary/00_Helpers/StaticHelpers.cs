using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;
using Tekla.Structures;
using static GC_CustomPropertyLibrary._00_Helpers.StringHelpers;

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
        public static bool IsHighestLevel(this Assembly assembly)
        {
            bool output=assembly.GetAssembly()==null?true:false;

            return output;
        }


        public static (bool success, string value) ElementTypeFromUda(this Assembly assembly, string udaName)
        {
            string output;
            bool success;

            try
            {
                string assemblyUda = "";
                assembly.GetUserProperty(udaName, ref assemblyUda);

                string mPartUda = "";
                assembly.GetMainPart().GetUserProperty(udaName, ref mPartUda);

                output = assemblyUda == "" ? mPartUda : assemblyUda;

                success = (!string.IsNullOrEmpty(output));
            }
            catch (Exception)
            {
                success = false;
                output = "";
            }
            return (success, output);
        }

        public static (bool success, string value) ElementTypeFromAssemblyPrefix(this Assembly assembly)
        {
            bool success;
            string output;
            try
            {
                string posPrefix = assembly.AssemblyNumber.Prefix;
                //string template = posPrefix.GetElementTypeTemplateByCuPrefix();
                var template = "ElementTypeFromAssemblyPrefix";
                output = assembly.ReplaceDoubleTemplatePropertyPlaceholdersWithValues(template);
                success = (!string.IsNullOrEmpty(output));
            }
            catch (Exception)
            {
                success = false;
                output = "";
            }
            return (success, output);
        }

        public static (bool success, string value) ElementTypeFromProfile(this Assembly assembly)
        {
            bool success;
            string output;
            try
            {
                Part part = assembly.GetMainPart() as Part;
                string profile = part.Profile.ProfileString;
                //string template = profile.GetElementTypeTemplateByProfilePrefix();
                var template = "ElementTypeFromProfile";
                output = assembly.ReplaceDoubleTemplatePropertyPlaceholdersWithValues(template);
                success = (!string.IsNullOrEmpty(output));

            }
            catch (Exception)
            {
                success = false;
                output = "";
            }
            return (success, output);
        }

    }
}
