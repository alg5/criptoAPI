using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;

namespace CriptoAPI.Services
{
    public class CriptoService
    {
        private const string URL = @"https://data.messari.io/api/v2/assets";
        private const string SECRET_CODE = "36698dd3-9e43-43fe-aec8-48f5532944da";
        public string GetCurrencyData(int limit)
        {
            string res = string.Empty;
            //set querystring parameters
            StringBuilder sb = new StringBuilder();
            sb.Append("?fields=id,symbol,name");
            sb.Append(",metrics/market_data/price_usd");
            sb.Append(",metrics/marketcap/current_marketcap_usd");
            sb.AppendFormat("&limit={0}", limit);

            string urlParameters = sb.ToString();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    // Add an Accept header for JSON format.
                    client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                    //Add Secret key
                    client.DefaultRequestHeaders.Add("x-messari-api-key", SECRET_CODE);
                    // List data response.
                    HttpResponseMessage response = client.GetAsync(urlParameters).Result; 
                    if (response.IsSuccessStatusCode)
                    {
                        res =  response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    }
 
                }

            }
            catch (Exception ex)
            {
                //TODO
                string msg = ex.Message;
            }
            return res;

        }
    }
}
