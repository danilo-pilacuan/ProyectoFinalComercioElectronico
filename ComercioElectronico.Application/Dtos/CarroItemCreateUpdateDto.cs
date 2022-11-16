using System.ComponentModel.DataAnnotations;

namespace ComercioElectronico.Application;

public class CarroItemCreateUpdateDto
{
    [Required]
    public int Cantidad { get; set;}
    [Required]
    public Guid CarroId { get; set;}
    [Required]
    public Guid ProductoId { get; set;}
}
