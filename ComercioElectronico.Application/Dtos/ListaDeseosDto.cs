using System.ComponentModel.DataAnnotations;
using ComercioElectronico.Domain;

namespace ComercioElectronico.Application;

public class ListaDeseosDto
{
    [Required]
    public Guid Id { get; set;}
    [Required]
    public Guid ClienteId { get; set;}
    public virtual Cliente Cliente { get; set;}
    public virtual ICollection<ListaDeseosItemDto> Items { get; set;} = new List<ListaDeseosItemDto>();
}
