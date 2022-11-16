using ComercioElectronico.Application;
using Microsoft.AspNetCore.Mvc;

namespace ComercioElectronico.HttpApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ListaDeseosController:ControllerBase
{
    private readonly IListaDeseosAppService listaDeseosAppService;
    public ListaDeseosController(IListaDeseosAppService listaDeseosAppService)
    {
        this.listaDeseosAppService=listaDeseosAppService;
    }

    [HttpGet]
    public ICollection<ListaDeseosDto> obtenerMarcas()
    {
        return listaDeseosAppService.GetAll();
    }

    [HttpPost]
    public async Task<ListaDeseosDto> registrar([FromBody] ListaDeseosCreateUpdateDto listaDeseosCreateUpdateDto)
    {
        return await listaDeseosAppService.CreateAsync(listaDeseosCreateUpdateDto);
    }

    [HttpPut("{listaDeseosId}")]
    public async Task actualizar(Guid listaDeseosId, [FromForm] ListaDeseosCreateUpdateDto listaDeseosCreateUpdateDto)
    {
        await listaDeseosAppService.UpdateAsync(listaDeseosId,listaDeseosCreateUpdateDto);
    }

    [HttpDelete("{listaDeseosId}")]
    public async Task<bool> DeleteAsync(Guid listaDeseosId)
    {

        return await listaDeseosAppService.DeleteAsync(listaDeseosId);

    }
}
