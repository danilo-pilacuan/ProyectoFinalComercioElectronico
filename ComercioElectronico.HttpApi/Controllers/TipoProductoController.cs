using ComercioElectronico.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace ComercioElectronico.HttpApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableCors]
[Authorize]
public class TipoProductoController:ControllerBase
{
    private readonly ITipoProductoAppService tipoProductoAppService;
    public TipoProductoController(ITipoProductoAppService tipoProductoAppService)
    {
        this.tipoProductoAppService=tipoProductoAppService;
    }

    [HttpGet]
    public ICollection<TipoProductoDto> obtenerMarcas()
    {
        return tipoProductoAppService.GetAll();
    }

    [HttpPost]
    public async Task<TipoProductoDto> registrar([FromBody] TipoProductoCreateUpdateDto tipoProductoCreateUpdateDto)
    {
        return await tipoProductoAppService.CreateAsync(tipoProductoCreateUpdateDto);
    }

    [HttpPut("{tipoProductoId}")]
    public async Task actualizar(string tipoProductoId, [FromBody] TipoProductoCreateUpdateDto tipoProductoCreateUpdateDto)
    {
        await tipoProductoAppService.UpdateAsync(tipoProductoId,tipoProductoCreateUpdateDto);
    }

    [HttpDelete("{tipoProductoId}")]
    public async Task<bool> DeleteAsync(string tipoProductoId)
    {

        return await tipoProductoAppService.DeleteAsync(tipoProductoId);

    }
}

