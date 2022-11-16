using System.ComponentModel.DataAnnotations;

namespace ComercioElectronico.Domain;

public class Marca
{
    [Required]
    [StringLength(DominioConstantes.ID_MAX)]
    public string Id{get;set;}
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAX)]
    public string Nombre{get;set;}    
}
