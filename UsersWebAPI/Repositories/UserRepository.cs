using System.Xml.Linq;
using UsersWebAPI.Models;

namespace UsersWebAPI.Repositories
{
    public class UserRepository
    {
      
            private static readonly List<User> _users = new();

        //public UserRepository() 
        //{
        //    _users.Add(new User { Id = 1, Name = "moal", Email = "moal@eaaa.dk" }); 
        //}
            public User Create(User user)
            {
               // user.Id = _users.Count + 1;
                _users.Add(user);
                return user;
            }



        public IEnumerable<User>? GetUsers() => _users;
        public User? GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

            public bool Delete(int id)
            {
                var user = GetById(id);
                if (user == null) return false;
                _users.Remove(user);
                return true;
            }
        }
    
}
