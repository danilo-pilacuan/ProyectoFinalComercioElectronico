using ComercioElectronico.Application;
using Microsoft.AspNetCore.Mvc;

namespace ComercioElectronico.HttpApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MarcasController:ControllerBase
{

    private readonly IMarcaAppService marcaAppService;

    public MarcasController(IMarcaAppService marcaAppService)
    {
        this.marcaAppService=marcaAppService;
    }

    [HttpGet]
    public ICollection<MarcaDto> obtenerMarcas()
    {
        return marcaAppService.GetAll();
    }

    [HttpPost]
    public async Task<MarcaDto> registrar([FromForm] MarcaCreateDto marcaCreateDto)
    {
        return await marcaAppService.CreateAsync(marcaCreateDto);
    }

    [HttpPut("{marcaId}")]
    public async Task actualizar(string marcaId, [FromForm] MarcaUpdateDto marcaUpdateDto)
    {
        await marcaAppService.UpdateAsync(marcaId,marcaUpdateDto);
    }

    [HttpDelete("{marcaId}")]
    public async Task<bool> DeleteAsync(string marcaId)
    {

        return await marcaAppService.DeleteAsync(marcaId);

    }
}

