using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tekla.Structures.Model;

namespace GC_CustomPropertyLibrary._00_Helpers
{
    public static class StringHelpers
    {
        public static string ReplaceDoubleTemplatePropertyPlaceholdersWithValues(this Assembly assembly,string template)
        {
            string output= template;
            try
            {
                List<string> placeholders = template.ExtractPlaceholders();
                List<string> propertyValues = new List<string>();
                if (placeholders.Count > 0)
                {
                    List<string> propertyNames = template.ExtractUserPropertyNames();
                    foreach (string name in propertyNames)
                    {
                        double value = 0;
                        assembly.GetReportProperty(name, ref value);
                        propertyValues.Add(value.ToString());
                    }
                    for (int i = 0; i < placeholders.Count; i++)
                    {
                        output = output.Replace(placeholders[i], propertyValues[i]);
                    }
                }
            }
            catch (System.Exception)
            {
                output=template;
            } 

            return output;
        }

        private static List<string> ExtractPlaceholders(this string input)
        {
            return input.RegexGroupsToList(@"(<[^>]*>)");
        }
        private static List<string> ExtractUserPropertyNames(this string input)
        {
            return input.RegexGroupsToList(@"<([^>]*)>");
        }
        private static List<string> RegexGroupsToList(this string input,string pattern)
        {
            List<string> output= new List<string>();
            try
            {
                Regex regex = new Regex(pattern);
                Match match = regex.Match(input);
                if (match.Success)
                {
                    output.AddRange(regex
                        .Matches(input)
                        .Cast<Match>()
                        .Select(x => x.Groups[1].Value));
                }
            }
            catch (System.Exception)
            {
                output.Add("");
            }            
            return output;
        }
    }
}
