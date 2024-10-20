using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaTapWeb.Models
{
    [Table("tb_question")]
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }
        public string QuestionName { get; set; }

        [ForeignKey("Quiz")]
        public int QuizID { get; set; }

        
        public Quiz Quiz { get; set; }

        public ICollection<Option> Options { get; set; } = new List<Option>();
    }
}
