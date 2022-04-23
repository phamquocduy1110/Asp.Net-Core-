using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace NhatNgheDay01Demo.Controllers
{
    public class ADONETController1 : Controller
    {

        const string ChuoiKetNoi = @"Data Source=DESKTOP-2TJNS3V\MSSQL2019;Initial Catalog=eStore20;Integrated Security=True";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DocDatabase()
        {
            var sql = "SELECT * FROM Loai ORDER BY TenLoai";

            SqlConnection
        }
    }
}
