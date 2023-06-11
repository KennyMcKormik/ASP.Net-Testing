using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController : ControllerBase
    {
        private IUserService _userService;

        public CRUDController(IUserService userService) { _userService = userService; }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return await _userService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var result = await _userService.GetUser(id);
            if (result is null)
                return NotFound("User not found");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User request)
        {
            var result = await _userService.AddUser(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<User>>> UpdateUser(int id, User request)
        {
            var result = await _userService.UpdateUser(id, request);

            if (result is null)
                return NotFound("User not found");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);

            if (result is null)
                return NotFound("User not found");

            return Ok(result);
        }

    }
}
