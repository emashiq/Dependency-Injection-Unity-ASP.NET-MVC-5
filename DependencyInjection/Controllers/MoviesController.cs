using System.Threading.Tasks;
using System.Web.Mvc;
using DependencyInjection.Models;
using DependencyInjection.Repository;
namespace DependencyInjection.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        // GET: Movies
        public async Task<ActionResult> Index()
        {
            return View(_movieRepository.GetMovieList());
        }

        // GET: Movies/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Movie movie = _movieRepository.GetMovie(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepository.AddMovie(movie);
                _movieRepository.MovieCommit();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Movie movie = _movieRepository.GetMovie(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepository.UpdateMovie(movie);
                _movieRepository.MovieCommit();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Movie movie = _movieRepository.GetMovie(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Movie movie = _movieRepository.GetMovie(id);
            _movieRepository.DeleteMovie(movie);
            _movieRepository.MovieCommit();
            return RedirectToAction("Index");
        }

        
    }
}
