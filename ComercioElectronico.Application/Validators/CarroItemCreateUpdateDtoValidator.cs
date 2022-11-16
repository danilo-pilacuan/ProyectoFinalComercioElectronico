using FluentValidation;

namespace ComercioElectronico.Application;

public class CarroItemCreateUpdateDtoValidator : AbstractValidator<CarroItemCreateUpdateDto>
{
    public CarroItemCreateUpdateDtoValidator ()
    {
        RuleFor(x => x.Cantidad).GreaterThan(0);
    }
}
