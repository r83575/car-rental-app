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
    public class PackageController : ControllerBase
    {
        private IRepository<Package>packageRepository;

        public PackageController(IRepository<Package> packageRepository)
        {
            this.packageRepository = packageRepository;
        }

        [HttpGet("get/{id}")]
        public IActionResult GetPackageById(int id)
        {
            Package p = packageRepository.GetById(id);
            if (p == null)
                return NotFound("the user isnot found");
            return Ok(p);
        }

        [HttpGet("get")]
        public IActionResult GetAllPackages()
        {
            List<Package> p = packageRepository.GetAll();
            if (p == null)
                return NotFound("the user isnot found");
            return Ok(p);
        }

        [HttpPost("add")]
        public ActionResult<Package> AddPackage(Package p)
        {
            if (p == null || !ModelState.IsValid)
                return BadRequest();
            Package package = packageRepository.GetById(p.Id);
            if (package != null)
                return BadRequest("try to add exist package");
            packageRepository.Add(p);
            return CreatedAtAction(nameof(AddPackage), new { id = p.Id }, p);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdatePackage(int id,Package p)
        {

            if (p == null || !ModelState.IsValid)
                return BadRequest();
            if(id != p.Id)
                return Conflict();
            return CreatedAtAction(nameof(AddPackage), new { id = p.Id }, packageRepository.Update(p)); 
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            Package package = packageRepository.GetById(id);    
            if(package  == null)
            {
                return NotFound();
            }
            packageRepository.Delete(package);
            return NoContent();
        }
    }
}
