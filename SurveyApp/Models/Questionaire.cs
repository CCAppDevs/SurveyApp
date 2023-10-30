namespace SurveyApp.Models
{
    public class Questionaire
    {
        public int QuestionaireID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Title { get; set; }

        // navigation property
        public virtual ICollection<Question> Questions { get; set; }

    }
}
