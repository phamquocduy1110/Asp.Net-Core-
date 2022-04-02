using Microsoft.AspNetCore.Mvc;
using NhatNgheDay01Demo.Models;

namespace NhatNgheDay01Demo.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        const string JSON_FILE = "Student.json";
        const string TEXT_FILE = "Student.txt";

        public string PathTxtFile => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", TEXT_FILE);
        public string PathJsonFile => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", JSON_FILE);

        [HttpPost]
        public IActionResult Index(StudentInfo model, string Save)
        {
            if (ModelState.IsValid)
            {
                if (Save == "Ghi file Text")
                {
                    var data = new string[] {
                        model.StudentId,
                        model.FullName,
                        model.Grade.ToString(),
                        model.Rating
                    };
                    System.IO.File.WriteAllLines(PathTxtFile, data);
                }
                else if (Save == "Ghi file Json")
                {
                    // Conver obect to json
                    var json_data = System.Text.Json.JsonSerializer.Serialize(model);
                    System.IO.File.WriteAllText(PathJsonFile, json_data);
                }
            }
            return View();
        }
    }
}
