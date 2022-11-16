using System.ComponentModel.DataAnnotations;

namespace ComercioElectronico.Domain;

public class TipoProducto
{
    [Required]
    [StringLength(DominioConstantes.ID_MAX)]
    public string Id{get;set;}
    [Required]
    [StringLength(DominioConstantes.DESCRIPCION_MAX)]
    public string Descripcion{get;set;}
}
