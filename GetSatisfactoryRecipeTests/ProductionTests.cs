using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetSatisfactoryRecipe.Tests {
    [TestClass()]
    public class ProductionTests {
        private static readonly Material materialPower = new("_MW");
        private static readonly Material materialIronOre = new("_Iron Ore");
        private static readonly Material materialWater = new("_Water");

        public static IEnumerable<object[]> GenerateBetterSameWorseData {
            get {
                return new[] {
                    new object[] {
                        new Dictionary<Material, double>() { { materialPower, 10 }, { materialIronOre, 10 } },
                        new Dictionary<Material, double>() { { materialPower, 10 }, { materialIronOre, 10 } },
                        false, true, false, false
                    },
                    new object[] {
                        new Dictionary<Material, double>() { { materialPower, 10 }, { materialIronOre, 5 } },
                        new Dictionary<Material, double>() { { materialPower, 10 }, { materialIronOre, 10 } },
                        true, false, false, false
                    },
                    new object[] {
                        new Dictionary<Material, double>() { { materialPower, 10 } },
                        new Dictionary<Material, double>() { { materialPower, 10 }, { materialIronOre, 10 } },
                        true, false, false, false
                    },
                    new object[] {
                        new Dictionary<Material, double>() { { materialPower, 10 }, { materialIronOre, 15 } },
                        new Dictionary<Material, double>() { { materialPower, 10 }, { materialIronOre, 10 } },
                        false, false, true, false
                    },
                    new object[] {
                        new Dictionary<Material, double>() { { materialPower, 10 }, { materialIronOre, 10 }, { materialWater, 5 } },
                        new Dictionary<Material, double>() { { materialPower, 10 }, { materialIronOre, 10 } },
                        false, false, true, false
                    },
                    new object[] {
                        new Dictionary<Material, double>() { { materialPower, 10 }, { materialIronOre, 5 }, { materialWater, 1 } },
                        new Dictionary<Material, double>() { { materialPower, 10 }, { materialIronOre, 10 } },
                        false, false, false, true
                    },
                    new object[] {
                        new Dictionary<Material, double>() { { materialPower, 10 }, { materialWater, 1 } },
                        new Dictionary<Material, double>() { { materialPower, 10 }, { materialIronOre, 10 } },
                        false, false, false, true
                    },
                };
            }
        }

        [TestMethod]
        [DynamicData(nameof(GenerateBetterSameWorseData))]
        public void BomOneIsBetterThanOrSameAsBomTwoTest(Dictionary<Material, double> bomOne, Dictionary<Material, double> bomTwo, bool better, bool same, bool worse, bool different) {
            Assert.AreEqual(Production.BomOneIsBetterThanOrSameAsBomTwo(bomOne, bomTwo), better || same);
        }

        [TestMethod]
        [DynamicData(nameof(GenerateBetterSameWorseData))]
        public void BomOneIsBetterThanBomTwoTest(Dictionary<Material, double> bomOne, Dictionary<Material, double> bomTwo, bool better, bool same, bool worse, bool different) {
            Assert.AreEqual(Production.BomOneIsBetterThanBomTwo(bomOne, bomTwo), better);
        }

        [TestMethod]
        [DynamicData(nameof(GenerateBetterSameWorseData))]
        public void BomOneIsWorseThanBomTwoTest(Dictionary<Material, double> bomOne, Dictionary<Material, double> bomTwo, bool better, bool same, bool worse, bool different) {
            Assert.AreEqual(Production.BomOneIsWorseThanBomTwo(bomOne, bomTwo), worse);
        }
    }
}
