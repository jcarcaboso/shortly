using MediatR;

namespace Shortly.App.GetMapping;

public sealed record GetMappingQuery(string Id) : IRequest<GetMappingQueryResponse>;

public sealed record GetMappingQueryResponse(string Id, string DestinationUrl, bool IsEnabled);