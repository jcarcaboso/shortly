namespace Shortly.Domain;

public sealed record UrlMapping(string Id, string DestinationUrl, bool IsActive = true);