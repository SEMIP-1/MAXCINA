using Microsoft.AspNetCore.Mvc.Rendering;

namespace MAXCINA.Areas.Admin.ViewModels
{
    public class MoviesCreateVM
    {
        public List<Cinemas> Cinema { get; set; } = null!;
        public List<Categories> Category { get; set; } = null!;
    }
}
