using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SurveyApp.Models;
using System.Runtime.CompilerServices;

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

            if (configuration == null)
            {
                throw new NullReferenceException("No configuration available");
            }

            //if (!context.Questionaire.Any() && !context.Questions.Any() && !context.Responses.Any() && !context.Surveys.Any())
            //{
            //    var questionaires = new List<Questionaire>
            //    {
            //        new Questionaire { Title = "Questionaire 1", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
            //        new Questionaire { Title = "Questionaire 2", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
            //        new Questionaire { Title = "Questionaire 3", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
            //        new Questionaire { Title = "Questionaire 4", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
            //    };

            //    var questions = new List<Question>
            //    {
            //        new Question { Prompt = "Prompt", PromptType = 1},
            //        new Question { Prompt = "Prompt", PromptType = 2},
            //        new Question { Prompt = "Prompt", PromptType = 1},
            //        new Question { Prompt = "Prompt", PromptType = 2},
            //        new Question { Prompt = "Prompt", PromptType = 1},
            //        new Question { Prompt = "Prompt", PromptType = 2},
            //        new Question { Prompt = "Prompt", PromptType = 1},
            //        new Question { Prompt = "Prompt", PromptType = 2},
            //    };

            //    var responses = new List<Response>
            //    {
            //        new Response { QuestionID = 1, NumericResponse =  1},
            //        new Response { QuestionID = 1, NumericResponse =  2},
            //        new Response { QuestionID = 1, TextResponse =  "Response"},
            //        new Response { QuestionID = 1, TextResponse =  "Response2"},
            //        new Response { QuestionID = 2, NumericResponse =  1},
            //        new Response { QuestionID = 2, NumericResponse =  2},
            //        new Response { QuestionID = 2, TextResponse =  "Response"},
            //        new Response { QuestionID = 2, TextResponse =  "Response2"},
            //        new Response { QuestionID = 3, NumericResponse =  1},
            //        new Response { QuestionID = 3, NumericResponse =  2},
            //        new Response { QuestionID = 3, TextResponse =  "Response"},
            //        new Response { QuestionID = 3, TextResponse =  "Response2"},
            //        new Response { QuestionID = 4, NumericResponse =  1},
            //        new Response { QuestionID = 4, NumericResponse =  2},
            //        new Response { QuestionID = 4, TextResponse =  "Response"},
            //        new Response { QuestionID = 4, TextResponse =  "Response2"},
            //    };

            //    var surveys = new List<Survey>
            //    {
            //        new Survey { QuestionaireId = 1, AdministeredDate = DateTime.Now, Instructor = "Jesse Harlan", Location = "WAH216"},
            //        new Survey { QuestionaireId = 2, AdministeredDate = DateTime.Now, Instructor = "Johnny Appleseed", Location = "WAH215"},
            //        new Survey { QuestionaireId = 3, AdministeredDate = DateTime.Now, Instructor = "John Doe", Location = "WAH214"},
            //        new Survey { QuestionaireId = 4, AdministeredDate = DateTime.Now, Instructor = "John F Kennedy", Location = "WAH213"},
            //    };

            //    context.Questionaire.AddRange(questionaires);
            //    context.Questions.AddRange(questions);
            //    context.Responses.AddRange(responses);
            //    context.Surveys.AddRange(surveys);

            //    context.SaveChanges();
            //}


            for (int i = 0; i < 4; i++)
            {
                Questionaire questionaires = new Questionaire
                {
                    Title = "Questionaire " + i++,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,

                    Questions = new List<Question>
                    {
                        new Question { Prompt = "Prompt", PromptType = 1},
                        new Question { Prompt = "Prompt", PromptType = 2},
                    }
                };

                context.Questionaire.Add(questionaires);
                await context.SaveChangesAsync();
            }

            //for (int j = 0; j < 4; j++)
            //{
            //    Question questions = new Question
            //    {
            //        Prompt = "Prompt?",
            //        PromptType = 1
            //    };

            //    context.Questions.Add(questions);
            //    await context.SaveChangesAsync();
            //}

        }
    }
}
