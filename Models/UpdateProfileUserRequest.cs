namespace BASITWEBAPI.Models;

public class UpdateProfileUserRequest
{
    public string NewName { get; set; }
    public string NewLastname { get; set; }
    public string NewUsername { get; set; }
    public string Password { get; set; }
}