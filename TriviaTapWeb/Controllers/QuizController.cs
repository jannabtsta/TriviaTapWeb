using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TriviaTapWeb.Models;

namespace TriviaTapWeb.Controllers
{
    public class QuizController : Controller

    {
        
            private readonly TriviaDBContext _context;

            public QuizController(TriviaDBContext context)
            {
                _context = context;
            }
            // GET: QuizController
            public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexAsAdmin()
        {
            return View();
        }



        public async Task<IActionResult> History(int questionIndex = 0)
        {
            int quizId = 1; // History Quiz has QuizID = 1
            var quiz = await _context.Quizzes
                .Include(q => q.Questions)
                    .ThenInclude(q => q.Options)
                .FirstOrDefaultAsync(q => q.QuizID == quizId);

            if (quiz == null)
            {
                return NotFound();
            }

            var currentQuestion = quiz.Questions.Skip(questionIndex).FirstOrDefault();

            if (currentQuestion == null)
            {
                ViewBag.Score = TempData["Score"];
                return View("QuizResult", quiz);
            }

            ViewBag.QuizId = quizId; // Ensure QuizID is passed to the view
            ViewBag.QuestionIndex = questionIndex;
            ViewBag.TotalQuestions = quiz.Questions.Count;

            return View("History", currentQuestion);
        }

        public async Task<IActionResult> Science(int questionIndex = 0)
        {
            int quizId = 2; 
            var quiz = await _context.Quizzes
                .Include(q => q.Questions)
                    .ThenInclude(q => q.Options)
                .FirstOrDefaultAsync(q => q.QuizID == quizId);

            if (quiz == null)
            {
                return NotFound();
            }

            var currentQuestion = quiz.Questions.Skip(questionIndex).FirstOrDefault();

            if (currentQuestion == null)
            {
                ViewBag.Score = TempData["Score"];
                return View("QuizResult", quiz);
            }

            ViewBag.QuizId = quizId; // Ensure QuizID is passed to the view
            ViewBag.QuestionIndex = questionIndex;
            ViewBag.TotalQuestions = quiz.Questions.Count;

            return View("Science", currentQuestion);
        }

        public async Task<IActionResult> Trivia(int questionIndex = 0)
        {
            int quizId = 3;
            var quiz = await _context.Quizzes
                .Include(q => q.Questions)
                    .ThenInclude(q => q.Options)
                .FirstOrDefaultAsync(q => q.QuizID == quizId);

            if (quiz == null)
            {
                return NotFound();
            }

            var currentQuestion = quiz.Questions.Skip(questionIndex).FirstOrDefault();

            if (currentQuestion == null)
            {
                ViewBag.Score = TempData["Score"];
                return View("QuizResult", quiz);
            }

            ViewBag.QuizId = quizId; // Ensure QuizID is passed to the view
            ViewBag.QuestionIndex = questionIndex;
            ViewBag.TotalQuestions = quiz.Questions.Count;

            return View("Trivia", currentQuestion);
        }


        [HttpPost]
        public IActionResult SubmitQuiz(int quizId, int questionId, int selectedOptionId, int questionIndex)
        {
            var question = _context.Questions
                .Include(q => q.Options)
                .FirstOrDefault(q => q.QuestionID == questionId);

            if (question == null)
            {
                return NotFound();
            }

            var selectedOption = question.Options.FirstOrDefault(o => o.OptionID == selectedOptionId);
            if (selectedOption != null && selectedOption.IsCorrect)
            {
                if (TempData["Score"] == null)
                {
                    TempData["Score"] = 1;
                }
                else
                {
                    TempData["Score"] = (int)TempData["Score"] + 1;
                }
            }

            // Redirect to the appropriate quiz based on quizId
            if (quizId == 1)
            {
                return RedirectToAction("History", new { quizId = 1, questionIndex = questionIndex + 1 });
            }
            else if (quizId == 2)
            {
                return RedirectToAction("Science", new { quizId = 2, questionIndex = questionIndex + 1 });
            }
            else if (quizId == 3)
            {
                return RedirectToAction("Trivia", new { quizId = 3, questionIndex = questionIndex + 1 });
            }

            return RedirectToAction("Quiz", new { quizId = quizId, questionIndex = questionIndex + 1 });
        }




        // GET: QuizController/Create
       

      

        // GET: QuizController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuizController/Edit/5
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

        // GET: QuizController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuizController/Delete/5
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
