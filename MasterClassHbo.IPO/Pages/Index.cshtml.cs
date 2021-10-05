using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MasterClassHbo.Ipo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IpoRegistrationContext context;

        [BindProperty]
        public RegistrationModel Registration { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IpoRegistrationContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public void OnGet()
        {
            Registration = new RegistrationModel();
        }

        public IActionResult OnPost()
        {
            if (context.Registrations.Any(x => x.Email == Registration.Email))
            {
                ModelState.AddModelError($"{nameof(Registration)}.{nameof(Registration.Email)}", $"{Registration.Email} already registered");
            }

            if (Registration.Certificates && Registration.Stocks)
            {
                ModelState.AddModelError($"{nameof(Registration)}.{nameof(Registration.Stocks)}", "You can't choose stocks and certificates");
            }

            if (ModelState.IsValid)
            {
                context.Add(Registration);
                context.SaveChanges();
                return RedirectToPage("Registered");
            }
            else
            {
                return Page();
            }
        }
    }
}
