using ComercioElectronico.Application;
using Microsoft.AspNetCore.Mvc;

namespace ComercioElectronico.HttpApi.Controllers;

[ApiController]
[Route("[controller]")]
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
    public async Task<ClienteDto> registrar([FromForm] ClienteCreateUpdateDto clienteCreateUpdateDto)
    {
        return await clienteAppService.CreateAsync(clienteCreateUpdateDto);
    }

    [HttpPut("{clienteId}")]
    public async Task actualizar(Guid clienteId, [FromForm] ClienteCreateUpdateDto clienteCreateUpdateDto)
    {
        await clienteAppService.UpdateAsync(clienteId,clienteCreateUpdateDto);
    }

    [HttpDelete("{clienteId}")]
    public async Task<bool> DeleteAsync(Guid clienteId)
    {

        return await clienteAppService.DeleteAsync(clienteId);

    }
}
