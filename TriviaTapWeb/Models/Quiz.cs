using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaTapWeb.Models
{
    [Table("tb_quiz")]
    public class Quiz
    {
        [Key]
        public int QuizID { get; set; }
        public string Title { get; set; }

    
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
