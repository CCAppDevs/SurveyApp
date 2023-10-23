namespace SurveyApp.Models
{
    public class Form
    {
        public int FormID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Title { get; set; }

        // navigation property
        public virtual ICollection<Question> Questions { get; set; }

    }
}
