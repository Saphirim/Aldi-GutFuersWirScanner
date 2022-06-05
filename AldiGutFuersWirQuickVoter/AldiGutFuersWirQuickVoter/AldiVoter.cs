using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AldiGutFuersWirQuickVoter
{
    public class AldiVoter
    {
        HttpClient _client;
        const string UriPath = "";

        public AldiVoter()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://www.aldi-gutfuerswir.de");

            if (string.IsNullOrEmpty(UriPath))
            {
                Console.WriteLine("Insert your UriPath containting your organization to AldiVoter.cs first! '/api/v3/votings/[YOUR_ORG_REFERENCE_HERE]/vote/]'");
            }
        }

        public string? ExtractCode(string barCodeText)
        {
            var barCodeUri = new Uri(barCodeText);
            var queryParams = System.Web.HttpUtility.ParseQueryString(barCodeUri.Query);

            return queryParams.GetValues("c")?[0]?.ToUpper();
        }

        public async Task<bool> TryVoting(string votingCode)
        {
            if (string.IsNullOrEmpty(votingCode))
            {
                return false;
            }

            var postContent = "{\"projectpromoter\":\"tsv-grafing-ev\",\"direct_action\":\"\",\"email\":\"[\\\"" + votingCode + "\\\"]\"}";
            var response = await _client.PostAsync(UriPath, new StringContent(postContent, Encoding.UTF8, "application/json"));

            return response.StatusCode == HttpStatusCode.Created;
        }
    }
}
