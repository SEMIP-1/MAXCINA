namespace MAXCINA.Models
{
    public class Movies
    {
        public int MoviesId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public string TrailerUrl { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MovieStatus { get; set; }
        public int CinemaId { get; set; }
        public int CategoryId { get; set; }
        // Foreign Keys
        public Cinemas Cinema { get; set; } 
        public Categories Category { get; set; }
        // Navigation Properties
        public List<Actors> Actors { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
