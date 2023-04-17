namespace GetSatisfactoryRecipe {
    public class Recipe {
        private readonly Guid _id = Guid.NewGuid();

        public string Name { get; private set; }
        public int CraftingTime { get; private set; }
        public List<Tuple<Material, int>> Inputs { get; private set; }
        public List<Tuple<Material, int>> Outputs { get; private set; }

        public Recipe(string name, int craftingTime) {
            this.Name = name;
            this.CraftingTime = craftingTime;
            this.Inputs = new List<Tuple<Material, int>>();
            this.Outputs = new List<Tuple<Material, int>>();
        }

        public Recipe AddInput(Material material, int amount) {
            if (this.Inputs.Any(x => x.Item1 == material)) {
                throw new ArgumentException($"Duplicate input '{material}' specified.");
            }
            this.Inputs.Add(new Tuple<Material, int>(material, amount));
            return this;
        }

        public Recipe AddOutput(Material material, int amount) {
            if (this.Outputs.Any(x => x.Item1 == material)) {
                throw new ArgumentException($"Duplicate output '{material}' specified.");
            }
            this.Outputs.Add(new Tuple<Material, int>(material, amount));
            return this;
        }

        public override bool Equals(object? obj) {
            return (obj is Recipe recipe) && this._id.Equals(recipe._id);
        }

        public override int GetHashCode() {
            return HashCode.Combine(this._id);
        }

        public override string ToString() {
            return this.Name;
        }
    }
}
