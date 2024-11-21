namespace Pineu.Application.MainDomain.ScoreLogs.Queries.DTOs {
    public sealed record GetUsersScoreSummeryResponse(int CurrentScore, int TotalDeliveredScore, int TotalPaymentScore);
}
