using WebsiteForms.Database;
using WebsiteForms.Database.Entities;

namespace WebsiteForms.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetAll()
        {
            List<User> users;
            using (var db = new WebsiteFormsContext())
            {
                users = db.Users.ToList();
            }

            return users;
        }

        public User GetById(int id)
        {
            User user;
            using (var db = new WebsiteFormsContext())
            {
                user = db.Users.Find(id);
            }

            return user;
        }

        public User? GetByUsername(string username)
        {
            User? user;
            using (var db = new WebsiteFormsContext())
            {
                user = db.Users.Where(u => u.Username == username).FirstOrDefault();
            }

            return user;
        }
    }
}
