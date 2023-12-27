using CalculationLibrary.DataModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Pechi.Data;

namespace Pechi.Models
{
    public class ResultPageModel
    {
        public OutputDataModel? OutputDataModel { get; set; }
        public DataRow? DataRow { get; set; }
        [BindProperty]
        public bool save { get; set; }
    }
}
