using TodoApi.Shared.Enums;

namespace TodoApi.Shared.Exceptions;

public class NotFoundException : Exception
{
    public ErrorCodeEnums ErrorCode;
    
    public string ErrorMessage;

    public NotFoundException(ErrorCodeEnums errorCode, string errorMessage)
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    }
}