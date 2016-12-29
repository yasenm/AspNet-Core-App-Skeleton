using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CoreAppSkeleton.Data.Services.Tests
{
    public class Class1
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, 4);
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(4, 5);
        }
    }
}
