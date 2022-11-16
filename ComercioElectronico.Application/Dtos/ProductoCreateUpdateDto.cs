using System.ComponentModel.DataAnnotations;
using ComercioElectronico.Domain;

namespace ComercioElectronico.Application;

public class ProductoCreateUpdateDto
{
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAX)]
    public string Nombre { get; set;}
    [Required]
    public string Precio { get; set;}
    [Required]
    [StringLength(DominioConstantes.DESCRIPCION_MAX)]
    public string Descripcion { get; set;}
    [Required]
    public int Existencias { get; set;}
    [Required]
    [StringLength(DominioConstantes.EMAIL_MAX)]
    public string Observaciones { get; set;}
    [Required]
    public DateTime? FechaVencimiento { get; set;}
    [Required]
    public string MarcaId{ get; set;}
    [Required]
    public string TipoProductoId{ get; set;}
}
