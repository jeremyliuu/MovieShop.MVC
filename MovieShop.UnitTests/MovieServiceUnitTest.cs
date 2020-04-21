using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieShop.Data;
using MovieShop.Entities;
using MovieShop.Services;
using System.Linq;
using Moq;

namespace MovieShop.UnitTests
{
    [TestClass]
    public class MovieServiceUnitTest
    {
        private MovieService _sut;
        // System Under Test
        private List<Movie> _fakeMovies;
        private Mock<IMovieRepository> _mockMovieRepository;

        public MovieServiceUnitTest()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            _sut = new MovieService(_mockMovieRepository.Object);
        }

        [TestInitialize]
        //triggered before every test case
        public void TestInitialize()
        {
            _fakeMovies = new List<Movie> {
                new Movie
                {
                    Id = 1,
                    Title = "TestMovie1",
                    Budget = 25000,
                },
                new Movie
                {
                    Id = 2,
                    Title = "TestMovie2",
                    Budget = 25000,
                },
                new Movie
                {
                    Id = 3,
                    Title = "TestMovie3",
                    Budget = 25000,
                },
                new Movie
                {
                    Id = 4,
                    Title = "TestMovie4",
                    Budget = 25000,
                },
                new Movie
                {
                    Id = 5,
                    Title = "TestMovie5",
                    Budget = 25000,
                }
            };

            //using Moq to set up mock methods for IMovieRepository
            _mockMovieRepository.Setup(m => m.GetTopGrossingMovies()).Returns(_fakeMovies);
            _mockMovieRepository.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns((int id) => _fakeMovies.FirstOrDefault(x => x.Id == id));
        }

        [TestMethod]
        public void Test_For_TopGrossingMovies_From_FakeData()
        {
            // Act
            var topMovies = _sut.GetTopGrossingMovies();
            // Assert
            // you can do multiple asserts in one unit test method
            // checking topMovies is not null
            Assert.IsNotNull(topMovies);
            // check totalnumber of movies equal to 5
            Assert.AreEqual(5, topMovies.Count());
            // Check the returned type
            CollectionAssert.AllItemsAreInstancesOfType(topMovies.ToList(), typeof(Movie));
        }

        [TestMethod]
        public void Test_For_GetMovieDetails_From_FakeData()
        {
            var movieDetail = _sut.GetMovieDetails(1);
            Assert.IsNotNull(movieDetail);
            Assert.AreEqual("TestMovie1", movieDetail.Title);
            Assert.AreEqual(1, movieDetail.Id);
            Assert.IsInstanceOfType(movieDetail, typeof(Movie));
        }
    }

    //public class FakeMovieRepository : IMovieRepository
    //{
    //    private List<Movie> _fakeMovies;
    //    public void Add(Movie entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete(Movie entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete(Expression<Func<Movie, bool>> where)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Movie Get(Expression<Func<Movie, bool>> where)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<Movie> GetAll()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Movie GetById(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<Movie> GetMany(Expression<Func<Movie, bool>> where)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<Movie> GetMoviesByGenre(int genreId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<Movie> GetTopGrossingMovies()
    //    {
    //        // Instead of using Database we need to fake movies from memory
            
    //        _fakeMovies = new List<Movie> {
    //            new Movie
    //            {
    //                Id = 1,
    //                Title = "TestMovie1",
    //                Budget = 25000,
    //            },
    //            new Movie
    //            {
    //                Id = 2,
    //                Title = "TestMovie2",
    //                Budget = 25000,
    //            },
    //            new Movie
    //            {
    //                Id = 3,
    //                Title = "TestMovie3",
    //                Budget = 25000,
    //            },
    //            new Movie
    //            {
    //                Id = 4,
    //                Title = "TestMovie4",
    //                Budget = 25000,
    //            },
    //            new Movie
    //            {
    //                Id = 5,
    //                Title = "TestMovie5",
    //                Budget = 25000,
    //            }
    //        };
    //        return _fakeMovies;
    //}

    //    public void Update(Movie entity)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

}
