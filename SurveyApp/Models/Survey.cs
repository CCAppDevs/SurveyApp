namespace SurveyApp.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }

        public string Instructor { get; set; }
        public int QuestionaireId { get; set; }
        public DateTime AdministeredDate { get; set; }
        public string Location { get; set; }

        public ICollection<Response> Responses { get; set; }
    }
}
