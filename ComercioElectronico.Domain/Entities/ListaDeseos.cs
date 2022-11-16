using System.ComponentModel.DataAnnotations;

namespace ComercioElectronico.Domain;

public class ListaDeseos
{
    [Required]
    public Guid Id { get; set;}
    [Required]
    public Guid ClienteId { get; set;}
    public virtual Cliente Cliente { get; set;}
    public virtual ICollection<ListaDeseosItem> Items { get; set;} = new List<ListaDeseosItem>();
}
