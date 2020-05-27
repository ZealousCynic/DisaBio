namespace DisaBioModel.Model
{
    class Star : BaseEntity
    {
        // Attributes
        private string firstname;
        private string lastname;
        private string imageURL;

        // Properties
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string ImageURL { get => imageURL; set => imageURL = value; }
        
        // Constructor
        public Star():base()        {        }

        public Star(int id,string firstname, string lastname, string imageURL):base(id)
        {
            Firstname = firstname;
            Lastname = lastname;
            ImageURL = imageURL;
        }
    }
}