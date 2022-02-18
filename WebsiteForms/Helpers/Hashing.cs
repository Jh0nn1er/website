using BCript = BCrypt.Net.BCrypt;

namespace WebsiteForms.Helpers
{
    public static class Hashing
    {
        public static string GetRandomSalt(int saltRounds = 12) => BCript.GenerateSalt(saltRounds);
        public static string HashString(string str) => BCript.HashPassword(str);
        public static bool Verify(string str, string hash) => BCript.Verify(str, hash);
    }
}
