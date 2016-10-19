using Insurance.Domain.Models;
using Insurance.Domain.Repositories;
using Insurance.Infraestructure.Data;
using System.Linq;

namespace Insurance.Infraestructure.Repositories
{
    public class SecurityRepository : ISecurityRepository
    {
        private AppDataContext _context;

        public SecurityRepository(AppDataContext contex)
        {
            this._context = contex;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public User Get(string email)
        {
            return _context.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public void Update(User user)
        {
            _context.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
