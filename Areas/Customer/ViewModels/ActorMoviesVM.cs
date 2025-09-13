namespace MAXCINA.Areas.Customer.ViewModels
{
    public class ActorMoviesVM
    {
        public Actors actors { get; set; } = null!;
        public List<Movies> movies { get; set; } = null!;
        public List<ActorMovies> actorMovies { get; set; } = null!;
    }
}
