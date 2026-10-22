namespace taskweb.Services;

public sealed record TelemetrySampleDto(
    long Id,
    DateTime TimestampUtc,
    double TemperatureC,
    double VoltageV,
    double Rpm,
    string Source,
    string Level);
