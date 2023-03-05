using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroApp.Library.Tools
{
    public static class PasswordSecurity
    {
        public static string EncryptPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        public static bool DecryptPassword(string password, string encryptedPassword) => BCrypt.Net.BCrypt.Verify(password, encryptedPassword);
    }
}
