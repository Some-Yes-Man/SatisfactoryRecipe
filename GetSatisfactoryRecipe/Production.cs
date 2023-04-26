using NLog;

namespace GetSatisfactoryRecipe {
    public class Production {

        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private const double PRODUCTION_AMOUNT = 1000;

        public enum RESOURCE_IMPORTANCE {
            CRITICAL = 20,
            IMPORTANT = 40,
            NORMAL = 60,
            MEH = 80,
            DONT_CARE = 100,
        }

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

        public static List<Production> CalculateNonShittyProductionsForMaterial(Material material, IEnumerable<Material> ignoredResources, Material materialPower, IEnumerable<Machine> knownMachines) {
            List<ProductionTree> productionOptions = ProductionTree.GetAllProductionOptionsInCool(material, knownMachines);
            List<Production> collectedOptions = new();

            foreach (ProductionTree option in productionOptions) {
                Dictionary<Material, double> optionRequirements = option.CalculateBasicRessourcesNeeded(PRODUCTION_AMOUNT);
                optionRequirements.Add(materialPower, option.CalculatePowerUsage(PRODUCTION_AMOUNT));

                foreach (var mat in optionRequirements.Keys) {
                    if (ignoredResources.Contains(mat)) {
                        optionRequirements.Remove(mat);
                    }
                }

                Production production = new(option, optionRequirements);

                // already collected the same, or even a better option
                if (collectedOptions.Any(x => BomOneIsBetterThanOrSameAsBomTwo(x.Materials, optionRequirements))) {
                    // better option available
                    if (collectedOptions.Any(x => BomOneIsBetterThanBomTwo(x.Materials, optionRequirements))) {
                        Log.Debug("There is a clearly better option available. Dropping current option.");
                        Log.Debug($"'{collectedOptions.First(x => BomOneIsBetterThanBomTwo(x.Materials, optionRequirements))}' is better than '{production}'.");
                    }
                    // same option present
                    else {
                        Log.Debug("Same option already available; adding new option anyway.");
                        collectedOptions.Add(production);
                    }
                }
                // no better or equivalent options found
                else {
                    // remove options that are clearly worse
                    List<Production> worseOptions = collectedOptions.Where(x => !BomOneIsBetterThanOrSameAsBomTwo(x.Materials, optionRequirements) && BomOneIsWorseThanBomTwo(x.Materials, optionRequirements)).ToList();
                    foreach (var worse in worseOptions) {
                        Log.Debug($"Removing bad option '{worse}'.");
                        collectedOptions.Remove(worse);
                    }
                    // add new option
                    Log.Debug($"Adding new option '{production}'.");
                    collectedOptions.Add(production);
                }
            }
            return collectedOptions;
        }

        public static List<Production> CalculateActuallyGoodProductions(List<Production> nonShittyOptions, Dictionary<Material, RESOURCE_IMPORTANCE> importance) {
            List<Material> allUsedMaterials = nonShittyOptions.SelectMany(x => x.Materials.Keys).Distinct().ToList();
            Dictionary<Material, List<Production>> topPerMaterial = new();
            foreach (var material in allUsedMaterials) {
                // get all option using this material
                List<Production> optionsWithMaterial = nonShittyOptions.Where(x => x.Materials.ContainsKey(material)).ToList();
                // sort them by amount used
                optionsWithMaterial.Sort((x, y) => x.Materials[material].CompareTo(y.Materials[material]));
                // take the best of many, or many of a few and add all that don't use this material at all
                double partPerImportance = (int)importance.GetValueOrDefault(material, RESOURCE_IMPORTANCE.NORMAL) / 100d;
                double partPerInvertedAmount = 1 - ((double)optionsWithMaterial.Count / nonShittyOptions.Count);
                topPerMaterial.Add(material, optionsWithMaterial.Take((int)(Math.Max(partPerImportance, partPerInvertedAmount) * optionsWithMaterial.Count)).Concat(nonShittyOptions.Where(x => !x.Materials.ContainsKey(material))).ToList());
            }

            // debug
            Console.Write("Option");
            foreach (var mat in allUsedMaterials) {
                Console.Write("," + mat);
            }
            Console.WriteLine();
            foreach (var option in nonShittyOptions) {
                string foo = option.Tree.ToString();
                foreach (var mat in allUsedMaterials) {
                    if (option.Materials.ContainsKey(mat)) {
                        foo += "," + (int)option.Materials[mat];
                    }
                    else {
                        foo += ",0";
                    }
                }
                Console.WriteLine(foo);
            }
            // debug

            List<Production> actuallyGood = new List<Production>();
            bool firstRun = true;
            foreach (var topOfMat in topPerMaterial.Values) {
                if (firstRun) {
                    actuallyGood.AddRange(topOfMat);
                    firstRun = false;
                }
                else {
                    actuallyGood = actuallyGood.Intersect(topOfMat).ToList();
                }
            }
            return actuallyGood;
        }

        public override string? ToString() {
            return this.Tree + " [" + string.Join(", ", this.Materials.Select(x => x.Key + "(" + x.Value.ToString("0.##") + ")")) + "]";
        }
    }
}
