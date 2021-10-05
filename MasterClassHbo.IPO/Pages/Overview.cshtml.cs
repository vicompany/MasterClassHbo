using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MasterClassHbo.Ipo.Pages
{
    public class OverviewModel : PageModel
    {
        private readonly ILogger<OverviewModel> _logger;
        private readonly IpoRegistrationContext _context;
        public List<RegistrationModel> Items { get; set; }

        public OverviewModel(ILogger<OverviewModel> logger, IpoRegistrationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            this.Items = _context.Registrations.ToList();
        }
    }
}
