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
		private static readonly HttpClient httpClient = new HttpClient(new WinHttpHandler());

		//testing
		private const string host = "http://localhost:8000"; //No slash at the end
		private const string baseUri = "";
		private const string orderApiPath = "/new_order";
		private const string trackOrderApiPath = "/track_order";

		public struct NewOrderResponse
		{
			public HttpStatusCode statusCode;
			public bool accepted;
			public int orderId;

			public NewOrderResponse(HttpStatusCode newStatusCode, bool isAccepted, int newOrderId)
			{
				statusCode = newStatusCode;
				accepted = isAccepted;
				orderId = newOrderId;
			}
		}

		public async Task<NewOrderResponse> RequestWaffleOrder(int waffleCount, int chocolateCount, string referenceNum, float amount)
		{
			Dictionary<string, string> body = new Dictionary<string, string>()
			{
				{ "waffle_quantity", waffleCount.ToString() },
				{ "chocolate_numbers", chocolateCount.ToString() },
				{ "transaction_number", referenceNum.ToString() },
				{ "amount_paid", amount.ToString() }
			};

			StringContent bodyJson = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

			HttpResponseMessage result = await httpClient.PostAsync(host + baseUri + orderApiPath, bodyJson);
			bodyJson.Dispose();

			if(result != null)
			{
				try
				{
					string dataString = await result.Content.ReadAsStringAsync();

					Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(dataString);

					NewOrderResponse response = new NewOrderResponse(result.StatusCode, bool.Parse(data["accepted"].ToString()), int.Parse(data["order_id"].ToString()));
					return response;
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);

					NewOrderResponse response = new NewOrderResponse(HttpStatusCode.BadRequest, false, -1);
					return response;
				}
				
			}

			return new NewOrderResponse(HttpStatusCode.BadRequest, false, -1);
		}

		public async Task<bool?> TrackWaffleOrder(int orderId)
		{
			string query = "?order_id=" + orderId;

			HttpRequestMessage requestToSend = new HttpRequestMessage()
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(host + baseUri + trackOrderApiPath + query)
			};

			HttpResponseMessage result = await httpClient.SendAsync(requestToSend);
			if (result != null)
			{
				try
				{
					string dataString = await result.Content.ReadAsStringAsync();

					Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(dataString);
					if (result.StatusCode != HttpStatusCode.Created)
						return null;
					else
					{
						if (int.Parse(data["order_status"].ToString()) == 0)
							return false;
						else
							return true;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					return null;
				}
			}

			return null;
		}
	}
}
