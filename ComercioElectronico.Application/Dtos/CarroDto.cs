using System.ComponentModel.DataAnnotations;
using ComercioElectronico.Domain;

namespace ComercioElectronico.Application;

public class CarroDto
{
    [Required]
    public Guid Id { get; set;}
    [Required]
    public DateTime? FechaCreacion { get; set;}
    [Required]
    public DateTime? FechaModificacion { get; set;}
    [Required]
    public Guid ClienteId { get; set;}
    [Required]
    public decimal Total {get;set;}
    public virtual Cliente Cliente { get; set;}
    public virtual ICollection<CarroItemDto> Items { get; set;} = new List<CarroItemDto>();
}
