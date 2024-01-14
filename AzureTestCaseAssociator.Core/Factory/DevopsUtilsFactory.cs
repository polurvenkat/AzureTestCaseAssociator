using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Net;

namespace AzureTestCaseAssociator.Core.Factory
{
    public static class DevopsUtilsFactory
    {
        /// <summary>
        /// Creates an instance of <see cref="HttpRequestMessage"/> with the specified DevOps access token.
        /// </summary>
        /// <param name="devopsAccessToken">The DevOps access token.</param>
        /// <returns>An instance of <see cref="HttpRequestMessage"/>.</returns>
        public static HttpRequestMessage GetDevOpsRequest(string devopsAccessToken)
        {
            var authenticationHeaderValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($":{devopsAccessToken}")));

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Patch,
                Headers =
                {
                    { HttpRequestHeader.Authorization.ToString(), authenticationHeaderValue.ToString() },
                    { HttpRequestHeader.Accept.ToString(), "application/json" },
                    { HttpRequestHeader.ContentType.ToString(), "application/json-patch+json" }
                }
            };

            return request;
        }
    }
}