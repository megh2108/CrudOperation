using CrudOperation.Data.Contract;
using CrudOperation.Models;

namespace CrudOperation.Data.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly IAppDbContext _appDbContext;

        public UserRepository(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<SampleTable> GetAllUsers()
        {
            List<SampleTable> users = _appDbContext.SampleTables.ToList();
            return users;
        }

        public SampleTable GetUserById(int id)
        {
            var user = _appDbContext.SampleTables.FirstOrDefault(c => c.Id == id);

            return user;
        }

        public bool AddUser(SampleTable user)
        {
            var result = false;
            if (user != null)
            {
                _appDbContext.SampleTables.Add(user);
                _appDbContext.SaveChanges();
                result = true;
            }

            return result;
        }

        public bool UpdateUser(SampleTable user)
        {
            var result = false;
            if (user != null)
            {
                _appDbContext.SampleTables.Update(user);
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool DeleteUser(int id)
        {
            var result = false;
            var user = _appDbContext.SampleTables.Find(id);
            if (user != null)
            {
                _appDbContext.SampleTables.Remove(user);
                _appDbContext.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool UserExists(string name)
        {
            var user = _appDbContext.SampleTables.FirstOrDefault(c => c.Name == name);

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UserExists(int id, string name)
        {
            var user = _appDbContext.SampleTables.FirstOrDefault(c => c.Id != id && c.Name == name);

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
