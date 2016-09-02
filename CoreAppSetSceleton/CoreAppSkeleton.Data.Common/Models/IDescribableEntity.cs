using System.ComponentModel.DataAnnotations;

namespace CoreAppSkeleton.Data.Common.Models
{

    public interface IDescribableEntity
    {
        [StringLength(200, MinimumLength = 4)]
        string Title { get; set; }

        [StringLength(5000, MinimumLength = 4)]
        string Description { get; set; }

        [StringLength(400, MinimumLength = 4)]
        string Summary { get; set; }

        [StringLength(200, MinimumLength = 4)]
        string Author { get; set; }
    }
}
