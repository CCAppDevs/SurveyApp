namespace SurveyApp.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string Prompt { get; set; }
        public int PromptType { get; set; }
        
        // relationship
        public int FormId { get; set; }






        
    }

}
