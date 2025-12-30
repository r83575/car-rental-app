using DAL;

namespace BLL
{
    public class PurchaseRentalRepository : IRepository<PurchaseRental>
    {
        private Car car;

        public PurchaseRentalRepository(Car car)
        {
            this.car = car;
        }
        public PurchaseRental Add(PurchaseRental entity)
        {
            car.PurchaseRentals.Add(entity);
            car.SaveChanges();
            return entity;
        }

        public void Delete(PurchaseRental entity)
        {
            car.PurchaseRentals.Remove(entity);
            car.SaveChanges();
        }

        public List<PurchaseRental> GetAll()
        {
            return car.PurchaseRentals.ToList();
        }

        public PurchaseRental GetById(int id)
        {
            return car.PurchaseRentals.Find(id);
        }
        public List<PurchaseRental> GetByRentalId(int id)
        {
            return car.PurchaseRentals.Where(x=> x.RentalId == id).ToList();
        }
        public List<PurchaseRental> GetByPurchaseId(int id)
        {
            return car.PurchaseRentals.Where(x => x.PurchaseId == id).ToList();
        }
        public PurchaseRental Update(PurchaseRental entity)
        {
            car.PurchaseRentals.Update(entity);
            car.SaveChanges();
            return entity;
        }
    }
}