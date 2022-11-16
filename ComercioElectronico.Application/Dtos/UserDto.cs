using System.ComponentModel.DataAnnotations;
using ComercioElectronico.Domain;

namespace ComercioElectronico.Application;

public class UserDto
{
    [Required]
    public int Id{get;set;}
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAX)]
    public string UserName{get;set;}    
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAX)]
    public string Contrasenia{get;set;}    
}
