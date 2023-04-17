using System.Security.Cryptography.X509Certificates;

namespace GetSatisfactoryRecipe {
    public class Production {
        public ProductionTree Tree { get; set; }
        public Dictionary<Material, double> Materials { get; set; }

        public Production(ProductionTree tree, Dictionary<Material, double> materials) {
            this.Tree = tree;
            this.Materials = new();
            foreach (var mat in materials) {
                this.Materials.Add(mat.Key, mat.Value);
            }
        }

        public static bool BomOneIsBetterThanOrSameAsBomTwo(Dictionary<Material, double> bomOne, Dictionary<Material, double> bomTwo) {
            return bomOne.All(x => bomTwo.ContainsKey(x.Key)) && bomOne.All(x => bomTwo[x.Key] >= x.Value);
        }

        public static bool BomOneIsBetterThanBomTwo(Dictionary<Material, double> bomOne, Dictionary<Material, double> bomTwo) {
            return bomOne.All(x => bomTwo.ContainsKey(x.Key)) && bomOne.All(x => x.Value <= bomTwo[x.Key]) && (bomOne.Any(x => x.Value < bomTwo[x.Key]) || bomTwo.Any(x => !bomOne.ContainsKey(x.Key)));
        }

        public static bool BomOneIsWorseThanBomTwo(Dictionary<Material, double> bomOne, Dictionary<Material, double> bomTwo) {
            return bomTwo.All(x => bomOne.ContainsKey(x.Key) && (bomOne[x.Key] >= x.Value)) && (bomTwo.Any(x => bomOne[x.Key] > x.Value) || bomOne.Any(x => !bomTwo.ContainsKey(x.Key)));
        }

        public override string? ToString() {
            return this.Tree + " [" + string.Join(", ", this.Materials.Select(x => x.Key + "(" + x.Value.ToString("0.##") + ")")) + "]";
        }
    }
}
