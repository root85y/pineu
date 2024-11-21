namespace Pineu.Application.MainDomain.UserDiscounts.Queries.DTOs {
    public sealed record GetAllUserDiscountResponse(string Code, string Title, int Off, bool IsExpired);
}
