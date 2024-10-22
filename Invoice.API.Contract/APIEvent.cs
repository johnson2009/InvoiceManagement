namespace Invoice.API.Contract;

public class APIEvent
{
    public Guid EventID{get;set;}
    public string TraceSource{get;set;}

    public APIEvent(string traceSource)
    {
        EventID = Guid.NewGuid();
        TraceSource = traceSource;
    }
}
