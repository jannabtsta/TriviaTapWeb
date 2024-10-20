using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaTapWeb.Models
{
    [Table("tb_option")]
    public class Option
    {
        public int OptionID { get; set; }
        public string Options { get; set; }

        [ForeignKey("Question")]
        public int QuestionID { get; set; }   
        public Question Question { get; set; }
    
        public bool IsCorrect { get; set; }
    }
}
