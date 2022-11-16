using System.ComponentModel.DataAnnotations;

namespace ComercioElectronico.Application;

public class ListaDeseosItemCreateUpdateDto
{
    [Required]
    public Guid ListaDeseosId { get; set;}
    [Required]
    public Guid ProductoId { get; set;}
    
}
