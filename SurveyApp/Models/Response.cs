using System.Diagnostics.CodeAnalysis;

namespace SurveyApp.Models
{
    public class Response
    {


        public int ResponseID { get; set; } // identifies a individual answer to a question
        public int SurveyId { get; set; }

        public int QuestionID { get; set; }

        public double? NumericResponse { get; set; }

        public string? TextResponse { get; set; }
    }
}
