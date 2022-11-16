using System.ComponentModel.DataAnnotations;

namespace ComercioElectronico.Domain;

public class CarroItem
{
    [Required]
    public Guid Id { get; set;}
    [Required]
    public int Cantidad { get; set;}
    [Required]
    public Guid CarroId { get; set;}
    public virtual Carro Carro { get; set;}
    [Required]
    public Guid ProductoId { get; set;}
    public virtual Producto Producto { get; set;}
}
