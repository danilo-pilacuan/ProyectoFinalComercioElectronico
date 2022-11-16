using AutoMapper;
using ComercioElectronico.Domain;

namespace ComercioElectronico.Application;

public class TipoProductoAppService : ITipoProductoAppService
{
    private readonly ITipoProductoRepository repository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public TipoProductoAppService(ITipoProductoRepository repository, IUnitOfWork unitOfWork,IMapper mapper)
    {
        this.repository = repository;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    public async Task<TipoProductoDto> CreateAsync(TipoProductoCreateUpdateDto tipoProductoCreateUpdateDto)
    {
        // var tipoProducto = new TipoProducto();
        // tipoProducto.Id=tipoProductoCreateUpdateDto.Id;
        // tipoProducto.Descripcion=tipoProductoCreateUpdateDto.Descripcion;

        
        var tipoProducto = mapper.Map<TipoProductoCreateUpdateDto,TipoProducto>(tipoProductoCreateUpdateDto);


        tipoProducto=await repository.AddAsync(tipoProducto);
        await unitOfWork.SaveChangesAsync();
        
        // var tipoProductoDto = new TipoProductoDto();
        // tipoProductoDto.Id=tipoProducto.Id;
        // tipoProductoDto.Descripcion=tipoProducto.Descripcion;

        var tipoProductoDto = mapper.Map<TipoProducto,TipoProductoDto>(tipoProducto);


        return tipoProductoDto;
    }

    public async Task<bool> DeleteAsync(string tipoProductoId)
    {
        TipoProducto tipoProducto=await repository.GetByIdAsync(tipoProductoId);
        if(tipoProducto==null)
        {
            throw new ArgumentException($"El tipo producto el id: {tipoProductoId}, no existe");
        }
        repository.Delete(tipoProducto);

        await unitOfWork.SaveChangesAsync();

        return true;
    }

    public ICollection<TipoProductoDto> GetAll()
    {
        List<TipoProducto> listaTiposProducto= repository.GetAll().ToList();

        return listaTiposProducto.Select(x=>new TipoProductoDto(){Id=x.Id,Descripcion=x.Descripcion}).ToList();
    }

    public async Task UpdateAsync(string tipoProductoId, TipoProductoCreateUpdateDto tipoProductoCreateUpdateDto)
    {
        var tipoProducto = await repository.GetByIdAsync(tipoProductoId);
        if (tipoProducto == null){
            throw new ArgumentException($"El tipo producto el id: {tipoProductoId}, no existe");
        }

        tipoProducto.Descripcion = tipoProductoCreateUpdateDto.Descripcion;

        //Persistencia objeto
        await repository.UpdateAsync(tipoProducto);
        await repository.UnitOfWork.SaveChangesAsync();

        return;
    }
}
