using MediatR;

namespace Shortly.App.GetMapping;

public sealed record GetAllMappingsQuery() : IRequest<GetAllMappingsQueryResponse>;

public sealed record GetAllMappingsQueryResponse(IEnumerable<Mapping> Mappings);