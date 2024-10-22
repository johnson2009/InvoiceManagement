namespace Invoice.API.Contract;

public class CommonResponseBase<T>
{
    public Guid RequestId { get; set; }

    public ResponseCode ResponseCode{get;set;}

    public T? Data{get;set;}

    public long RefreshDate
    {
        get
        {
            return DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }
    }
}
