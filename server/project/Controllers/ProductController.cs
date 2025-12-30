using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using DAL;
using Microsoft.AspNetCore.Cors;
using DTO;
using AutoMapper;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ProductController : ControllerBase
    {
        private IRepository<Product> productRepository;
        private IMapper mapper;

        public ProductController(IRepository<Product> productRepository,IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        
        }

        [HttpGet("get/{id}")]
        public IActionResult GetProductById(int id)
        {
            Product p = productRepository.GetById(id);
            if (p == null)
                return NotFound("the user isnot found");
            return Ok(mapper.Map<ProductDTO>(p));
        }

        [HttpGet("get")]
        public IActionResult GetAllProducts()
        {
            List<Product> p = productRepository.GetAll();
            if (p == null)
                return NotFound("the user isnot found");
            return Ok(mapper.Map<List<ProductDTO>>(p));
        }

        [HttpPost("add")]
        public ActionResult<Product> AddProduct([FromForm] ProductDTO p)
        {
            if (p == null || !ModelState.IsValid)
                return BadRequest();

            // שמירת קובץ התמונה
            var pathImage = Path.Combine(Environment.CurrentDirectory, "Images\\", p.ImageFile.FileName);
            using (FileStream fs = new FileStream(pathImage, FileMode.Create))
            {
                p.ImageFile.CopyTo(fs);
                fs.Close();
            }
            p.Image = pathImage.ToString();

            // שמירת קובץ הלוגו
            var pathLogo = Path.Combine(Environment.CurrentDirectory, "Images\\", p.LogoFile.FileName);
            using (FileStream fs = new FileStream(pathLogo, FileMode.Create))
            {
                p.LogoFile.CopyTo(fs);
                fs.Close();
            }
            p.Logo = pathLogo.ToString();

            Product product = productRepository.GetById(p.Id);
            if (product != null)
                return BadRequest("try to add exist product");
            productRepository.Add(mapper.Map<Product>(p));
            return CreatedAtAction(nameof(AddProduct), new { id = p.Id }, p);
        }



        [HttpPut("update/{id}")]
        public IActionResult UpdateProduct(int id, Product p)
        {
            if (p == null || !ModelState.IsValid)
                return BadRequest();
            if (id != p.Id)
                return Conflict();
            return CreatedAtAction(nameof(UpdateProduct), new { id = p.Id }, productRepository.Update(p));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            Product product = productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            productRepository.Delete(product);
            return NoContent();
        }
    }
}
