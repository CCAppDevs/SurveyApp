using Microsoft.AspNetCore.Identity;
using SurveyApp.Models;

namespace SurveyApp.Data
{
    public class SeedData
    {
        public static async Task EnsurePopulated(IServiceProvider services)
        {
            ApplicationDbContext context = services.GetService<ApplicationDbContext>();
            IConfiguration configuration = services.GetService<IConfiguration>();

            if (context == null)
            {
                throw new NullReferenceException("No context available");
            }

            for (int i = 0; i < 5; i++)
            {
                Questionaire seed = new Questionaire
                {

                    Questions = new List<Question>
                    {
                        new Question
                        {
                            Responses = new List<Response>
                            {
                                new Response
                                {

                                }
                            }
                        }
                    }

                };

                context.Questionaire.Add(seed);

                await context.SaveChangesAsync();

            }

        }
    }
}
