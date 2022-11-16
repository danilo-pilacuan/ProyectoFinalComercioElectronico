using System.ComponentModel.DataAnnotations;

namespace ComercioElectronico.Domain;

public class OrdenItem
{
    [Required]
    public Guid Id { get; set;}
    [Required]
    public int Cantidad { get; set;}
    [Required]
    public Guid OrdenId { get; set;}
    public virtual Orden Orden { get; set;}
    [Required]
    public Guid ProductoId { get; set;}
    public virtual Producto Producto { get; set;}
}
