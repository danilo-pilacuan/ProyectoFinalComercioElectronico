using System.ComponentModel.DataAnnotations;
using ComercioElectronico.Domain;

namespace ComercioElectronico.Application;

public class UserDto
{
    [Required]
    [StringLength(DominioConstantes.ID_MAX)]
    public string Id{get;set;}
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAX)]
    public string UserName{get;set;}    
    [Required]
    public string Password;
}
