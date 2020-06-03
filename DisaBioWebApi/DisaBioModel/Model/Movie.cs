using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Model
{
    public class Movie : BaseEntity
    {
        // Attributes
        private string title;
        private List<string> imageUrl = new List<string>();
        private List<string> trailorUrl = new List<string>();
        private string description;
        private int playTime;
        private List<Genre> genre = new List<Genre>();
        private List<Star> director = new List<Star>();
        private List<Star> actors = new List<Star>();
        private DateTime releasDate;

        // Properties
        public string Title { get => title; set => title = value; }
        public List<string> ImageUrl { get => imageUrl; set => imageUrl = value; }
        public List<string> TrailorUrl { get => trailorUrl; set => trailorUrl = value; }
        public string Description { get => description; set => description = value; }
        public int PlayTime { get => playTime; set => playTime = value; }
        public List<Genre> Genre { get => genre; set => genre = value; }
        public List<Star> Director { get => director; set => director = value; }
        public List<Star> Actors { get => actors; set => actors = value; }
        public DateTime ReleasDate { get => releasDate; set => releasDate = value; }

        // Constructor
        public Movie():base() { }

        public Movie(int id, string title, List<string> imageUrl, List<string> trailorUrl, string description, int playTime, List<Genre> genre, List<Star> director, List<Star> actors, DateTime releasDate):base(id)
        {
            Title = title;
            ImageUrl = imageUrl;
            TrailorUrl = trailorUrl;
            Description = description;
            PlayTime = playTime;
            Genre = genre;
            Director = director;
            Actors = actors;
            ReleasDate = releasDate;
        }
    }
}
