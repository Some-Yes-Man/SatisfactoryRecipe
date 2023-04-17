namespace GetSatisfactoryRecipe {
    public class Recipe {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public int CraftingTime { get; private set; }
        public Dictionary<Material, int> Inputs { get; private set; }
        public Dictionary<Material, int> Outputs { get; private set; }

        public Recipe(string name, int craftingTime) {
            this.Name = name;
            this.CraftingTime = craftingTime;
            this.Inputs = new Dictionary<Material, int>();
            this.Outputs = new Dictionary<Material, int>();
        }

        public Recipe AddInput(Material material, int amount) {
            if (this.Inputs.ContainsKey(material)) {
                throw new ArgumentException($"Duplicate input '{material}' specified.");
            }
            this.Inputs.Add(material, amount);
            return this;
        }

        public Recipe AddOutput(Material material, int amount) {
            if (this.Outputs.ContainsKey(material)) {
                throw new ArgumentException($"Duplicate output '{material}' specified.");
            }
            this.Outputs.Add(material, amount);
            return this;
        }

        public override bool Equals(object? obj) {
            return (obj is Recipe recipe) && this.Id.Equals(recipe.Id);
        }

        public override int GetHashCode() {
            return HashCode.Combine(this.Id);
        }

        public override string ToString() {
            return this.Name;
        }
    }
}
