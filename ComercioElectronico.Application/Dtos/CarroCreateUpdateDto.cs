using System.ComponentModel.DataAnnotations;

namespace ComercioElectronico.Application;

public class CarroCreateUpdateDto
{
    [Required]
    public DateTime? FechaCreacion { get; set;}
    [Required]
    public DateTime? FechaModificacion { get; set;}
    [Required]
    public Guid ClienteId { get; set;}
    [Required]
    public decimal Total {get;set;}
}
