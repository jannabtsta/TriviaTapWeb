using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TriviaTapWeb.Models;

namespace TriviaTapWeb.Controllers
{
    public class QuestionController : Controller
    {

        private readonly TriviaDBContext _context;

        public QuestionController(TriviaDBContext context)
        {
            _context = context;
        }
        // GET: QuestionController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddQuestion(int QuizID)
        {
            var quiz = _context.Quizzes.FirstOrDefault(q => q.QuizID == QuizID);
            if (quiz == null)
            {
                return NotFound();
            }

            ViewBag.QuizID = QuizID;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion(int QuizID, string questionName, List<string> options, int correctOptionIndex)
        {
            var quiz = await _context.Quizzes.FirstOrDefaultAsync(q => q.QuizID == QuizID);
            if (quiz == null)
            {
                return NotFound();
            }

            // Create a new question
            var question = new Question
            {
                QuizID = QuizID,
                QuestionName = questionName,
            };

            // Add options
            for (int i = 0; i < options.Count; i++)
            {
                question.Options.Add(new Option
                {
                    Options = options[i],
                    IsCorrect = (i == correctOptionIndex) // Mark the correct option
                });
            }

            // Add the question to the quiz
            quiz.Questions.Add(question);

            // Save changes to the database
            _context.Quizzes.Update(quiz);
            await _context.SaveChangesAsync();

            return RedirectToAction("IndexAsAdmin", "Quiz", new { quizId = QuizID });
        }



        // GET: QuestionController/Details/5
        public async Task<IActionResult> ListQuestions(int QuizID)
        {
            // Fetch the quiz along with its questions and options
            var quiz = await _context.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(q => q.Options)
                .FirstOrDefaultAsync(q => q.QuizID == QuizID);

            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz); // Pass the quiz model to the view
        }

        // GET: QuestionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: QuestionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuestionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: QuestionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuestionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
