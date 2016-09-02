using System;

namespace CoreAppSkeleton.Data.Common.Models
{
    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }

        bool PreserveCreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}