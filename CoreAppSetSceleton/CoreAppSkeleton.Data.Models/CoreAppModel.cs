using System.ComponentModel.DataAnnotations;

namespace CoreAppSkeleton.Data.Models
{
    public class CoreAppModel
    {
        [Required]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
