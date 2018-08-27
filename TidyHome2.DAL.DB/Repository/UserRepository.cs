using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidyHome2.DAL.Entities.Entities;
using TidyHome2.DAL.DB.Interfaces;

namespace TidyHome2.DAL.DB.Repository
{
    public class UserRepository : BaseRepository<Users>
    {
        public UserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public IEnumerable<Roles> GetRolesUserById(string username)
        {
            return Context.FirstOrDefault(c => c.Email == username)?.Roles;
        }
        public IEnumerable<Roles> GetRolesUserById(long id)
        {
            return Context.FirstOrDefault(c => c.IdUsers == id)?.Roles;
        }
        public Users GetUserEmailById(string email)
        {
            return Context.FirstOrDefault(c => c.Email == email);

        }

        public bool AddUser(Users user)
        {
            Context.Add(user);
            try
            {
                Save();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool AddUser(Users user, string[] roles)
        {
            var u = Context.Add(user);
            try
            {
                for (int i = 0; i < roles.Length; i++)
                {
                    var r = roles[i];
                    u.Roles.Add(DataContext.Roles.SingleOrDefault(c => c.Role == r));
                }
                Save();

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public IEnumerable<Users> GetAllUsers()
        {
            return Context.ToList();
        }
        public IEnumerable<Users> GetFindUsers(string term)
        {
            string[] mass = term.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var q = from p in Context
                    from m in mass
                    where
                        mass.Any(i => p.Surname.Contains(i)) ||
                        mass.Any(i => p.Name.Contains(i)) ||
                        mass.Any(i => p.Patronymic.Contains(i))
                    select p;
            return q;
        }
        public Users GetUserById(long id)
        {
            return Context.FirstOrDefault(c => c.IdUsers == id);
        }
        public bool EditUser(int id, Users users)
        {
            var context = Context.SingleOrDefault(c => c.IdUsers == id);
            try
            {
                context.Surname = users.Surname != context.Surname ? users.Surname : context.Surname;
                context.Name = users.Name != context.Name ? users.Name : context.Name;
                context.Patronymic = users.Patronymic != context.Patronymic ? users.Patronymic : context.Patronymic;
                //context.Email = users.Email != null && users.Email != context.Email ? users.Email : context.Email;               
                context.Address = users.Address != context.Address ? users.Address : context.Address;
                context.Phone = users.Phone != context.Phone ? users.Phone : context.Phone;
                context.Discount = users.Discount != context.Discount ? users.Discount : context.Discount;
                context.IdType = users.IdType != context.IdType ? users.IdType : context.IdType;

                

                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveUserById(int id)
        {
            var context = Context.SingleOrDefault(c => c.IdUsers == id);
            try
            {
                var roles = new List<Roles>();
                foreach (var role in context.Roles)
                {
                    roles.Add(role);
                }
                foreach (var role in roles)
                {
                    DataContext.Roles.Remove(role);
                }
                Context.Remove(context);

                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public IEnumerable<Bids> GetBidUserById(string name)
        //{
        //    return Context.FirstOrDefault(c => c.Email == name)?.Bids;
        //}
        //public IEnumerable<Orders> GetOrderUserById(string name)
        //{
        //    return Context.FirstOrDefault(c => c.Email == name)?.Orders;
        //}

        //public bool CompleteOrderByIdForUser(int id, string name)
        //{
        //    var q = Context.FirstOrDefault(c => c.Email == name)?.Orders.SingleOrDefault(o => o.IdOrder == id);
        //    q.DateEnd = DateTime.Now;
        //    q.IdStatus = 2;
        //    try
        //    {
        //        Save();
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //public IEnumerable<Users> GetAllUserEmployeeTypeById(int id)
        //{
        //    return Context.Where(c => c.TypeService.IdType == id && c.Roles.Any(b => b.Role == "Employee")).ToList();
        //}
        public bool AddRolesUser(IEnumerable<long> rolesuser, int id)
        {
            try
            {
                var user = Context.SingleOrDefault(c => c.IdUsers == id);

                user.Roles.Clear();

                foreach (var roleuser in rolesuser)
                {
                    user.Roles.Add(DataContext.Roles.SingleOrDefault(c => c.IdRole == roleuser));
                }

                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
