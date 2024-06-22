using System.Text.Json;

namespace BitLaunch
{
    public static class ListServer
    {
        public static async Task<List<CreateServerResponse>> GetServers(this BitLaunchClient client)
        {
            try
            {
                HttpResponseMessage post = await client.HttpClient.Get("servers");
                return JsonSerializer.Deserialize<List<CreateServerResponse>>(await post.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
