using MediatR;

namespace Shortly.App.GetKey;

public sealed record GetKeyQuery : IRequest<string>
{

}