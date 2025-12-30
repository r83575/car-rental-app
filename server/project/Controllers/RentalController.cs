using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using DAL;
using DTO;
using Microsoft.AspNetCore.Cors;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class RentalController : ControllerBase
    {
        private IRepository<Rental> rentalRepository;

        public RentalController(IRepository<Rental> rentalRepository)
        {
            this.rentalRepository = rentalRepository;
        }

        [HttpGet("get/{id}")]
        public IActionResult GetRentalById(int id)
        {
            Rental r = rentalRepository.GetById(id);
            if (r == null)
                return NotFound("the Rental is not found");
            return Ok(r);
        }
        [HttpGet("getByUser/{id}")]
        public IActionResult GetRentalByUser(int id)
        {
            List<Rental> r = ((RentalRepository)rentalRepository).GetByUser(id);
            if (r == null)
                return NotFound("the user not has rentals");
            return Ok(r);
        }

        [HttpGet("get")]
        public IActionResult GetAllRentals()
        {
            List<Rental> p = rentalRepository.GetAll();
            if (p == null)
                return NotFound("the user isnot found");
            return Ok(p);
        }

        [HttpPost("add")]
        public ActionResult<Rental> AddRental(Rental r)
        {
            if (r == null || !ModelState.IsValid)
                return BadRequest();
            Rental rental = rentalRepository.GetById(r.Id);
            if (rental != null)
                return BadRequest("try to add exist rental");
            rentalRepository.Add(r);
            return CreatedAtAction(nameof(AddRental), new { id = r.Id }, r);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateRental(int id, Rental r)
        {
            if (r == null || !ModelState.IsValid)
                return BadRequest();
            if (id != r.Id)
                return Conflict();
            return CreatedAtAction(nameof(AddRental), new { id = r.Id }, rentalRepository.Update(r));
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            Rental rental = rentalRepository.GetById(id);
            if (rental == null)
            {
                return NotFound();
            }
            rentalRepository.Delete(rental);
            return NoContent();
        }
    }
}
