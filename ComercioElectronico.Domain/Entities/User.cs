using System.ComponentModel.DataAnnotations;

namespace ComercioElectronico.Domain;

public class User
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
