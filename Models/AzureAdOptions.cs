namespace SimpleGraphClient.Models
{
    public class AzureAdOptions
    {
        public string TenantId { get; set; } = string.Empty;

        public string ClientId { get; set; } = string.Empty;

        public string ClientSecret { get; set; } = string.Empty;

        public string InstanceUrl => "https://login.microsoftonline.com/";

        public string[] Scopes => new string[] { "https://graph.microsoft.com/.default" };

        public Uri Authority
        {
            get { return new Uri(InstanceUrl + TenantId); }
        }
    }
}
