using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetSatisfactoryRecipe.Tests {
    [TestClass()]
    public class UtilsTests {
        public static IEnumerable<object[]> GenerateTwoIdTestData {
            get {
                return new[] {
                    new object[] { Guid.Parse("00000000-0000-0000-0000-000000000000"), Guid.Parse("00000000-0000-0000-0000-000000000000"), Guid.Parse("00000000-0000-0000-0000-000000000000") },
                    new object[] { Guid.Parse("11111111-1111-1111-1111-111111111111"), Guid.Parse("11111111-1111-1111-1111-111111111111"), Guid.Parse("00000000-0000-0000-0000-000000000000") },
                    new object[] { Guid.Parse("00000000-0000-0000-0000-000000000000"), Guid.Parse("11111111-1111-1111-1111-111111111111"), Guid.Parse("11111111-1111-1111-1111-111111111111") },
                    new object[] { Guid.Parse("11223344-0000-0000-0000-556677889900"), Guid.Parse("00000000-1234-5678-9999-000000000000"), Guid.Parse("11223344-1234-5678-9999-556677889900") },
                };
            }
        }

        [TestMethod]
        [DynamicData(nameof(GenerateTwoIdTestData))]
        public void TestMergingTwoIdsAsItems(Guid a, Guid b, Guid expected) {
            Assert.AreEqual(Utils.XorGuids(a, b), expected);
        }

        [TestMethod]
        [DynamicData(nameof(GenerateTwoIdTestData))]
        public void TestMergingTwoIdsAsList(Guid a, Guid b, Guid expected) {
            Assert.AreEqual(Utils.XorGuids(new Guid[] { a, b }), expected);
        }
    }
}
