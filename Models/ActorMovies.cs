namespace MAXCINA.Models
{
    public class ActorMovies
    {
        public int Id { get; set; }
        public int ActorsId { get; set; }
        public Actors Actors { get; set; }
        public int MoviesId { get; set; }
        public Movies Movies { get; set; }
    }
}
