namespace GetSatisfactoryRecipe {
    public class Material {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }

        public Material(string name) {
            this.Name = name;
        }

        public override bool Equals(object? obj) {
            return (obj is Material material) && this.Id.Equals(material.Id);
        }

        public override int GetHashCode() {
            return HashCode.Combine(this.Id);
        }

        public override string ToString() {
            return this.Name;
        }
    }
}
