using System.ComponentModel.DataAnnotations;

namespace ComercioElectronico.Domain;

public class Orden
{
    [Required]
    public Guid Id { get; set;}
    [Required]
    public DateTime? FechaCreacion { get; set;}
    [Required]
    public EstadoOrden EstadoOrden { get; set;}
    [Required]
    public Guid ClienteId { get; set;}
    public virtual Cliente Cliente { get; set;}
    public ICollection<OrdenItem> Items { get; set;} = new List<OrdenItem>();
    [Required]
    public decimal Total {get;set;}
}

public enum EstadoOrden{

    Anulada = 0,

    Registrada=1,

    Procesada=2,

    Entregada=3
}
