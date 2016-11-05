using System.Security.Cryptography;
using System.Text;

namespace EXP.Infrastructure
{
    public class Crypto
    {
        public string ComputeHash(string text)
        {
            string hash = string.Empty;
            using (var algorithm = SHA256.Create()) 
            {
                var hashBytes = algorithm.ComputeHash(Encoding.ASCII.GetBytes(text));
                
                hash = System.Convert.ToBase64String(hashBytes);

            }
            return hash;
        }
    }
}
