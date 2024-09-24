using CrudOperation.Models;

namespace CrudOperation.Data.Contract
{
    public interface IUserRepository
    {
         IEnumerable<SampleTable> GetAllUsers();

         bool AddUser(SampleTable user);

        bool UpdateUser(SampleTable user);

        bool DeleteUser(int id);

        public bool UserExists(string name);
        public bool UserExists(int id, string name);
    }
}
