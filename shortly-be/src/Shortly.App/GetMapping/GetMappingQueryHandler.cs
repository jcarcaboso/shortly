using MediatR;
using Shortly.Infrastructure;

namespace Shortly.App.GetMapping;

public sealed class GetMappingQueryHandler(IMappingRepository _mappingRepository) : IRequestHandler<GetMappingQuery, GetMappingQueryResponse>
{
    public async Task<GetMappingQueryResponse> Handle(GetMappingQuery request, CancellationToken cancellationToken)
    {
        // TODO: change this
        var mapping = await _mappingRepository.GetMappingAsync(request.Id);
        return new GetMappingQueryResponse(request.Id, mapping, true);
    }
}