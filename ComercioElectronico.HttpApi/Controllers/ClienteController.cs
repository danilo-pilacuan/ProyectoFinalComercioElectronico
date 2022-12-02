using ComercioElectronico.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace ComercioElectronico.HttpApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableCors]
[Authorize]
public class ClienteController:ControllerBase
{
    private readonly IClienteAppService clienteAppService;
    public ClienteController(IClienteAppService clienteAppService)
    {
        this.clienteAppService=clienteAppService;
    }

    [HttpGet]
    public ICollection<ClienteDto> obtenerMarcas()
    {
        return clienteAppService.GetAll();
    }

    [HttpPost]
    public async Task<ClienteDto> registrar([FromBody] ClienteCreateUpdateDto clienteCreateUpdateDto)
    {
        return await clienteAppService.CreateAsync(clienteCreateUpdateDto);
    }

    [HttpPut("{clienteId}")]
    public async Task actualizar(Guid clienteId, [FromBody] ClienteCreateUpdateDto clienteCreateUpdateDto)
    {
        await clienteAppService.UpdateAsync(clienteId,clienteCreateUpdateDto);
    }

    [HttpDelete("{clienteId}")]
    public async Task<bool> DeleteAsync(Guid clienteId)
    {

        return await clienteAppService.DeleteAsync(clienteId);

    }
}
