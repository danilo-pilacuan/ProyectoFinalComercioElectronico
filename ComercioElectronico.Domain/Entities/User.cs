using System.ComponentModel.DataAnnotations;

namespace ComercioElectronico.Domain;

public class User
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
