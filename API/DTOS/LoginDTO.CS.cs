using System.ComponentModel.DataAnnotations;

namespace API.DTOS
{
    public class LoginDTO
    {
        [Required]
    public string username { get; set; }
    [Required]
    public string password { get; set; }
    
    
            
    }
}