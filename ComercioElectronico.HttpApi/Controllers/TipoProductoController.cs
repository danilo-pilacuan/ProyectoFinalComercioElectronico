using ComercioElectronico.Application;
using Microsoft.AspNetCore.Mvc;

namespace ComercioElectronico.HttpApi.Controllers;

[ApiController]
[Route("[controller]")]
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
    public async Task<TipoProductoDto> registrar([FromForm] TipoProductoCreateUpdateDto tipoProductoCreateUpdateDto)
    {
        return await tipoProductoAppService.CreateAsync(tipoProductoCreateUpdateDto);
    }

    [HttpPut("{id}")]
    public async Task actualizar(string id, [FromForm] TipoProductoCreateUpdateDto tipoProductoCreateUpdateDto)
    {
        await tipoProductoAppService.UpdateAsync(id,tipoProductoCreateUpdateDto);
    }
}

