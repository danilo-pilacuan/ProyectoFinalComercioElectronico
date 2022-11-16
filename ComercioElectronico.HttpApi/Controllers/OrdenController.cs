using ComercioElectronico.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComercioElectronico.HttpApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrdenController:ControllerBase
{
    private readonly IOrdenAppService ordenAppService;
    public OrdenController(IOrdenAppService ordenAppService)
    {
        this.ordenAppService=ordenAppService;
    }

    [HttpGet]
    public ICollection<OrdenDto> obtenerMarcas()
    {
        return ordenAppService.GetAll();
    }

    [HttpPost]
    public async Task<OrdenDto> registrar([FromBody] OrdenCreateUpdateDto ordenCreateUpdateDto)
    {
        return await ordenAppService.CreateAsync(ordenCreateUpdateDto);
    }
    
    [HttpPost("OrdenItem")]
    public async Task<OrdenItemDto> registrarOrdenItem([FromForm] OrdenItemCreateUpdateDto ordenItemCreateUpdateDto)
    {
        return await ordenAppService.CreateOrdenItemAsync(ordenItemCreateUpdateDto);
    }

    [HttpPut("{ordenId}")]
    public async Task actualizar(Guid ordenId, [FromForm] OrdenCreateUpdateDto ordenCreateUpdateDto)
    {
        await ordenAppService.UpdateAsync(ordenId,ordenCreateUpdateDto);
    }

    [HttpDelete("{ordenId}")]
    public async Task<bool> DeleteAsync(Guid ordenId)
    {

        return await ordenAppService.DeleteAsync(ordenId);

    }
}
