namespace DisaBioModel.Model
{
    public class Genre : BaseEntity
    {
        // Attributes
        private string name;

        // Properties
        public string Name { get => name; set => name = value; }

        // Constructor
        public Genre() : base() { }
        public  Genre(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}