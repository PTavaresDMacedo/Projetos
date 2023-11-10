using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Model;
using Receitas.Service.Measures;

namespace Tastebook.WebApp.Pages.Measures
{
    public class RetrieveAllModel : PageModel
    {
        private readonly IMeasureService _measureService;

        public RetrieveAllModel(IMeasureService measureService)
        {
            _measureService = measureService;
        }

        public List<Measure> measures { get; set; }

        public void OnGet()
        {
            measures = _measureService.RetrieveAll();
        }

        public void OnPost()
        {
            Measure measure = new Measure();
            measure.MeasureType = Convert.ToString(Request.Form["measure_type"]);
            _measureService.Create(measure);
            measures = _measureService.RetrieveAll();
        }
    }
}
