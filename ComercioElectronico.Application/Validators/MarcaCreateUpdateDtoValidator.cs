using FluentValidation;

namespace ComercioElectronico.Application;

public class MarcaCreateUpdateDtoValidator : AbstractValidator<MarcaCreateUpdateDto>
{
    public MarcaCreateUpdateDtoValidator()
    {

        RuleFor(x => x.Nombre).MinimumLength(2);
    }
}
