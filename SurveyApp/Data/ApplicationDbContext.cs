using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SurveyApp.Models;

namespace SurveyApp.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Questionaire> Questionaire { get; set; }
        public DbSet<Question> Questions { get; set; }

        public DbSet <Response> Responses{ get; set; }

        public DbSet <Survey> Surveys { get; set; }

        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Questionaire>().Navigation(q => q.Questions).AutoInclude();
        }
    }
}