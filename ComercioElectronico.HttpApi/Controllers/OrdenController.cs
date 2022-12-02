using ComercioElectronico.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace ComercioElectronico.HttpApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableCors]
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
    public async Task<OrdenItemDto> registrarOrdenItem([FromBody] OrdenItemCreateUpdateDto ordenItemCreateUpdateDto)
    {
        return await ordenAppService.CreateOrdenItemAsync(ordenItemCreateUpdateDto);
    }

    [HttpPut("{ordenId}")]
    public async Task actualizar(Guid ordenId, [FromBody] OrdenCreateUpdateDto ordenCreateUpdateDto)
    {
        await ordenAppService.UpdateAsync(ordenId,ordenCreateUpdateDto);
    }

    [HttpDelete("{ordenId}")]
    public async Task<bool> DeleteAsync(Guid ordenId)
    {

        return await ordenAppService.DeleteAsync(ordenId);

    }
}
