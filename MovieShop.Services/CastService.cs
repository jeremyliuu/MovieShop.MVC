using MovieShop.Data;
using MovieShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService()
        {
            _castRepository = new CastRepository(new MovieShopDbContext());
        }

        public void Add(Cast cast)
        {
            _castRepository.Add(cast);
        }

        public IEnumerable<Cast> GetAllCasts()
        {
            return _castRepository.GetAll();
        }

        public Cast GetCastDetails(int castId)
        {
            var cast = _castRepository.GetCastWithMovies(castId);
            return cast;
        }

        
    }

    public interface ICastService
    {
        Cast GetCastDetails(int castId);
        IEnumerable<Cast> GetAllCasts();
        void Add(Cast cast);
    }
}
