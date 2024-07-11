using FluentValidation;
using Journey.Communication.Requests;
using Journey.Exception;

namespace Journey.Application.UseCases.Viagens.Activities.Register;

public class ValidatorActivity:AbstractValidator<RequestRegisterActivityJson> 
{
    public ValidatorActivity()
    {
        RuleFor(request => request.Name).NotEmpty().WithMessage(ResourceErrorMessages.NOME_NULO);
    }
}
