using FluentValidation;

namespace ComercioElectronico.Application;

public class OrdenCreateUpdateDtoValidator : AbstractValidator<OrdenCreateUpdateDto>
{
    public OrdenCreateUpdateDtoValidator ()
    {
        RuleFor(x => x.Total).GreaterThan(0M);
    }
}
