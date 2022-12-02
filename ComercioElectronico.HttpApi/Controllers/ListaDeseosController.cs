using ComercioElectronico.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace ComercioElectronico.HttpApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableCors]
[Authorize]
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

    [HttpPost("ListaDeseosItem")]
    public async Task<ListaDeseosItemDto> registrarListaDeseosItem([FromBody] ListaDeseosItemCreateUpdateDto listaDeseosItemCreateUpdateDto)
    {
        return await listaDeseosAppService.CreateListaDeseosItemAsync(listaDeseosItemCreateUpdateDto);
    }

    [HttpPut("{listaDeseosId}")]
    public async Task actualizar(Guid listaDeseosId, [FromBody] ListaDeseosCreateUpdateDto listaDeseosCreateUpdateDto)
    {
        await listaDeseosAppService.UpdateAsync(listaDeseosId,listaDeseosCreateUpdateDto);
    }

    [HttpDelete("{listaDeseosId}")]
    public async Task<bool> DeleteAsync(Guid listaDeseosId)
    {

        return await listaDeseosAppService.DeleteAsync(listaDeseosId);

    }
}
