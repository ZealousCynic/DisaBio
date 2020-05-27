using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Model
{
    class Cinema:BaseEntity
    {
        // Attributes
        private List<Movie> movies;
        private List<Employee> employees;
        private List<CinemaHall> halls;
        private float basePrice;
        private string name;
        private Location location;


        // Properties
        public float BasePrice { get => basePrice; set => basePrice = value; }
        public string Name { get => name; set => name = value; }
        public List<Movie> Movies { get => movies; private set => movies = value; }
        public List<Employee> Employees { get => employees; set => employees = value; }
        public List<CinemaHall> Halls { get => halls; private set => halls = value; }
        public Location Location { get => location; set => location = value; }

        // Constructor
        public Cinema():base(){        }
        public Cinema(int id,float basePrice, string name, List<Movie> movies, List<Employee> employees, List<CinemaHall> halls, Location location):base(id)
        {
            BasePrice = basePrice;
            Name = name;
            Movies = movies;
            Employees = employees;
            Halls = halls;
            Location = location;
        }

    }
}
