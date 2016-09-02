using System;

namespace CoreAppSkeleton.Data.Common.Contracts.DataAnotations
{
    public class IsUnicodeAttribute : Attribute
    {
        private readonly bool isUnicode;

        public IsUnicodeAttribute(bool isUnicode)
        {
            this.isUnicode = isUnicode;
        }

        public bool IsUnicode
        {
            get
            {
                return this.isUnicode;
            }
        }
    }
}
