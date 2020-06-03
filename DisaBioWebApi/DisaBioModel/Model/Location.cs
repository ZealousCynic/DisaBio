using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Model
{
    public class Location : BaseEntity
    {
        private string province;
        private int postalCode;
        private string address;
        private int roadNumber;

        // Properties
        public string Province { get => province; set => province = value; }
        public int PostalCode { get => postalCode; set => postalCode = value; }
        public string Address { get => address; set => address = value; }
        public int RoadNumber { get => roadNumber; set => roadNumber = value; }
        
        // Attributes
        public Location() : base() { }

        public Location(int id,string province, int postalCode, string address, int roadNumber):base(id)
        {
            Province = province;
            PostalCode = postalCode;
            Address = address;
            RoadNumber = roadNumber;
        }
    }
}
