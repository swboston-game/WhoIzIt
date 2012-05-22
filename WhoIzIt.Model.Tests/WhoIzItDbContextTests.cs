using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WhoIzIt.Model.Tests
{
    [TestClass]
    public class WhoIzItDbContextTests
    {
        [TestMethod]
        public void WhoIzItDbContextTest()
        {
            var dbContext = new WhoIzItDbContext();
            var count = dbContext.Badges.Count();


        }
    }
}
