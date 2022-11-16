using FluentValidation;

namespace ComercioElectronico.Application;

public class MarcaCreateDtoValidator : AbstractValidator<MarcaCreateDto>
{
    public MarcaCreateDtoValidator()
    {
        //RuleFor(x => x).Must(x => false).WithMessage("Verificacion de validaciones cen el proyecto");

        RuleFor(x => x.Nombre).MinimumLength(2);
    }
}
