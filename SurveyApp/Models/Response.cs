namespace SurveyApp.Models
{
    public class Response
    {


        public int ResponseID { get; set; }


        public int QuestionID { get; set; }

        public int ResponseType1 { get; set; }

        public string ResponseType2 { get; set; }


        //Navigation property?
        public int FormId { get; set; }
       






    }
}
