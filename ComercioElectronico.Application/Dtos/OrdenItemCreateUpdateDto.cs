using System.ComponentModel.DataAnnotations;

namespace ComercioElectronico.Application;

public class OrdenItemCreateUpdateDto
{
    [Required]
    public int Cantidad { get; set;}
    [Required]
    public Guid OrdenId { get; set;}
    
    [Required]
    public Guid ProductoId { get; set;}
    
}
