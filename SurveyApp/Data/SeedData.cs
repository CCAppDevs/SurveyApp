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

            if (!context.Questionaire.Any() && !context.Questions.Any() && !context.Responses.Any() && !context.Surveys.Any())
            {
                var questionaires = new List<Questionaire>
                {
                    new Questionaire { Title = "Questionaire 1", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Questionaire { Title = "Questionaire 2", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Questionaire { Title = "Questionaire 3", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },

                };

                var questions = new List<Question>
                {
                    new Question { QuestionaireId = 1, Prompt = "Prompt", PromptType = 1}
                };

                var responses = new List<Response>
                {
                    
                };

                var surveys = new List<Survey>
                {

                };

                context.AddRange(questionaires, questions, responses, surveys);
                context.SaveChanges();
            }
        }
    }
}
