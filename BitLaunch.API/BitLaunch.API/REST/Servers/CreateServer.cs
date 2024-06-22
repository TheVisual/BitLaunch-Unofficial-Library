using System.Text.Json;

namespace BitLaunch
{
	public static class CreateServer
	{
		public static async Task<CreateServerRequest> Create(this BitLaunchClient client, string name, int hostID, string hostImageID, string sizeID, string regionID, string password, string? initscript = null, List<string>? sshKeys = null)
		{
			try
			{
				Server server = new Server
				{
					name = name,
					hostID = hostID,
					hostImageID = hostImageID,
					sizeID = sizeID,
					regionID = regionID,
					password = password,
					initscript = initscript,
					sshKeys = sshKeys
				};

				HttpResponseMessage post = await client.HttpClient.PostCreate("servers", new CreateServerRequest { server = server });
				string responseContent = await post.Content.ReadAsStringAsync();
				Console.WriteLine(responseContent);
				return JsonSerializer.Deserialize<CreateServerRequest>(responseContent);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
		}
	}
}
