using System.ComponentModel.DataAnnotations;
using ComercioElectronico.Domain;

namespace ComercioElectronico.Application;

public class TipoProductoCreateUpdateDto
{
    [Required]
    [StringLength(DominioConstantes.ID_MAX)]
    public string Id{get;set;}
    [Required]
    [StringLength(DominioConstantes.DESCRIPCION_MAX)]
    public string Descripcion{get;set;}
}
