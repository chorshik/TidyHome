using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidyHome2.DAL.Entities.Entities;
using TidyHome2.DAL.DB.Repository;
using System.Security.Cryptography;
using System.Text.RegularExpressions;


namespace TidyHome2.BLL.Service
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository(new DatabaseFactory());
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public Users GetUserById(long id)
        {
            return _userRepository.GetUserById(id);
        }

        public bool AddRolesUser(IEnumerable<long> rolesuser, int id)
        {
            return _userRepository.AddRolesUser(rolesuser, id);
        }

        public Users GetUserEmailById(string email)
        {
            return _userRepository.GetUserEmailById(email);
        }
        public bool CheckUser(string email, string password)
        {
            ASCIIEncoding enc = new ASCIIEncoding();
            SHA1 sha1 = new SHA1CryptoServiceProvider();

            var user = _userRepository.GetUserEmailById(email);
            if (user != null && email == user.Email && Regex.Replace(BitConverter.ToString(sha1.ComputeHash(enc.GetBytes(password))), "-", "").ToLower() == user.Password)
                return true;
            return false;
        }

        public bool Checkin(Users user, string[] roles)
        {
            return CheckEmail(user.Email) && _userRepository.AddUser(user, roles);
        }

        public bool CheckEmail(string email)
        {
            var user = _userRepository.GetUserEmailById(email);
            return user == null;
        }
    }
}
