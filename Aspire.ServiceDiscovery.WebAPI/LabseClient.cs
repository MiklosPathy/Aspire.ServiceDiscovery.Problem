internal class LabseClient(HttpClient httpClient)
{
    public async Task<string> LabseTest()
    {
        try
        {
            var response = await httpClient.GetAsync("/v1/models/ainize/metadata");
            return response.ToString();
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}