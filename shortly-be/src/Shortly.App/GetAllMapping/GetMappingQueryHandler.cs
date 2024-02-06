using MediatR;
using Shortly.Infrastructure;

namespace Shortly.App.GetMapping;

public sealed class GetAllMappingsQueryHandler(IMappingRepository _mappingRepository) : IRequestHandler<GetAllMappingsQuery, GetAllMappingsQueryResponse>
{
    public async Task<GetAllMappingsQueryResponse> Handle(GetAllMappingsQuery request, CancellationToken cancellationToken)
    {
        var results = await _mappingRepository.GetAllAsync(cancellationToken);
        return new GetAllMappingsQueryResponse(results.Select(r => new Mapping(r.Id, r.DestinationUrl, r.IsActive)));
    }
}