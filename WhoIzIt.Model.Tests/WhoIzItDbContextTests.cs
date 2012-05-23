using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WhoIzIt.Model.Tests
{
    [TestClass]
    public class WhozitEntitiesTests
    {
        [TestMethod]
        public void WhozitEntitiesTest()
        {
            var dbContext = new WhozitEntities();
            var count = dbContext.Badges.Count();


        }
    }
}
