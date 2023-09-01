using System.Security.Claims;
using BASITWEBAPI.Controllers;
using BASITWEBAPI.Models;
using BASITWEBAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BASITWEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : Controller
    {
        private readonly JwtTokenGenerator _jwtTokenGenerator = new JwtTokenGenerator();
        private readonly AppDbContext _dbContext;

        public UserController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<User> users = await _dbContext.Users.ToListAsync();
            return Ok(users);
        }

    [Authorize]
    [HttpPut("password")]
    public IActionResult Put(UpdatePasswordUserRequest request){
       var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value);
        var user = _dbContext.Users.Where(user => user.Id == userId).FirstOrDefault();
        if(user is null) 
        {
            return NotFound();
        }
        if(!BCrypt.Net.BCrypt.Verify(request.Password,user.Password)) {
            return BadRequest("Password wrong");
        }

        user.Password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
        
        _dbContext.SaveChanges();
        
        return Ok();
    }


    [Authorize]
    [HttpPut("profile")]
    public IActionResult Put(UpdateProfileUserRequest request){
       var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value);
        var user = _dbContext.Users.Where(user=>user.Id == userId).FirstOrDefault();
        if (user is null)
        {
            return NotFound();
        }
        if(!BCrypt.Net.BCrypt.Verify(request.Password,user.Password)) {
            return BadRequest("Password wrong");
        }

        user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
        user.Name = request.NewName;
        user.Lastname= request.NewLastname;
        user.Username=request.NewUsername;

        _dbContext.SaveChanges();
        return Ok();
    }

    [HttpPost("login")]
    public IActionResult Post(LoginUserRequest request){
        var user = _dbContext.Users.Where(user => user.Username == request.UserName).FirstOrDefault();
        if(user is null){
            return NotFound("User does not exists");
        }

        BCrypt.Net.BCrypt.Verify(request.Password,user.Password);
        if(!BCrypt.Net.BCrypt.Verify(request.Password,user.Password)) {
            return BadRequest("Password wrong");
        }
        var token = _jwtTokenGenerator.GenerateToken(user);
        return Ok(token);

    }

    [Authorize]
    [HttpPost]
    public IActionResult Post(ValidatePassword request){
       var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value);
        var user = _dbContext.Users.Where(user=>user.Id==userId).FirstOrDefault();
        if (user is null){
            return NotFound();
        }
         if(!BCrypt.Net.BCrypt.Verify(request.Password,user.Password)) {
         return BadRequest("Password wrong");
        }
        return Ok(user);

    }


    [HttpPost("register")]
    public  IActionResult Post(CreateUserRequest request){
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        var user = _dbContext.Users.Where(user => user.Username == request.UserName).FirstOrDefault();
        if(user!=null){
            return Conflict("User with name already exists");
        }
        
        var newUser = new User{
            Name = request.Name,
            Lastname = request.Lastname,
            Username = request.UserName,
            Password = passwordHash,
        };
        _dbContext.Users.Add(newUser);


        _dbContext.SaveChanges();

        return Ok(newUser);

    }

    [Authorize]
    [HttpDelete]
    public IActionResult Delete(){
         var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value);
        var user = _dbContext.Users.Where(user => user.Id == userId).FirstOrDefault();
        if(user is null) {
            return NotFound($"User with ID {userId} not found");
        }

        _dbContext.Remove(user);
        _dbContext.SaveChanges();

        return Ok("Your account has been deleted");
    }

}
}
