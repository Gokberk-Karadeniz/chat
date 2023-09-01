using Microsoft.EntityFrameworkCore;

namespace BASITWEBAPI.Models

{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}