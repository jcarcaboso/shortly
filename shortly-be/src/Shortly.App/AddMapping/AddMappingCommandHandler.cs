using MediatR;
using Shortly.Infrastructure;

namespace Shortly.App.AddMapping;

public sealed class AddMappingCommandHandler(IMappingRepository _mappingRepository) : IRequestHandler<AddMappingCommand, Unit>
{
    public async Task<Unit> Handle(AddMappingCommand request, CancellationToken cancellationToken)
    {
        await _mappingRepository.AddMappingAsync(request.Id, request.DestinationUrl, cancellationToken);

        return Unit.Value;
    }
}