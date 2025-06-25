using System.Security.Cryptography;
using System.Text;
using ZooShop.Application.Interfaces;

namespace ZooShop.Application.Services;

public class HashService : IHashService
{
    public string Hash(string input)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));
        var builder = new StringBuilder();

        foreach (var t in bytes)
        {
            builder.Append(t.ToString("x2"));
        }

        return builder.ToString();
    }
}