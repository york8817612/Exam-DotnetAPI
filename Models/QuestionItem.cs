namespace ExamApi.Models
{
    public class QuestionItem {
        public Guid Id { get; set; }
        public Guid ExamItemId { get; set; }
        public QuestionTypes QuestionType { get; set; }
        public string? Text { get; set; }
        
        public virtual ICollection<AnwserItem>? AnwserItems { set; get; }
    }
}