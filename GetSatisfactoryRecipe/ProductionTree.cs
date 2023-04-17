namespace GetSatisfactoryRecipe {
    public class ProductionTree {
        public Material ProducedMaterial { get; private set; }
        public Recipe ProductionRecipe { get; private set; }
        public Machine ProductionMachine { get; private set; }
        public Dictionary<Material, ProductionTree> ProductionInputs { get; private set; } = new();

        private readonly Dictionary<Material, Recipe> lockedRecipes;

        private ProductionTree(Material material, Dictionary<Material, Recipe> lockedRecipes, IEnumerable<Machine> knownMachines) {
            this.ProducedMaterial = material;
            this.ProductionRecipe = lockedRecipes[material];
            this.ProductionMachine = knownMachines.First(x => x.Recipes.Contains(this.ProductionRecipe));
            this.lockedRecipes = lockedRecipes;

            foreach (var input in this.ProductionRecipe.Inputs) {
                if (lockedRecipes.ContainsKey(input.Key)) {
                    this.ProductionInputs.Add(input.Key, new ProductionTree(input.Key, lockedRecipes, knownMachines));
                }
            }
        }

        public List<Recipe> CalculateUsedRecipes() {
            return new List<Recipe> { this.ProductionRecipe }.Concat(this.ProductionInputs.Values.SelectMany(x => x.CalculateUsedRecipes())).Distinct().ToList();
        }

        private double CalculatePowerUsageBasedOnMachines(double machinesNeeded) {
            // one machine under-clocked when fractions are needed
            return this.ProductionMachine.PowerUsage * Math.Floor(machinesNeeded) + this.ProductionMachine.PowerUsage * Math.Pow(machinesNeeded - Math.Floor(machinesNeeded), 1.321928d);
            // all machines under-clocked when fractions are needed
            //return Math.Pow(machinesNeeded / Math.Ceiling(machinesNeeded), 1.321928d) * Math.Ceiling(machinesNeeded) * this.ProductionMachine.PowerUsage;
        }

        public double CalculatePowerUsage(double amount) {
            int recipeOutputPerRun = this.ProductionRecipe.Outputs[this.ProducedMaterial];
            double recipeRunsPerMinute = 60d / this.ProductionRecipe.CraftingTime;
            double recipeOutputPerMinute = recipeRunsPerMinute * recipeOutputPerRun;
            double machinesNeeded = amount / recipeOutputPerMinute;

            return this.CalculatePowerUsageBasedOnMachines(machinesNeeded) + this.ProductionInputs.Sum(x => x.Value.CalculatePowerUsage(this.ProductionRecipe.Inputs[x.Key] * recipeRunsPerMinute * machinesNeeded));
        }

        public Dictionary<Machine, int> CalculateMachinesNeeded(double amount) {
            int recipeOutputPerRun = this.ProductionRecipe.Outputs[this.ProducedMaterial];
            double recipeRunsPerMinute = 60d / this.ProductionRecipe.CraftingTime;
            double recipeOutputPerMinute = recipeRunsPerMinute * recipeOutputPerRun;
            double machinesNeeded = amount / recipeOutputPerMinute;
            Dictionary<Machine, int> machines = new() { { this.ProductionMachine, (int)Math.Ceiling(machinesNeeded) } };

            foreach (var needs in this.ProductionInputs.Select(x => x.Value.CalculateMachinesNeeded(this.ProductionRecipe.Inputs[x.Key] * recipeRunsPerMinute * machinesNeeded))) {
                foreach (var n in needs) {
                    if (machines.ContainsKey(n.Key)) {
                        machines[n.Key] += n.Value;
                    }
                    else {
                        machines.Add(n.Key, n.Value);
                    }
                }
            }
            return machines;
        }

        public Dictionary<Material, double> CalculateBasicRessourcesNeeded(double amount) {
            Dictionary<Material, double> ressources = new();
            if (!this.ProductionInputs.Any()) {
                ressources.Add(this.ProducedMaterial, amount);
            }
            else {
                int recipeOutputPerRun = this.ProductionRecipe.Outputs[this.ProducedMaterial];
                double recipeRunsPerMinute = 60d / this.ProductionRecipe.CraftingTime;
                double recipeOutputPerMinute = recipeRunsPerMinute * recipeOutputPerRun;
                double machinesNeeded = amount / recipeOutputPerMinute;

                foreach (var needs in this.ProductionInputs.Select(x => x.Value.CalculateBasicRessourcesNeeded(this.ProductionRecipe.Inputs[x.Key] * recipeRunsPerMinute * machinesNeeded))) {
                    foreach (var n in needs) {
                        if (ressources.ContainsKey(n.Key)) {
                            ressources[n.Key] += n.Value;
                        }
                        else {
                            ressources.Add(n.Key, n.Value);
                        }
                    }
                }
            }
            return ressources;
        }

        private List<Material> CalculateAllMissingInputs() {
            IEnumerable<Material> missingMaterials = this.ProductionRecipe.Inputs.Where(x => !this.ProductionInputs.ContainsKey(x.Key)).Select(x => x.Key);
            return missingMaterials.Concat(this.ProductionInputs.SelectMany(x => x.Value.CalculateAllMissingInputs())).Distinct().ToList();
        }

        private ProductionTree Clone(Material lockedMaterial, Recipe lockedRecipe, IEnumerable<Machine> knownMachines) {
            Dictionary<Material, Recipe> clonedLockedRecipes = this.lockedRecipes.ToDictionary(x => x.Key, x => x.Value);
            clonedLockedRecipes.Add(lockedMaterial, lockedRecipe);
            return new(this.ProducedMaterial, clonedLockedRecipes, knownMachines);
        }

        private ProductionTree Clone(Dictionary<Material, Recipe> lockedMaterialRecipes, IEnumerable<Machine> knownMachines) {
            Dictionary<Material, Recipe> clonedLockedRecipes = this.lockedRecipes.ToDictionary(x => x.Key, x => x.Value);
            foreach (var matLock in lockedMaterialRecipes) {
                clonedLockedRecipes.Add(matLock.Key, matLock.Value);
            }
            return new(this.ProducedMaterial, clonedLockedRecipes, knownMachines);
        }

        public override string? ToString() {
            return $"Material '{this.ProducedMaterial}' ({this.ProductionRecipe}) : {string.Join(" + ", this.CalculateUsedRecipes())}";
        }

        private static IEnumerable<Recipe> GetAllProducingRecipes(Material material, IEnumerable<Machine> knownMachines) {
            return knownMachines.SelectMany(x => x.Recipes).Where(x => x.Outputs.ContainsKey(material));
        }

        private static List<Dictionary<Material, Recipe>> PermutatePossibleRecipes(IEnumerable<Material> missingMaterials, IEnumerable<Machine> knownMachines) {
            return PermutatePossibleRecipes(new List<Dictionary<Material, Recipe>>(), missingMaterials.Select(x => new Tuple<Material, IEnumerable<Recipe>>(x, GetAllProducingRecipes(x, knownMachines))));
        }

        private static List<Dictionary<Material, Recipe>> PermutatePossibleRecipes(List<Dictionary<Material, Recipe>> collectedRecipes, IEnumerable<Tuple<Material, IEnumerable<Recipe>>> missingMaterials) {
            // already done
            if (!missingMaterials.Any()) {
                return collectedRecipes;
            }

            List<Dictionary<Material, Recipe>> brandNewList = new();
            foreach (var possibleRecipe in missingMaterials.First().Item2) {
                // first step
                if (collectedRecipes.Count == 0) {
                    brandNewList.Add(new Dictionary<Material, Recipe>() { { missingMaterials.First().Item1, possibleRecipe } });
                }
                // later steps
                else {
                    foreach (var collected in collectedRecipes) {
                        Dictionary<Material, Recipe> subDict = collected.ToDictionary(x => x.Key, x => x.Value);
                        subDict.Add(missingMaterials.First().Item1, possibleRecipe);
                        brandNewList.Add(subDict);
                    }
                }
            }

            return PermutatePossibleRecipes(brandNewList, missingMaterials.Skip(1).ToList());
        }

        public static List<ProductionTree> GetAllProductionOptions(Material material, IEnumerable<Machine> knownMachines) {
            List<ProductionTree> productionOptions = new();
            List<ProductionTree> incompleteOptions = GetAllProducingRecipes(material, knownMachines).Select(x => new ProductionTree(material, new Dictionary<Material, Recipe>() { { material, x } }, knownMachines)).ToList();

            while (incompleteOptions.Any()) {
                List<ProductionTree> toAdd = new();

                foreach (var option in incompleteOptions) {
                    if (option.CalculateAllMissingInputs().Any()) {
                        // remove incomplete option
                        // add all material permutations as new options
                        List<Dictionary<Material, Recipe>> missingMatsRecipesPermutated = PermutatePossibleRecipes(option.CalculateAllMissingInputs(), knownMachines);
                        foreach (var permutation in missingMatsRecipesPermutated) {
                            toAdd.Add(option.Clone(permutation, knownMachines));
                        }
                    }
                    else {
                        productionOptions.Add(option);
                    }
                }

                incompleteOptions.Clear();
                incompleteOptions.AddRange(toAdd);
            }

            return productionOptions;
        }
    }
}
