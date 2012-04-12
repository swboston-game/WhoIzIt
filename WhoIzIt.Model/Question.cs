namespace WhoIzIt.Model
{
    public class Question : BaseEntity
    {
        public string QuestionText { get; set; }
        public Answer Answer { get; set; }
        public QuestionStatus Status { get; set; }
    }
}
