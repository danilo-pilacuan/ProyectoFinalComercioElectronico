using ComercioElectronico.Application;
using Microsoft.AspNetCore.Mvc;

namespace ComercioElectronico.HttpApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MarcasController:ControllerBase
{

    private readonly IMarcaAppService marcaAppservice;

    public MarcasController(IMarcaAppService marcaAppservice)
    {
        this.marcaAppservice=marcaAppservice;
    }

    [HttpGet]
    public ICollection<MarcaDto> obtenerMarcas()
    {
        return marcaAppservice.GetAll();
    }

    [HttpPost]
    public async Task<MarcaDto> registrar([FromForm] MarcaCreateUpdateDto marcaCreateUpdateDto)
    {
        return await marcaAppservice.CreateAsync(marcaCreateUpdateDto);
    }

    [HttpPut("{id}")]
    public async Task actualizar(string id, [FromForm] MarcaCreateUpdateDto marcaCreateUpdateDto)
    {
        await marcaAppservice.UpdateAsync(id,marcaCreateUpdateDto);
    }
}

