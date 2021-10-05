using Microsoft.EntityFrameworkCore;

namespace MasterClassHbo.Ipo
{
    public class IpoRegistrationContext: DbContext
    {
        public IpoRegistrationContext(DbContextOptions<IpoRegistrationContext> options) : base(options)
        {
        }

        public DbSet<RegistrationModel> Registrations { get; set; }
    }
}
