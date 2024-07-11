using FluentValidation;
using Journey.Communication.Requests;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;

namespace Journey.Application.UseCases.Viagens.Register;

public class RegisterTripValidator:AbstractValidator<RequestRegisterTripJson>
{
    public RegisterTripValidator()
    {
        //Criando uma regra
        RuleFor(request => request.Name).NotEmpty().WithMessage(ResourceErrorMessages.NOME_NULO);

        RuleFor(request => request.StartDate.Date).GreaterThanOrEqualTo(DateTime.UtcNow.Date)
            .WithMessage(ResourceErrorMessages.A_DATA_DA_VIAGEM_DEVE_SER_POSTERIOR_A_HOJE);

        RuleFor(request => request).Must(request => request.EndDate.Date >= request.StartDate.Date)
            .WithMessage(ResourceErrorMessages.A_DATA_FINAL_DA_VIAGEM_DEVE_SER_MAIOR_QUE_A_DATA_INICIAL);
    }
}