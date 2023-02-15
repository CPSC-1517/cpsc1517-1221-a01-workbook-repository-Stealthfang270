using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BoringWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public DateTime CurrentDateTime = DateTime.Now;



        public int LuckyNumber { get; private set; } = 0;

        public void OnGet()
        {
            Random random = new Random();
            LuckyNumber = random.Next(0, 51);
        }
    }
}