using FluentValidation;

public class RequestUserLogin
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class RequestUserLoginValidator : AbstractValidator<RequestUserLogin>
{
    public RequestUserLoginValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Email Inválido")
            .Must(e => !string.IsNullOrWhiteSpace(e)).WithMessage("Email não pode estar em branco!");

        RuleFor(x => x.Password)
            .MinimumLength(6).WithMessage("Senha deve ser maior que 6 digitos")
            .Must(p => !string.IsNullOrWhiteSpace(p)).WithMessage("Senha não pode estar em branco!");
    }
}