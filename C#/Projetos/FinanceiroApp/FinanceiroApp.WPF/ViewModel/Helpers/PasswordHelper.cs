namespace FinanceiroApp.WPF.ViewModel.Helpers
{
    public static class PasswordHelper
    {
        public static string EncryptPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
        public static bool DecryptPassword(string password, string encryptedPassword) => BCrypt.Net.BCrypt.Verify(password, encryptedPassword);
    }
}
