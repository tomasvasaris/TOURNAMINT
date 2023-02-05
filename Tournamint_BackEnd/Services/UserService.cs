﻿using Tournamint_BackEnd.Models;
using Tournamint_BackEnd.Repositories;

namespace Tournamint_BackEnd.Services
{
    public class UserService : IUserService
    {

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256(passwordSalt))
            {
                var cumputedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return cumputedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
