using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MasterClassHbo.Lunch.Pages
{
    public class RegisteredModel : PageModel
    {
        private readonly ILogger<RegisteredModel> _logger;

        public RegisteredModel(ILogger<RegisteredModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
