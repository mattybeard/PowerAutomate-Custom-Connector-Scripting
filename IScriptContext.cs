using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public interface IScriptContext
{
    string CorrelationId { get; }
    string OperationId { get; }
    Uri OriginalRequestUri { get; }
    HttpRequestMessage Request { get; }
    Uri CreateNotificationUri(string pathAndQuerySuffix);
    Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
}