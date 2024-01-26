using System.Security.Cryptography;
using System.Text;
using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Application.Validators
{
    public static class UserValidator
    {
        public static User AddUser(string email, string password, Guid employeeId)
        {
            if (string.IsNullOrEmpty(email)) throw new Exception("O email e obrigatório.");

            if (string.IsNullOrEmpty(password)) throw new Exception("O Password e Obrigatório");

            return new User(Guid.NewGuid(), email, ComputeSha256Hash(password), employeeId);
        }

        public static string ComputeSha256Hash(string password)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

            var builder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
