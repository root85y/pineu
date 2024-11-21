namespace Pineu.Application.MainDomain.Seizures.Queries.DTOs {
    public sealed record GetSeizuresChartResponse(DateTime Date, int SeizureTimes, double AverageSeizureDuration);
}
