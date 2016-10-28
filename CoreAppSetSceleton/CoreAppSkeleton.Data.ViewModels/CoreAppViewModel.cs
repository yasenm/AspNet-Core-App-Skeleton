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
                    Description123 = a.Description
                };
            }
        }
        
        public string Title { get; set; }

        [Required]
        public string Description123 { get; set; }
    }
}
