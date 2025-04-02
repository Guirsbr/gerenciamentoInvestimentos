﻿using System.IdentityModel.Tokens.Jwt;
using System.Text;
using investimento.Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace investimento.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public List<User> Get()
        {
            return _context.Users.ToList();
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.email == email);
        }

        public AuthResult GetUserByToken(string token)
        {
            var authResult = new AuthResult("", false, "");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Key.Secret);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out _);

                var jwtToken = tokenHandler.ReadJwtToken(token);
                var jwtUserId = jwtToken.Payload["userId"];
                var userId = Convert.ToInt32(jwtUserId);

                var databaseUser = _context.Users.FirstOrDefault(u => u.id == userId);
                if (databaseUser == null)
                {
                    return authResult;
                }

                return new AuthResult(token, true, databaseUser.name);
            }
            catch
            {
                return authResult;
            }
        }
    }
}
