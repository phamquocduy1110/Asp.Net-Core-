using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace NhatNgheDay01Demo.Controllers
{
    public class ADONETController : Controller
    {

        //const string ChuoiKetNoi = @"Data Source=DESKTOP-2TJNS3V\MSSQL2019;Initial Catalog=eStore20;Integrated Security=True";
        
        public ADONETController(IConfiguration configuration)
        {
            _configuration = configuration;
            ChuoiKetNoi = _configuration.GetConnectionString("EStore");

        }

        string ChuoiKetNoi = string.Empty;
        private readonly IConfiguration _configuration;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DocDatabase()
        {
            var sql = "SELECT * FROM Loai ORDER BY TenLoai";

            SqlConnection connection = new SqlConnection(ChuoiKetNoi);
            SqlDataAdapter da = new SqlDataAdapter(sql, connection);

            DataTable dtLoai = new DataTable();
            da.Fill(dtLoai);

            // Process result
            var sb = new StringBuilder();
            foreach (DataRow dr in dtLoai.Rows)
            {
                sb.AppendLine($"{dr["MaLoai"]} - {dr["TenLoai"]}");
            }

            return Content(sb.ToString());

        }

        public IActionResult ThemLoai(string TenLoai, string MoTa)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ChuoiKetNoi);
                var sql = $"insert into Loai(TenLoai, MoTa) values(N'{TenLoai}', N'{MoTa}')";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return Content("Thêm thành công");
            }
            catch (Exception ex)
            {
                return Content($"Lỗi: , { ex.Message}");
            }
        }
    }
}
