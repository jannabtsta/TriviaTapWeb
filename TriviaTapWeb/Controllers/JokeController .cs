using Microsoft.AspNetCore.Mvc;
using TriviaTapWeb.Services; 
using System.Threading.Tasks;
namespace TriviaTapWeb.Controllers
{
    public class JokeController : Controller
    {
        private readonly JokeService _jokeService;

        public JokeController()
        {
            _jokeService = new JokeService();
        }

        public async Task<IActionResult> Index()
        {
            var joke = await _jokeService.GetRandomJoke();
            return View(joke);
        }
    }
}
