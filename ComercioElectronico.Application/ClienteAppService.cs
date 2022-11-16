using AutoMapper;
using ComercioElectronico.Domain;

namespace ComercioElectronico.Application;

public class ClienteAppService : IClienteAppService
{
    private readonly IClienteRepository repository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ClienteAppService(IClienteRepository repository, IUnitOfWork unitOfWork,IMapper mapper)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        this.mapper=mapper;
    }
    public async Task<ClienteDto> CreateAsync(ClienteCreateUpdateDto clienteCreateUpdateDto)
    {

        var cliente = mapper.Map<ClienteCreateUpdateDto,Cliente>(clienteCreateUpdateDto);

        cliente=await repository.AddAsync(cliente);
        await unitOfWork.SaveChangesAsync();
        
        
        var clienteDto = mapper.Map<Cliente,ClienteDto>(cliente);


        return clienteDto;
    }

    public async Task<bool> DeleteAsync(Guid clienteId)
    {
        Cliente cliente=await repository.GetByIdAsync(clienteId);
        if(cliente==null)
        {
            throw new ArgumentException($"El cliente con el id: {clienteId}, no existe");
        }
        repository.Delete(cliente);

        await unitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<ClienteDto> GetAll()
    {
        List<Cliente> listaTiposCliente= repository.GetAll().ToList();
            
        return listaTiposCliente.Select(x=>mapper.Map<Cliente,ClienteDto>(x)).ToList();


    }

    public async Task UpdateAsync(Guid clienteId, ClienteCreateUpdateDto clienteCreateUpdateDto)
    {
        var cliente = await repository.GetByIdAsync(clienteId);
        if (cliente == null){
            throw new ArgumentException($"El tipo cliente el id: {clienteId}, no existe");
        }

        // cliente.Nombre=clienteCreateUpdateDto.Nombre;
        // cliente.Precio=clienteCreateUpdateDto.Precio;
        // cliente.Descripcion=clienteCreateUpdateDto.Descripcion;
        // cliente.Observaciones=clienteCreateUpdateDto.Observaciones;
        // cliente.FechaVencimiento=clienteCreateUpdateDto.FechaVencimiento;
        // cliente.Existencias=clienteCreateUpdateDto.Existencias;
        // cliente.MarcaId=clienteCreateUpdateDto.MarcaId;
        // cliente.TipoClienteId=clienteCreateUpdateDto.TipoClienteId;
        
        cliente.Nombres=clienteCreateUpdateDto.Nombres;
        cliente.Apellidos=clienteCreateUpdateDto.Apellidos;
        cliente.Direccion=clienteCreateUpdateDto.Direccion;
        cliente.Telefono=clienteCreateUpdateDto.Telefono;
        cliente.Email=clienteCreateUpdateDto.Email;

        //Persistencia objeto
        await repository.UpdateAsync(cliente);
        await repository.UnitOfWork.SaveChangesAsync();

        return;
    }
}
