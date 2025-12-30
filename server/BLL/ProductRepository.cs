using DAL;
namespace BLL
{
    public class ProductRepository : IRepository<Product>
    {
        private Car car;

        public ProductRepository(Car car)
        {
            this.car = car;
        }
        public Product Add(Product entity)
        {
            car.Products.Add(entity);
            car.SaveChanges();
            return entity;
        }

        public void Delete(Product entity)
        {
            car.Products.Remove(entity);
            car.SaveChanges();
        }

        public Product GetById(int id)
        {
            return car.Products.Find(id);
        }
        public List<Product> GetAll()
        {
            return car.Products.ToList();
        }

        public Product Update(Product entity)
        {
            car.Products.Update(entity);
            car.SaveChanges();
            return entity;
        }
    }
}