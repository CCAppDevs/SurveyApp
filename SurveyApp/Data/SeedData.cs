using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

            if (!context.Questionaire.Any())
            {
                var questionaires = new List<Questionaire>
                {
                    new Questionaire { Title = "Questionaire 1", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Questionaire { Title = "Questionaire 2", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Questionaire { Title = "Questionaire 3", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },

                };

                context.AddRange(questionaires);
                context.SaveChanges();
            }

            if (!context.Questions.Any())
            {
                var questions = new List<Question>
                {
                    new Question { QuestionaireId = 1, Prompt = "Prompt", PromptType = 1}
                };

                context.AddRange(questions); 
                context.SaveChanges();
            }

        }
    }
}
