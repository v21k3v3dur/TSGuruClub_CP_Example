using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC_CustomPropertyLibrary.Models
{
    public class EpdDataModel
    {
        public string ProductCode { get; set; }
        public string EpdNumber { get; set; }
        public string EpdLink { get; set; }
        public DeclarationUnit DeclaredUnit { get; set; }
        public double GwpA1_3 { get; set; }
        public string CalculationFieldName { get; set; }
    }
    public enum DeclarationUnit
    {
        kg,
        t,
        m,
        m2,
        m3,
        pcs
    }
}
