using FluentValidation;

namespace ComercioElectronico.Application;

public class ClienteCreateUpdateDtoValidator : AbstractValidator<ClienteCreateUpdateDto>
{
    public ClienteCreateUpdateDtoValidator()
    {
        RuleFor(x => x.Nombres).MinimumLength(2);
    }
}
