using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public abstract class ScriptBase
{
    public IScriptContext Context { get; set; }
    public CancellationToken CancellationToken { get; set; }
    public abstract Task<HttpResponseMessage> ExecuteAsync();
    public static StringContent CreateJsonContent(string serializedJson)
    {
        return new StringContent(serializedJson);
    }
}
