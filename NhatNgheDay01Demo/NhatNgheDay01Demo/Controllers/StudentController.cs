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

        [HttpGet]
        public IActionResult ReadData(string type)
        {
            try
            {
                if (type == "JSON")
                {
                    var json_data = System.IO.File.ReadAllText(PathTxtFile);
                    var student = System.Text.Json.JsonSerializer.Deserialize<StudentInfo>(json_data);
                    return View("Index", student);
                }
                else if (type == "TXT")
                {
                    var lines = System.IO.File.ReadAllLines(PathTxtFile);
                    var student = new StudentInfo
                    {
                        StudentId = lines[0],
                        FullName = lines[1],
                        Grade = double.Parse(lines[2]),

                    };
                    return View("Index", student);
                }
                ViewBag.ErrorMessage = $"Chưa hỗ trợ loại: {type}";
                return View("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Lỗi: {ex.Message}";
                return View("Index");

            }
        }
    }
}
