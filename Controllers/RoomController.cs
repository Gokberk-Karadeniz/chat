using System.Security.Claims;
using BASITWEBAPI.Controllers;
using BASITWEBAPI.Controllers;
using BASITWEBAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BASITWEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : Controller
    {
        private readonly AppDbContext _dbContext;

        public RoomController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize]
        [HttpGet("room")]
        public async Task<IActionResult> Get()
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value);
            var user = _dbContext.Users.Where(user => user.Id == userId).FirstOrDefault();
            if (user is null)
            {
                return NotFound($"User with ID {userId} not found");
            }

            List<Room> rooms = await _dbContext.Rooms.Where(room => room.Users.Contains(user)).ToListAsync();

            return Ok(rooms);
        }

        [Authorize]
        [HttpPost("join")]
        public IActionResult Post(JoinRoomRequest request)
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value);
            var user = _dbContext.Users.Where(user => user.Id == userId).FirstOrDefault();
            if (user is null)
            {
                return NotFound($"User with ID {userId} not found");
            }

            var room = _dbContext.Rooms.Where(room => room.Name == request.RoomName).FirstOrDefault();
            if (room == null)
            {
                return NotFound();
            }
            if (request.RoomPassword != room.Password)
            {
                return BadRequest("Password wrong");
            }

            room.Users.Add(user);

            _dbContext.SaveChanges();

            return Ok(room);
        }

        [Authorize]
        [HttpPut("{roomId:int}/password")]
        public IActionResult Put(int roomId, UpdatePasswordRoomRequest request)
        {
            var room = _dbContext.Rooms.Where(room => room.Id == roomId).FirstOrDefault();
            if (room == null)
            {
                return NotFound();
            }
            if (room.Password != request.RoomPassword)
            {
                return BadRequest("Room password wrong");
            }
            room.Password = request.NewRoomPassword;
            _dbContext.SaveChanges();
            return NoContent();
        }

        [Authorize]
        [HttpPut("{roomId:int}/profile")]
        public IActionResult Put(int roomId, UpdateRoomRequest request)
        {
            var room = _dbContext.Rooms.Where(room => room.Id == roomId).FirstOrDefault();
            if (room is null)
            {
                return NotFound();
            }
            if (room.Name != request.RoomName)
            {
                return BadRequest("Room name wrong");
            }
            room.Name = request.NewRoomName;
            _dbContext.SaveChanges();
            return NoContent();
        }

        [Authorize]
        [HttpPost("addroom")]
        public IActionResult Post(CreateRoomRequest request)
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value);
            var user = _dbContext.Users.Where(user => user.Id == userId).FirstOrDefault();
            if (user is null)
            {
                return NotFound($"User with ID {userId} not found");
            }

            var room = _dbContext.Rooms.Where(room => room.Name == request.RoomName).FirstOrDefault();
            if (room != null)
            {
                return Conflict("Room with name already exists");
            }

            var newRoom = new Room
            {
                Name = request.RoomName,
                Password = request.RoomPassword,
            };
            newRoom.Users.Add(user);

            _dbContext.Rooms.Add(newRoom);
            _dbContext.SaveChanges();

            return Ok(newRoom);

        }

        [HttpDelete("{roomId:int}")]
        public IActionResult Delete(int roomId)
        {
            var room = _dbContext.Rooms.Where(room => room.Id == roomId).FirstOrDefault();
            if (room is null)
            {
                return NotFound($"Room with ID {roomId} not found");
            }
            _dbContext.Remove(room);
            _dbContext.SaveChanges();

            return NoContent();
        }


    }
}

