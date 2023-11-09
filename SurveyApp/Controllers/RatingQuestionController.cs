using Microsoft.AspNetCore.Mvc;
using SurveyApp.Models;

namespace SurveyApp.Controllers
{
    [Route("api/ratingquestion")]
    [ApiController]
    public class RatingQuestionController : ControllerBase
    {
        private List<RatingQuestion> ratingQuestions = new List<RatingQuestion>
    {
        new RatingQuestion { Id = 1, QuestionText = "How would you rate this component?", Range = 5 },
        new RatingQuestion { Id = 2, QuestionText = "Another rating question", Range = 10 },
    };

        [HttpGet]
        public IActionResult GetRatingQuestions()
        {
            return Ok(ratingQuestions);
        }

        // Add other methods for creating, updating, and deleting rating questions as needed.
    }
}
