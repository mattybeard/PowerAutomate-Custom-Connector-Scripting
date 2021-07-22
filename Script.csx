using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

public class Script : ScriptBase
{
    public override async Task<HttpResponseMessage> ExecuteAsync()
    {
        // Manipulate the request data as applicable before setting it back
        var requestContentAsString = await this.Context.Request.Content.ReadAsStringAsync().ConfigureAwait(false);
        var requestContentAsJson = JObject.Parse(requestContentAsString);
        this.Context.Request.Content = CreateJsonContent(requestContentAsJson.ToString());

        // Make the actual API request
        var response = await this.Context.SendAsync(this.Context.Request, this.CancellationToken).ConfigureAwait(continueOnCapturedContext: false);
            
        // Manipulate the response data as applicable before returning it
        var responseContentAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        var responseContentAsJson = JObject.Parse(responseContentAsString);
        response.Content = CreateJsonContent(responseContentAsJson.ToString());

        return response;
    }
}
