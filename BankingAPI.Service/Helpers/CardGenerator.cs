using System.Security.Cryptography;
using System.Text;

namespace BankingAPI.Service.Helpers
{
    public class CardGenerator
    {
        public static string GenerateNumber(int size)
        {
            byte[] bytes = new byte[size]; 
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            StringBuilder sb = new StringBuilder(size);
            foreach (byte b in bytes)
            {
                sb.AppendFormat("{0:D2}", b % 100); 
            }
            return sb.ToString().Substring(0, size);
        }

        public static string GenerateExpirationDate()
        {
            return DateTime.Now.AddYears(5).ToString("MM/yyyy");        
        }
    }
}
