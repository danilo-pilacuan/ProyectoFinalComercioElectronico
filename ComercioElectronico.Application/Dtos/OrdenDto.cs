using System.ComponentModel.DataAnnotations;
using ComercioElectronico.Domain;

namespace ComercioElectronico.Application;

public class OrdenDto
{
    [Required]
    public Guid Id { get; set;}
    [Required]
    public DateTime? FechaCreacion { get; set;}
    [Required]
    public EstadoOrden EstadoOrden { get; set;}
    [Required]
    public Guid ClienteId { get; set;}
    [Required]
    public decimal Total {get;set;}
    public virtual Cliente Cliente { get; set;}
    public virtual ICollection<OrdenItemDto> Items { get; set;} = new List<OrdenItemDto>();
}
