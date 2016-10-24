using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Insurance.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDataContext _context;

        public UserRepository(AppDataContext context)
        {
            this._context = context;
        }

        public User GetByEmail(string email)
        {
            return _context.Users
               .Where(x => x.Email.ToLower().Equals(email.ToLower()))
               .ToList()
               .Select(x => new User(x.UserId, x.Email, x.Active, x.RegisterDate, x.LastAccessDate) { })
               .FirstOrDefault();
        }

        public User GetById(Guid id)
        {
            return _context.Users
                .Where(x => x.UserId == id)
                .ToList()
                .Select(x => new User(x.UserId, x.Email, x.Active, x.RegisterDate, x.LastAccessDate) {})
                .FirstOrDefault();
        }

        public List<User> GetByRange(int skip, int take)
        {
            return _context.Users.OrderBy(x => x.Email).Skip(skip).Take(take).ToList();
        }

        public List<User> GetAll()
        {
            return _context.Users.OrderBy(x => x.Email).ToList();
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
