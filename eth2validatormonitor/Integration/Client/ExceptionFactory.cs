/* 
 * Beaconcha.in ETH2 API
 *
 * High performance API for querying information from the Ethereum 2.0 beacon chain The API is currently free to use. A fair use policy applies. Calls are rate limited to 10 requests / 1 minute / IP. All API results are cached for 1 minute. If you required a higher usage plan please checkout https://beaconcha.in/pricing.
 *
 * OpenAPI spec version: 1.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */


using System;
using RestSharp;

namespace IO.Swagger.Client
{
    /// <summary>
    /// A delegate to ExceptionFactory method
    /// </summary>
    /// <param name="methodName">Method name</param>
    /// <param name="response">Response</param>
    /// <returns>Exceptions</returns>
    public delegate Exception ExceptionFactory(string methodName, IRestResponse response);
}
