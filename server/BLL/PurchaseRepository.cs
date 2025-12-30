using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class PurchaseRepository : IRepository<Purchase>
    {
        private Car car;

        public PurchaseRepository(Car car)
        {
            this.car = car;
        }

        public Purchase Add(Purchase entity)
        {
            car.Purchases.Add(entity);
            car.SaveChanges();
            return entity;
        }

        public void Delete(Purchase entity)
        {
            car.Purchases.Remove(entity);
            car.SaveChanges();
        }

        public Purchase GetById(int id)
        {
            return car.Purchases.Find(id);
        }
        public List<Purchase> GetByUser(int id)
        {
            List<Purchase> purchaseList = car.Purchases.Where(x => x.UserId == id).ToList();
            return purchaseList;  
        }
        public List<Purchase> GetAll()
        {
            return car.Purchases.ToList();
        }

        public Purchase Update(Purchase entity)
        {
            car.Purchases.Update(entity);
            car.SaveChanges();
            return entity;
        }
    }
}
