using Shortly.Domain;

namespace Shortly.Infrastructure;

public interface IMappingRepository
{
    Task AddMappingAsync(string id, string destinationUrl, CancellationToken ct);
    Task<IEnumerable<UrlMapping>> GetAllAsync(CancellationToken ct);
    Task<string> GetMappingAsync(string id);
    Task ToggleMappingAsync(string id, CancellationToken ct);
}