﻿using Tournamint_BackEnd.Database;
using Tournamint_BackEnd.Models;
using Tournamint_BackEnd.Services;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Tournamint_BackEnd.Repositories
{
    public interface IUserRepository
    {
        bool Exist(string userName);
        int Register(LocalUser user);
        bool TryLogin(string userName, string password, out LocalUser? user);
    }
    public class UserRepository : IUserRepository
    {
        private readonly MatchContext _context;
        private readonly IUserService _userService;

        public UserRepository(MatchContext context,
            IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public virtual bool TryLogin(string userName, string password, out LocalUser? user)
        {
            user = _context.Users.FirstOrDefault(x => x.UserName == userName);
            if (user == null)
                return false;
            
            if (!_userService.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return false;
            
            return true;
        }
        
        public int Register(LocalUser user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public bool Exist(string userName)
        {
            return _context.Users.Any(x => x.UserName == userName);
        }
    }
}
