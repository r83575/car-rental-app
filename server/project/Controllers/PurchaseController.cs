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
    public class PurchaseController : ControllerBase
    {
        private IRepository<Purchase> purchaseRepository;

        public PurchaseController(IRepository<Purchase> purchaseRepository)
        {
            this.purchaseRepository = purchaseRepository;
        }

        [HttpGet("get/{id}")]
        public IActionResult GetPurchaseById(int id)
        {
            Purchase p = purchaseRepository.GetById(id);
            if (p == null)
                return NotFound("the user isnot found");
            return Ok(p);
        }

        [HttpGet("getByUser/{id}")]
        public IActionResult GetRentalByUser(int id)
        {
            List<Purchase> r = ((PurchaseRepository)purchaseRepository).GetByUser(id);
            if (r == null)
                return NotFound("the user not has purchase");
            return Ok(r);
        }
        [HttpGet("get")]
        public IActionResult GetAllPurchase()
        {
            List<Purchase> p = purchaseRepository.GetAll();
            if (p == null)
                return NotFound("the user isnot found");
            return Ok(p);
        }

        [HttpPost("add")]
        public ActionResult<Purchase> AddPurchase(Purchase p)
        {
            if (p == null || !ModelState.IsValid)
                return BadRequest();
            Purchase purchase = purchaseRepository.GetById(p.Id);
            if (purchase != null)
                return BadRequest("try to add exist purchase");
            purchaseRepository.Add(p);
            return CreatedAtAction(nameof(AddPurchase), new { id = p.Id },p);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdatePurchase(int id, Purchase p)
        {
            if (p == null || !ModelState.IsValid)
                return BadRequest();
            if (id != p.Id)
                return Conflict();
            return CreatedAtAction(nameof(AddPurchase), new { id = p.Id }, purchaseRepository.Update(p));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            Purchase purchase = purchaseRepository.GetById(id);
            if (purchase == null)
            {
                return NotFound();
            }
            purchaseRepository.Delete(purchase);
            return NoContent();
        }
    }
}
