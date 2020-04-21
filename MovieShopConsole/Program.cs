using MovieShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MovieShopDbContext())
            {
                // var genres = db.Genres.ToList();
                var movies = db.Movies.Where(m => m.Title.StartsWith("a")).ToList();
            }
        }
    }
}
