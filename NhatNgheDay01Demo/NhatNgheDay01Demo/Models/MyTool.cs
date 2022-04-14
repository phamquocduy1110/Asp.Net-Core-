using System;
using System.Text;

namespace NhatNgheDay01Demo.Models
{
    public class MyTool
    {
        public static string GenerateSecurityCode(int length = 5)
        {
            var pattern = "qazwsxedcrfvtgbyhnujmik<>?lop[]{}1234567890~!@#$%^&*()-=";
            var random = new Random();

            var result = new StringBuilder();
            for(int i = 0; i < length; i++)
            {
                result.Append(pattern[random.Next(0, pattern.Length)]);
            }
            return result.ToString();
        }
    }
}
