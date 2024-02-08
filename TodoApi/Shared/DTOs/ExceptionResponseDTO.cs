using TodoApi.Shared.Enums;

namespace TodoApi.Shared.DTOs;

public record ExceptionResponseDTO
{
    public ErrorCodeEnums ErrorCode { get; set; }
    
    public string Message { get; set; }
};