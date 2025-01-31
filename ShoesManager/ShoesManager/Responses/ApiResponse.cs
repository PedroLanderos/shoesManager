namespace ShoesManager.Responses
{
    public record ApiResponse(bool Success = false, int? ErrorCode = null, string? ErrorMessage = null);

    public record ApiResponse<T>(bool Success = false, int? ErrorCode = null, string? ErrorMessage = null, T? Data = default);
}
