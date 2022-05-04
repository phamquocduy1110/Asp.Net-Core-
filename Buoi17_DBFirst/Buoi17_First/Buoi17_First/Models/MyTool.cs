namespace Buoi17_First.Models
{
    /// <summary>
    /// Các tiện ích 
    /// </summary>
    public class MyTool
    {
        /// <summary>
        /// Upload file vào thư mục chỉ định
        /// </summary>
        /// <param name="myfile">file gửi lên</param>
        /// <param name="folder">thư mục lưu (trong wwwroot\Hinh)</param>
        /// <returns></returns>
        public static string UploadFileToFolder(IFormFile myfile, string folder)
        {
            try
            {
                var fileName = DateTime.Now.Ticks.ToString() + myfile.FileName;

                string fullPathFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", folder, fileName);

                using (var file = new FileStream(fullPathFile, FileMode.Create))
                {
                    myfile.CopyTo(file);
                }
                return fileName;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
