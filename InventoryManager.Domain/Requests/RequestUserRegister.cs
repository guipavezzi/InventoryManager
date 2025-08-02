using FluentValidation;

public class RequestUserRegister
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class RequestUserRegisterValidator : AbstractValidator<RequestUserRegister>
{
    public RequestUserRegisterValidator()
    {
        RuleFor(x => x.Name)
            .Must(n => !string.IsNullOrWhiteSpace(n))
            .WithMessage("Nome não pode estar em branco!");

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Email Inválido")
            .Must(e => !string.IsNullOrWhiteSpace(e)).WithMessage("Email não pode estar em branco!");

        RuleFor(x => x.Password)
            .MinimumLength(6).WithMessage("Senha deve ser maior que 6 digitos")
            .Must(p => !string.IsNullOrWhiteSpace(p)).WithMessage("Senha não pode estar em branco!");
    }
}