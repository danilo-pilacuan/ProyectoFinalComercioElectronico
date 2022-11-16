using System.ComponentModel.DataAnnotations;

namespace ComercioElectronico.Application;

public class ListaDeseosCreateUpdateDto
{
    [Required]
    public Guid ClienteId { get; set;}
    
}
