namespace BASITWEBAPI.Models;

public class Message {
    public int Id { get; set;}
    public User User {get; set;}
    public Room Room { get; set;}
    public string MessageValue { get; set;}
    public DateTime Timestamp { get; set;}
}