using System.Security.Cryptography;
using System.Text;

namespace TaskOfCrocusoft.Services.HashPassword
{
    public class HashPassword
    {
        public string HashThePassword(string password)
        {
            var sha = SHA256.Create();
            var getBytesOfPassword = Encoding.Default.GetBytes(password);
            var hashThePassword = sha.ComputeHash(getBytesOfPassword);


            if (hashThePassword is not null)
                return Convert.ToBase64String(hashThePassword);

            return "Not implemented!";
        }
    }
}