using System.ComponentModel.DataAnnotations;

namespace ComercioElectronico.Domain;

public class ListaDeseosItem
{
    [Required]
    public Guid Id { get; set;}
    [Required]
    public Guid ListaDeseosId { get; set;}
    public virtual ListaDeseos ListaDeseos { get; set;}
    [Required]
    public Guid ProductoId { get; set;}
    public virtual Producto Producto { get; set;}
}
