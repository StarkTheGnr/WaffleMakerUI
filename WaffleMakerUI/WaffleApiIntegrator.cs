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
		private const string host = "https://postman-echo.com";// https://virtserver.swaggerhub.com";
		private const string baseUri = "";//"/NU024/Waffle_Vending_Machine/1.0.0";
		private const string orderApiPath = "/post";//"/new_order";

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

		public async Task<NewOrderResponse> RequestWaffleOrder(int waffleCount, int chocolateCount, string referenceNum)
		{
			MessageBox.Show(referenceNum);
			Dictionary<string, string> body = new Dictionary<string, string>()
			{
				{ "waffle_quantity", waffleCount.ToString() },
				{ "chocolate_numbers", chocolateCount.ToString() },
				{ "transaction_number", referenceNum.ToString() }
			};

			StringContent bodyJson = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

			HttpResponseMessage result = await httpClient.PostAsync(host + baseUri + orderApiPath, bodyJson);
			bodyJson.Dispose();

			if(result != null)
			{
				try
				{
					string dataString = await result.Content.ReadAsStringAsync();
					//testing
					MessageBox.Show(dataString);

					Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(dataString);

					//testing
					MessageBox.Show(JsonConvert.SerializeObject(data["json"]));

					//NewOrderResponse response = new NewOrderResponse(result.StatusCode, bool.Parse(data["accepted"]), int.Parse((string)data["order_id"]));
					//testing
					NewOrderResponse response = new NewOrderResponse(result.StatusCode, false, -1);
					return response;
				}
				catch(Exception)
				{
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
				RequestUri = new Uri(host + baseUri + "/get" + query),//testing orderApiPath),
			};

			HttpResponseMessage result = await httpClient.SendAsync(requestToSend);
			if (result != null)
			{
				try
				{
					string dataString = await result.Content.ReadAsStringAsync();
					//testing
					MessageBox.Show("ds " + dataString);

					Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(dataString);

					//testing
					MessageBox.Show("serialized " + JsonConvert.SerializeObject(data["args"]));

					if (result.StatusCode != HttpStatusCode.Created)
						return null;
					else
					{
						if (int.Parse((string)data["order_status"]) == 0)
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
