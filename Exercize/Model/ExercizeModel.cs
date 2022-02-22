using System.ComponentModel.DataAnnotations;

namespace Library.Model
{
    public class ExercizeModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsFinished { get; set; } = false;
    }
}