namespace GetSatisfactoryRecipe {
    public class Material {
        private readonly Guid _id = Guid.NewGuid();
        public string Name { get; private set; }

        public Material(string name) {
            this.Name = name;
        }

        public override bool Equals(object? obj) {
            return (obj is Material material) && this._id.Equals(material._id);
        }

        public override int GetHashCode() {
            return HashCode.Combine(this._id);
        }

        public override string ToString() {
            return this.Name;
        }
    }
}
