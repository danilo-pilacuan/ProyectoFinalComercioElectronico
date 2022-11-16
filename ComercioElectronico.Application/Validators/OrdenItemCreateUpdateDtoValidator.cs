using FluentValidation;

namespace ComercioElectronico.Application;

public class OrdenItemCreateUpdateDtoValidator : AbstractValidator<OrdenItemCreateUpdateDto>
{
    public OrdenItemCreateUpdateDtoValidator ()
    {
        RuleFor(x => x.Cantidad).GreaterThan(0);
    }
}
