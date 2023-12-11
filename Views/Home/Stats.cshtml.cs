using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Web3_Beadando.Views.Home
{
    public class StatsModel : PageModel
    {
        public int[] ChartData { get; set; } = { 10, 20, 30, 40, 50 };
        public string ChartDataJson => JsonConvert.SerializeObject(ChartData);

        public string[] ChartLabels { get; set; } = { "Label 1", "Label 2", "Label 3", "Label 4", "Label 5" };
        public string ChartLabelsJson => JsonConvert.SerializeObject(ChartLabels);

        public void OnGet()
        {
        }
    }
}
