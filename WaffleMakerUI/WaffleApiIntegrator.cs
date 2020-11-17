using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace WaffleMakerUI
{
	class WaffleApiIntegrator
	{
		private static readonly HttpClient httpClient = new HttpClient();

		private const string host = "https://virtserver.swaggerhub.com";
		private const string baseUri = "/NU024/Waffle_Vending_Machine/1.0.0";
		private const string orderApiPath = "/new_order";

		public struct NewOrderResponse
		{
			HttpStatusCode statusCode;
			bool accepted;
			int orderId;

			public NewOrderResponse(HttpStatusCode newStatusCode, bool isAccepted, int newOrderId)
			{
				statusCode = newStatusCode;
				accepted = isAccepted;
				orderId = newOrderId;
			}
		}

		public async Task<NewOrderResponse> RequestWaffleOrder(int waffleCount, int chocolateCount)
		{
			Dictionary<string, string> body = new Dictionary<string, string>()
			{
				{ "waffle_quantity", waffleCount.ToString() }
			};
			string query = "?chocolate_numbers=" + chocolateCount;

			StringContent bodyJson = new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8, "application/json");

			HttpResponseMessage result = await httpClient.PostAsync(host + baseUri + orderApiPath + query, bodyJson);
			bodyJson.Dispose();

			if(result != null)
			{
				string dataString = await result.Content.ReadAsStringAsync();
				MessageBox.Show(dataString);
				Dictionary<string, string> data = (Dictionary<string, string>)JsonConvert.DeserializeObject(dataString, typeof(Dictionary<string, string>));

				NewOrderResponse response = new NewOrderResponse(result.StatusCode, bool.Parse(data["accepted"]), int.Parse(data["order_id"]));
				return response;
			}

			return new NewOrderResponse(HttpStatusCode.BadRequest, false, -1);
		}
	}
}
