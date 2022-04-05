using System.Threading;

namespace NhatNgheDay01Demo.Models
{
    public class Demo
    {
        public string Test01()
        {
            Thread.Sleep(2000);
            return "Test01 - 2s";
        }

        public int Test02()
        {
            Thread.Sleep(5000);
            return 123;
        }
        public void Test03()
        {
            Thread.Sleep(3000);
        }

        public async Task<int> Test01Async()
        {
            await Task.Delay(5000);
            return 7777;
        }
        public async Task<string> Test02Async()
        {
            await Task.Delay(2000);
            return "Nhất Nghệ";
        }
        public async Task Test03Async()
        {
            await Task.Delay(3000);
        }
    }
}
