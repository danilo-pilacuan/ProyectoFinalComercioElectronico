using System.ComponentModel.DataAnnotations;

namespace ComercioElectronico.Application;

public class ListaDeseosItemDto
{
    [Required]
    public Guid Id { get; set;}
    [Required]
    public Guid ListaDeseosId { get; set;}
    [Required]
    public Guid ProductoId { get; set;}
}
