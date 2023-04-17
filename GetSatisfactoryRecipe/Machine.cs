namespace GetSatisfactoryRecipe {
    public class Machine {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public int PowerUsage { get; private set; }
        public List<Recipe> Recipes { get; private set; }

        public Machine(string name, int power) {
            this.Name = name;
            this.PowerUsage = power;
            this.Recipes = new List<Recipe>();
        }

        public Machine AddRecipe(Recipe recipe) {
            this.Recipes.Add(recipe);
            return this;
        }

        public override bool Equals(object? obj) {
            return (obj is Machine machine) && this.Id.Equals(machine.Id);
        }

        public override int GetHashCode() {
            return HashCode.Combine(this.Id);
        }

        public override string ToString() {
            return this.Name;
        }
    }
}
