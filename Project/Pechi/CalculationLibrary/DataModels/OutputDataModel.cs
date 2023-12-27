using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationLibrary.DataModels
{
    public class OutputDataModel
    {
        public List<RowModel> RowModels { get; set; } = new List<RowModel>();
        public double m { get; set; }
        public double Y0 { get; set; }
        public double Y1 { get; set; }
        public double Y1_DOP { get; set; }
    }
}
