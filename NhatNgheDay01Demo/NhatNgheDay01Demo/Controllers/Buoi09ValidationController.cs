using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using NhatNgheDay01Demo.Models;

namespace NhatNgheDay01Demo.Controllers
{
    public class Buoi09ValidationController : Controller
    {
        public IActionResult DemoAsyncRun()
        {
            Stopwatch sw = new Stopwatch();
            Demo demo = new Demo();
            sw.Start();
            demo.Test01();
            demo.Test02();
            demo.Test03();
            // Task.WaitAll()
            sw.Stop();
            return Content($"Chạy hết {sw.ElapsedMilliseconds} ms.");

        }

        public async Task<IActionResult> Async()
        {
            Stopwatch sw = new Stopwatch();
            Demo demo = new Demo();
            sw.Start();
            var a = demo.Test01Async();
            var b = demo.Test02Async();
            var c = demo.Test03Async();
            await a; await b; await c;
            sw.Stop();
            return Content($"Chạy hết {sw.ElapsedMilliseconds / 1000} ms.");
        }

        public IActionResult DemoRazor()
        {
            return View();
        }
    }
}
