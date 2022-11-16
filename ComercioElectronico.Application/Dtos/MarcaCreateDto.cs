using System.ComponentModel.DataAnnotations;
using ComercioElectronico.Domain;

namespace ComercioElectronico.Application;

public class MarcaCreateDto
{
    [Required]
    public string Id { get; set;}
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAX)]
    public string Nombre { get; set;}
}
