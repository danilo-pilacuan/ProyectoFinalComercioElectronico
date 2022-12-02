using ComercioElectronico.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace ComercioElectronico.HttpApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableCors]
[Authorize]
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
    public async Task<MarcaDto> registrar([FromBody] MarcaCreateDto marcaCreateDto)
    {
        return await marcaAppService.CreateAsync(marcaCreateDto);
    }

    [HttpPut("{marcaId}")]
    public async Task actualizar(string marcaId, [FromBody] MarcaUpdateDto marcaUpdateDto)
    {
        await marcaAppService.UpdateAsync(marcaId,marcaUpdateDto);
    }

    [HttpDelete("{marcaId}")]
    public async Task<bool> DeleteAsync(string marcaId)
    {

        return await marcaAppService.DeleteAsync(marcaId);

    }
}

