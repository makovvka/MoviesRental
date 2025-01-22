using System.Reflection;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbcontext context;
        private readonly IWebHostEnvironment environment;

        public MoviesController(ApplicationDbcontext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        public IActionResult Index(string searchString)
        {
            var movies = context.MoviesCollection.ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(n => n.Title.Contains(searchString)).ToList();
            }
            return View(movies);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MovieDTo movieDTo)
        {
            if (movieDTo.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "The image is required");
            }
            if (!ModelState.IsValid) {
                return View(movieDTo); 
            }

            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(movieDTo.ImageFile!.FileName);

            string imageFullPath = environment.WebRootPath + "/photos/"  + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                movieDTo.ImageFile.CopyTo(stream);
            }

            Movie movie = new Movie()
            {
                Title = movieDTo.Title,
                Description = movieDTo.Description,
                Author = movieDTo.Author,
                Genre = movieDTo.Genre,
                Price = movieDTo.Price,
                ImageFileName = newFileName,
                CreatedAt = DateTime.Now,
            };

            context.MoviesCollection.Add(movie);
            context.SaveChanges();


            return RedirectToAction("Index", "movies");
        }

        public IActionResult Edit(int id)
        {
            var movie = context.MoviesCollection.Find(id);
            if (movie == null)
            {
                return RedirectToAction("Index", "movies");
            }

            var movieDTo = new MovieDTo()
            {
                Title = movie.Title,
                Description = movie.Description,
                Author = movie.Author,
                Genre = movie.Genre,
                Price = movie.Price,
            };


            ViewData["id"] = movie.Id;
            ViewData["ImageFileName"] = movie.ImageFileName;
            ViewData["CreatedAt"] = movie.CreatedAt.ToString("MM/dd/yyyy");
            return View(movieDTo);
        }

        [HttpPost]
        public IActionResult Edit(int id, MovieDTo movieDTo)
        {
            var movie = context.MoviesCollection.Find(id);
            if(movie == null)
            {
                return RedirectToAction("Index", "movies");
            }

            if(!ModelState.IsValid)
            {
                ViewData["id"] = movie.Id;
                ViewData["ImageFileName"] = movie.ImageFileName;
                ViewData["CreatedAt"] = movie.CreatedAt.ToString("MM/dd/yyyy");

                return View(movieDTo);
            }

            string newFileName = movie.ImageFileName;
            if (movieDTo.ImageFile != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(movieDTo.ImageFile.FileName);

                string imageFullPath = environment.WebRootPath + "/photos/" + newFileName;
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    movieDTo.ImageFile.CopyTo(stream);
                }

                // delete the old image
                string oldImageFullPath = environment.WebRootPath + "/photos/" + movie.ImageFileName;
                System.IO.File.Delete(oldImageFullPath);
            }

            movie.Title = movieDTo.Title;
            movie.Description = movieDTo.Description;  
            movie.Author = movieDTo.Author; 
            movie.Genre = movieDTo.Genre;
            movie.Price = movieDTo.Price;
            movie.ImageFileName = newFileName;



            context.SaveChanges();
            return RedirectToAction("Index", "movies");
        }


        public IActionResult Delete(int id)
        {
            var movie = context.MoviesCollection.Find(id);
            if(movie == null)
            {
                return RedirectToAction("Index", "movies");
            }

            string imageFullPath = environment.WebRootPath + "/photos/" + movie.ImageFileName;
            System.IO.File.Delete(imageFullPath);

            context.MoviesCollection.Remove(movie);
            context.SaveChanges(true);

            return RedirectToAction("Index", "movies");
        }
    }
}
