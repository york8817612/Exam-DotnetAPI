using System.ComponentModel.DataAnnotations;

namespace ExamApi.Models
{
    public class ExamItem
    {
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        public bool Enable { get; set; }

        public virtual ICollection<QuestionItem>? QuestionItems { set; get; }
    }
}