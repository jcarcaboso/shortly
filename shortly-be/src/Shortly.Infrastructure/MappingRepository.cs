using Microsoft.EntityFrameworkCore;
using Shortly.Domain;
using Shortly.Infrastructure.Models;

namespace Shortly.Infrastructure;

internal sealed class MappingRepository(ShortlyContext context) : IMappingRepository
{
    public async Task AddMappingAsync(string id, string destinationUrl, CancellationToken ct)
    {
        await context.UrlMappings.AddAsync(new ShortUrlMapping()
        {
            Id = id,
            Url = destinationUrl
        }, ct);
        await context.SaveChangesAsync(ct);
    }

    public async Task<IEnumerable<UrlMapping>> GetAllAsync(CancellationToken ct)
    {
        return (await context.UrlMappings
                .AsNoTrackingWithIdentityResolution()
            .ToListAsync(ct))
            .Select(m => new UrlMapping(m.Id, m.Url, m.IsActive));
    }

    public async Task<string> GetMappingAsync(string id)
    {
        var mapping = await GetMapping(id);
        return mapping.Url;
    }

    public async Task ToggleMappingAsync(string id, CancellationToken ct)
    {
        var mapping = await GetMapping(id);

        mapping.IsActive = !mapping.IsActive;

        await context.SaveChangesAsync(ct);
    }

    private async Task<ShortUrlMapping> GetMapping(string id)
    {
        var mapping = await context.UrlMappings.FindAsync(id);
        return mapping!;
    }
}