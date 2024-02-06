using MediatR;

namespace Shortly.App.AddMapping;

public sealed record AddMappingCommand(string Id, string DestinationUrl) : IRequest<Unit>;