using System.ComponentModel.DataAnnotations;
using ComercioElectronico.Domain;

namespace ComercioElectronico.Application;

public class ClienteDto
{
    [Required]
    public Guid Id { get; set;}
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAX)]
    public string Nombres { get; set;}
    [Required]
    [StringLength(DominioConstantes.NOMBRE_MAX)]
    public string Apellidos { get; set;}
    [Required]
    [StringLength(DominioConstantes.DIR_MAX)]
    public string Direccion { get; set;}
    [Required]
    [StringLength(DominioConstantes.TELF_MAX)]
    public string Telefono { get; set;}
    [Required]
    [StringLength(DominioConstantes.EMAIL_MAX)]
    [EmailAddress]
    public string Email { get; set;}
}
