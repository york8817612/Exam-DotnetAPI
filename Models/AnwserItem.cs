namespace ExamApi.Models
{
    public class AnwserItem 
    {
        public Guid Id { get; set; }
        public Guid QuestionItemId { get; set; }
        public string? Text { get; set; }
        public byte Correct { get; set; }
    }
}