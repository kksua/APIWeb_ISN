using System.Collections.Generic;
using APIWeb_ISN.Models;


namespace Web_HP.ViewsModels
{
   
        public class MovieViewModel
        {
            public List<Movie> MoviesList { get; set; }
        }


        public class Movie
        {
            public int IdFilm { get; set; }
            public string NomFilm { get; set; }
            public string Duree { get; set; }
            public string Image { get; set; }
            public string Description { get; set; }
        }
    


}

