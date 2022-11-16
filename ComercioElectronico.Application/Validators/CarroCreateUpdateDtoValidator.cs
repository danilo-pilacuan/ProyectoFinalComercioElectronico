using FluentValidation;

namespace ComercioElectronico.Application;

public class CarroCreateUpdateDtoValidator : AbstractValidator<CarroCreateUpdateDto>
{
    public CarroCreateUpdateDtoValidator ()
    {
        RuleFor(x => x.Total).GreaterThan(0M);
    }
}
