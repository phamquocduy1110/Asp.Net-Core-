using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi17_First.Utils
{
    public class MyTool
    {
        public static string FullPathFolderImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh");

        public static string NoImage = "no-image-available.png";
        public static string? ImageToBase64(string fileName, string folder)
        {
            var fullPath = Path.Combine(FullPathFolderImage, folder, fileName);
            if (File.Exists(fullPath))
            {
                byte[] data = File.ReadAllBytes(fullPath);
                return Convert.ToBase64String(data);
            }

            return null;
        }

        public static string CheckImageExist(string fileName, string folder)
        {
            if (File.Exists(Path.Combine(FullPathFolderImage, folder, fileName)))
            {
                return $"{folder}/{fileName}";
            }
            return NoImage;
        }

        public static string GetRandom(int length = 5)
        {
            var pattern = @"1234567890qazwsxedcrfvtgbyhn@#$%";
            var rd = new Random();
            var sb = new StringBuilder();
            for (int i = 0; i < length; i++)
                sb.Append(pattern[rd.Next(0, pattern.Length)]);

            return sb.ToString();
        }


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
                var myFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", folder);
                if (!Directory.Exists(myFolder))
                {
                    Directory.CreateDirectory(myFolder);
                }

                string fullPathFile = Path.Combine(myFolder, fileName);
                using (var file = new FileStream(fullPathFile, FileMode.Create))
                {
                    myfile.CopyTo(file);
                }
                return fileName;
            }
            catch { return string.Empty; }
        }
    }
}