using System.ComponentModel.DataAnnotations;
using ComercioElectronico.Domain;

namespace ComercioElectronico.Application;

public class OrdenCreateUpdateDto
{
    [Required]
    public DateTime? FechaCreacion { get; set;}
    [Required]
    public EstadoOrden EstadoOrden { get; set;}
    [Required]
    public Guid ClienteId { get; set;}
    [Required]
    public decimal Total {get;set;}
}
