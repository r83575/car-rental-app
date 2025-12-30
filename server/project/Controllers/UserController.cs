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
    public class UserController : ControllerBase
    {
        private IRepository<User> userRepository;

        public UserController(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet("get/{id}")]
        public IActionResult GetUserById(int id)
        {
            User u = userRepository.GetById(id);
            if(u == null)
                return NotFound("the user isnot found");
             return Ok(u);
        }
        [HttpGet("getByTz/{Tz}")]
        public IActionResult GetUserByTz(int Tz)
        {
            User u =((UserRepository)userRepository).GetByTz(Tz);
            if (u == null)
                return NotFound("the user is not found");
            return Ok(u);
        }

        [HttpGet("get")]
        public IActionResult GetAll()
        {
            List<User> p = userRepository.GetAll();
            if (p == null)
                return NotFound("the user isnot found");
            return Ok(p);
        }

        [HttpPost("add")]
        public ActionResult<User>AddUser(User u)

        {
            if (u == null || !ModelState.IsValid)
                return BadRequest("you dont enter details");
            User user = ((UserRepository)userRepository).GetByTz(u.Tz);
            if (user != null)
                return BadRequest("try to add exist user");
            userRepository.Add(u);
            return CreatedAtAction(nameof(AddUser), new {Tz=u.Tz},u);
        }

        [HttpPost("login")]
        public ActionResult<User> LogIn(User u)
        {
            if (u == null || !ModelState.IsValid)
                return BadRequest("abcsde");
            User user = ((UserRepository)userRepository).GetByTz(u.Tz);
            if (user != null)
                if (user.Password.Equals(u.Password))
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest("you entered mistake password");
                }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateUser(int id, User u)
        {
            if (u == null || !ModelState.IsValid)
                return BadRequest();
            if (id != u.Tz)
                return Conflict();
            return CreatedAtAction(nameof(AddUser), new { id = u.Tz }, userRepository.Update(u));
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            User user = userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            userRepository.Delete(user);
            return NoContent();
        }
    }
}
