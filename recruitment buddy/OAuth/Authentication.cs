private OAuthToken RequestAuthorizationToken()
{
    var client = new RestClient("https://us.battle.net/oauth/token");
    var request = new RestRequest(Method.POST);
    request.AddHeader("cache-control", "no-cache");
    request.AddHeader("content-type", "application/x-www-form-urlencoded");
    request.AddParameter("application/x-www-form-urlencoded", $"grant_type=client_credentials&client_id={ClientId}&client_secret={ClientSecret}", ParameterType.RequestBody);

    IRestResponse response = client.Execute(request);

    var token = JsonConvert.DeserializeObject<OAuthToken>(response.Content);
}

public class OAuthToken
{
    public string access_token { get; set; }
    public string token_type { get; set; }
    public int expires_in { get; set; }
    public string scope { get; set; }
}