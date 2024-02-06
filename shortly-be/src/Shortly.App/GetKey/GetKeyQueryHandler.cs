using System.Security.Cryptography;
using System.Text;
using MediatR;

namespace Shortly.App.GetKey;

public sealed record GetKeyQueryHandler : IRequestHandler<GetKeyQuery, string>
{
    const int MaxLengthHash = 6;

    public Task<string> Handle(GetKeyQuery request, CancellationToken cancellationToken)
    {
        var guid = Guid.NewGuid().ToString();

        var bytes = Encoding.UTF8.GetBytes(guid);
        var hash = SHA256.HashData(bytes);

        var result = hash.Take(MaxLengthHash).Aggregate(
            new StringBuilder(),
            (builder, b) => builder.Append(b.ToString("x2")),
            builder => builder.ToString());

        return Task.FromResult(result);
    }
}