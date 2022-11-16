using ComercioElectronico.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComercioElectronico.HttpApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CarroController:ControllerBase
{
    private readonly ICarroAppService carroAppService;
    public CarroController(ICarroAppService carroAppService)
    {
        this.carroAppService=carroAppService;
    }

    [HttpGet]
    public ICollection<CarroDto> obtenerMarcas()
    {
        return carroAppService.GetAll();
    }

    [HttpPost]
    public async Task<CarroDto> registrar([FromBody] CarroCreateUpdateDto carroCreateUpdateDto)
    {
        return await carroAppService.CreateAsync(carroCreateUpdateDto);
    }

    [HttpPost("CarroItem")]
    public async Task<CarroItemDto> registrarCarroItem([FromForm] CarroItemCreateUpdateDto carroItemCreateUpdateDto)
    {
        return await carroAppService.CreateCarroItemAsync(carroItemCreateUpdateDto);
    }

    [HttpPut("{carroId}")]
    public async Task actualizar(Guid carroId, [FromForm] CarroCreateUpdateDto carroCreateUpdateDto)
    {
        await carroAppService.UpdateAsync(carroId,carroCreateUpdateDto);
    }

    [HttpDelete("{carroId}")]
    public async Task<bool> DeleteAsync(Guid carroId)
    {

        return await carroAppService.DeleteAsync(carroId);
    }
}
