using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Security;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;

namespace PowerBIEmbededWebFormsTeste
{
    public partial class PowerBI : System.Web.UI.Page
    {
        private static string ReportID = ConfigurationManager.AppSettings["powerbi:ReportRole"];
        private static string workspaceCollection = ConfigurationManager.AppSettings["powerbi:WorkspaceCollection"];
        private static string workspaceId = ConfigurationManager.AppSettings["powerbi:WorkspaceId"];
        private static string accessKey = ConfigurationManager.AppSettings["powerbi:AccessKey"];
        private static string apiUrl = ConfigurationManager.AppSettings["powerbi:ApiUrl"];
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (var client = this.CreatePowerBIClient())
                {
                    string myUserID = User.Identity.Name.ToString();
                    IEnumerable<string> myRole = new List<string>() { "Customer", "Developer" };
                    var embedToken = (myUserID == "") ? PowerBIToken.CreateReportEmbedToken(workspaceCollection, workspaceId, ReportID) : 
                        PowerBIToken.CreateReportEmbedToken(workspaceCollection, workspaceId, ReportID, myUserID, myRole);
                    string myTok = embedToken.Generate(accessKey);

                    accessTokenText.Value = myTok;  //input on the report page.

                    embedUrlText.Value = //"https://embedded.powerbi.com/appTokenReportEmbed?reportId=" + ReportID; //input on the report page.
                        "https://app.powerbi.com/reportEmbed?reportId=12363e55-3d42-43c1-bf93-6f60eb03a292&groupId=260b222b-ad33-4dde-adb4-aa82283a45ff&w=2&config=eyJjbHVzdGVyVXJsIjoiaHR0cHM6Ly9XQUJJLUJSQVpJTC1TT1VUSC1CLVBSSU1BUlktcmVkaXJlY3QuYW5hbHlzaXMud2luZG93cy5uZXQiLCJlbWJlZEZlYXR1cmVzIjp7Im1vZGVybkVtYmVkIjpmYWxzZX19";
                }
            }
        }

        private IPowerBIClient CreatePowerBIClient()
        {
            var credentials = new TokenCredentials(accessKey, "AppKey");

            var client = new PowerBIClient(credentials)
            {
                BaseUri = new Uri(apiUrl)
            };

            return client;
        }
    }
}