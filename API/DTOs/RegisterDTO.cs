using System.ComponentModel.DataAnnotations;

namespace API;

public class RegisterDTO
{
    [Required]
    // [MaxLength(100)]
    public string Username {get;set;}
    [Required]

    public string Password {get;set;}

}
