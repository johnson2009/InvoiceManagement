namespace Invoice.API.Contract;

public class ErrorResponse
{
    public string ErrorCode{get;set;}
    public string ErrorMessage{get;set;}
    public string ErrorDescription{get;set;}
}