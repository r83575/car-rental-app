using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using BLL.cast;
using Microsoft.EntityFrameworkCore;
using NHibernate.Mapping;

namespace BLL
{
    public class RentalRepository : IRepository<Rental>
    {
        private Car car;
        public RentalRepository(Car car)
        {
            this.car = car;
            //this.mapper = mapper;
        }

        public Rental Add(Rental entity)
        {
            car.Rentals.Add(entity);
            car.SaveChanges();
            return entity;
        }

        public void Delete(Rental entity)
        {
            car.Rentals.Remove(entity);
            //car.Rentals.AsNoTracking().ToList().Remove(mapper.Map<Rental>(entity));

            car.SaveChanges();
        }

        public Rental GetById(int id)
        {
            //return mapper.Map<Rental>(car.Rentals.Find(id));
            return car.Rentals.Find(id);
        }

        public List<Rental> GetByUser(int id)
        {
            PurchaseRepository p = new PurchaseRepository(car);
            PurchaseRentalRepository pr = new PurchaseRentalRepository(car);
            RentalRepository r = new RentalRepository(car);

            List<Purchase> purchaseList = car.Purchases.Where(x => x.UserId == id).ToList();
            List<int> purchaseIds = purchaseList.Select(x => x.Id).ToList();
            List<PurchaseRental> prList = purchaseIds.SelectMany(x => pr.GetByPurchaseId(x)).ToList();
            List<int> rentalIds = prList.Select(x => x.RentalId).Distinct().ToList();
            List<Rental> rentals = rentalIds.Select(x => r.GetById(x)).ToList();
            return rentals;
        }
        public List<Rental> GetAll()
        {
            return car.Rentals.ToList();
        }

        public Rental Update(Rental entity)
        {
            car.Rentals.Update(entity);
            car.SaveChanges();
            return entity;
        }
    }
}