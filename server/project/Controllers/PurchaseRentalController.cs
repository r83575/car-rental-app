using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using DAL;
using Microsoft.AspNetCore.Cors;

namespace project.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class PurchaseRentalController : ControllerBase
    {
            private IRepository<PurchaseRental> purchaseRentalRepository;

            public PurchaseRentalController(IRepository<PurchaseRental> purchaseRentalRepository)
            {
                this.purchaseRentalRepository = purchaseRentalRepository;
            }

            [HttpGet("get/{id}")]
            public IActionResult GetPurchaseRentalById(int id)
            {
                PurchaseRental p = purchaseRentalRepository.GetById(id);
                if (p == null)
                    return NotFound("the user isnot found");
                return Ok(p);
            }

            [HttpGet("get")]
            public IActionResult GetAllProducts()
            {
                List<PurchaseRental> p = purchaseRentalRepository.GetAll();
                if (p == null)
                    return NotFound("the user isnot found");
                return Ok(p);
            }

            [HttpPost("add")]
            public ActionResult<PurchaseRental> AddPurchaseRental(PurchaseRental p)
            {
                if (p == null || !ModelState.IsValid)
                    return BadRequest();
                PurchaseRental purchaseRental = purchaseRentalRepository.GetById(p.Id);
                if (purchaseRental != null)
                    return BadRequest("try to add exist purchase Rental");
                purchaseRentalRepository.Add(p);
                return CreatedAtAction(nameof(AddPurchaseRental), new { id = p.Id }, p);
            }

            [HttpPut("update/{id}")]
            public IActionResult UpdateProduct(int id, PurchaseRental p)
            {
                if (p == null || !ModelState.IsValid)
                    return BadRequest();
                if (id != p.Id)
                    return Conflict();
                return CreatedAtAction(nameof(UpdateProduct), new { id = p.Id }, purchaseRentalRepository.Update(p));
            }

            [HttpDelete("Delete")]
            public IActionResult Delete(int id)
            {
                PurchaseRental purchaseRental = purchaseRentalRepository.GetById(id);
                if (purchaseRental == null)
                {
                    return NotFound();
                }
                purchaseRentalRepository.Delete(purchaseRental);
                return NoContent();
            }
        }
}
