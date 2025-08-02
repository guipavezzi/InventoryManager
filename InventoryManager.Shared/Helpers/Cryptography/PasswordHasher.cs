using System.Security.Cryptography;

public class PasswordHasher
{
    private const int SaltSize = 16;
    private const int KeySize = 32;
    private const int Iterations = 100_00;
    private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA256;

    public (string Hash, string Salt) HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);

        var key = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            Algorithm,
            KeySize);

        return (Convert.ToBase64String(key), Convert.ToBase64String(salt));
    }

    public bool Verify(string password, string Hash, string salt)
    {
        var saltBytes = Convert.FromBase64String(salt);

        var HashToCheck = Rfc2898DeriveBytes.Pbkdf2(
            password,
            saltBytes,
            Iterations,
            Algorithm,
            KeySize);

        return CryptographicOperations.FixedTimeEquals(HashToCheck, Convert.FromBase64String(Hash));
    }
}