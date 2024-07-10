using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class CreditCardContext : DbContext
    {
        public CreditCardContext(DbContextOptions<CreditCardContext> options)
        : base(options)
        {
        }

        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<ValidationRequest> ValidationRequests { get; set; }
    }
}
