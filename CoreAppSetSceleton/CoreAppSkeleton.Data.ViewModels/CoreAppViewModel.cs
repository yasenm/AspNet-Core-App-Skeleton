using CoreAppSkeleton.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace CoreAppSkeleton.Data.ViewModels
{
    public class CoreAppViewModel
    {
        public static Expression<Func<CoreAppModel, CoreAppViewModel>> FromCoreAppModel
        {
            get
            {
                return a => new CoreAppViewModel
                {
                    Title = a.Title,
                    Description = a.Description
                };
            }
        }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
