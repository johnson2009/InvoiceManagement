namespace Invoice.Common.Exceptions;

public class BusinessException: Exception
{
    public List<BusinessError> Errors { get; set; }
    public BusinessException(BusinessError error)
    {
        Errors = new List<BusinessError> { error };
    }
    public BusinessException(List<BusinessError> errors)
    {
        Errors = errors;
    }
}

public class BusinessError
{
    public string Code { get; set; } = "-1";
    public string Message { get; set; }
    public string Details { get; set; }

    public BusinessError(string code)
    {
        Code = code;
    }

    public BusinessError(string code, string message)
    {
        Code = code;
        Message = message;
    }
    public BusinessError(string code, string message, string details)
    {
        Code = code;
        Message = message;
        Details = details;
    }
}
