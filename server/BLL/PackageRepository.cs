using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class PackageRepository : IRepository<Package>
    {
        private Car car;

        public PackageRepository(Car car)
        {
            this.car = car;
        }

        public Package Add(Package entity)
        {
            car.Packages.Add(entity);
            car.SaveChanges();
            return entity;
        }

        public void Delete(Package entity)
        {
            car.Packages.Remove(entity);
            car.SaveChanges();
        }

        public Package GetById(int id)
        {
            return car.Packages.Find(id);
        }
        public List<Package> GetAll()
        {
            return car.Packages.ToList();
        }

        public Package Update(Package entity)
        {
            car.Packages.Update(entity);
            car.SaveChanges();
            return entity;
        }
    }
}
