using System.ComponentModel.DataAnnotations;

namespace ComercioElectronico.Domain;

public class Carro
{
    [Required]
    public Guid Id { get; set;}
    [Required]
    public DateTime? FechaCreacion { get; set;}
    [Required]
    public DateTime? FechaModificacion { get; set;}
    [Required]
    public Guid ClienteId { get; set;}
    public virtual Cliente? Cliente { get; set;}
    public virtual ICollection<CarroItem> Items { get; set;} = new List<CarroItem>();
    [Required]
    public decimal Total {get;set;}

}
