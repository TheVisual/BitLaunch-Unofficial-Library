using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace BitLaunch
{
    public class BitLaunchHttpClient
    {
        private readonly BitLaunchClient _BitLaunchClient;
        public string Api { get; set; } = "https://app.bitlaunch.io/api/";
        public BitLaunchHttpClient(BitLaunchClient smsClient)
        {
            _BitLaunchClient = smsClient;
        }

        public async Task<HttpResponseMessage> Get(string endpoint)
        {
            var webClient = new HttpClient();

            while (true)
            {
                try
                {
                    webClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _BitLaunchClient.Api_key);
                    return await webClient.GetAsync(Api + endpoint);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        public async Task<HttpResponseMessage> Delete(string endpoint)
        {
            var webClient = new HttpClient();

            while (true)
            {
                try
                {
                    webClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _BitLaunchClient.Api_key);
                    return await webClient.DeleteAsync(Api + endpoint);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
		public async Task<HttpResponseMessage> PostCreate(string endpoint, CreateServerRequest PostData)
		{
			using var webClient = new HttpClient();

			while (true)
			{
				try
				{
					webClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
					webClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
					webClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _BitLaunchClient.Api_key);

					string jsonData = JsonSerializer.Serialize(PostData);
					Console.WriteLine(jsonData);

					var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
					return await webClient.PostAsync(Api + endpoint, content);
				}
				catch (Exception ex)
				{
					throw new Exception(ex.ToString());
				}
			}
		}

	}
}
