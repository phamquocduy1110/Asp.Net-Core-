using System.Text.Json;
using System.Xml.Linq;

namespace Buoi17_First.Models
{
    public static class MyExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }

        public static bool IsPrime(this int number)
        {
            if(number < 2 )
            {
                return false;
            }
            for( int i = 2; i < Math.Sqrt(number); i++ )
            {
                if( number % i == 0 ) {
                    return false;
                }
            }
            return true;
        }

        public static int KhoangCachNgay(this DateTime from, DateTime to)
        {
            return Math.Abs((from - to).Days);
        }
    }
}
