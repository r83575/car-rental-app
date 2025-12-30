using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class UserRepository : IRepository<User>
    {
        private Car car;
        public UserRepository(Car car)
        {
            this.car = car;
        }

        public User Add(User entity)
        {
            car.Users.Add(entity);
            car.SaveChanges();
            return entity;
        }

        public void Delete(User entity)
        {
            car.Users.Remove(entity);
            car.SaveChanges();
        }

        public User GetById(int id)
        {
            return car.Users.Find(id);
        }
        public User GetByTz(int Tz)
        {
            User user = car.Users.Where(x => x.Tz == Tz).FirstOrDefault();
            return user;
        }
        public List<User> GetAll()
        {
            return car.Users.ToList();
        }

        public User Update(User entity)
        {
            car.Users.Update(entity);
            car.SaveChanges();
            return entity;
        }
    }
}
