using Microsoft.EntityFrameworkCore;

namespace BASITWEBAPI.Models;


public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public List<Room> Rooms { get; set; } = new List<Room>();
}
